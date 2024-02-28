using API.Context;
using API.Entities;
using API.Interfaces.Repository;
using CountryValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _context;
        public CustomerRepository(DatabaseContext ctx)
        {
            _context = ctx;
        }

        public bool Delete(int id)
        {
            var obj = Get(id);
            if (obj == null)
                return false;

            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        public string Add(CustomerModel obj)
        {
            var validate = ValidateCustomer(obj);

            if (string.IsNullOrEmpty(validate))
            {
                _context.Add(obj);
                _context.SaveChanges();
                return obj.CustomerId.ToString();
            }
            else
                return validate;
        }

        public string Update(CustomerModel obj)
        {
            var customer = _context.Customers.Where(a => a.CustomerId == obj.CustomerId).FirstOrDefault();
            if (customer == null)
                return $"Customer {obj.CustomerId} doesn't exists";

            var validate = ValidateCustomer(customer);

            if(string.IsNullOrEmpty(validate))
            {
                _context.Update(customer);
                _context.SaveChanges();
                return "";
            }
            else
                return validate;
        }

        private string ValidateCustomer(CustomerModel obj)
        {
            if (string.IsNullOrEmpty(obj.Name))
                return ErrorReturn("Name");

            CountryValidator validator = new CountryValidator();
            var dniResult = validator.ValidateNationalIdentityCode(obj.DNI, Country.AR);

            obj.DNI = obj.DNI.RemoveSpecialCharacthers();

            if (!dniResult.IsValid)
                return ErrorReturn("DNI");

            try
            {
                if (!string.IsNullOrEmpty(obj.Email))
                {
                    var email = new System.Net.Mail.MailAddress(obj.Email);
                }
            }
            catch (Exception)
            {
                return ErrorReturn("E-mail");
            }

            if (!string.IsNullOrEmpty(obj.Phone))
                if (!ValidatePhoneNumber(obj.Phone))
                    return ErrorReturn("Phone");

            if (!string.IsNullOrEmpty(obj.Mobile))
                if (!ValidateMobileNumber(obj.Mobile))
                    return ErrorReturn("Mobile"); 

            return "";
        }

        static string ErrorReturn(string msg)
        {
            return $"The {msg} of the Customer is not valid";
        }

        static bool ValidatePhoneNumber(string numero)
        {
            // Expressão regular para validar números de telefone argentinos
            string regex = @"^\+?549?(11|2\d|3\d|4\d|5\d|6\d|7\d|8\d|9\d)\d{8}$";

            // Verifica se o número corresponde à expressão regular
            return Regex.IsMatch(numero, regex);
        }

        static bool ValidateMobileNumber(string numero)
        {
            // Expressão regular para validar números de celular argentinos
            string regex = @"^\+?549?(11|2\d|3\d|4\d|5\d|6\d|7\d|8\d|9\d)\d{8}$";

            // Verifica se o número corresponde à expressão regular
            return Regex.IsMatch(numero, regex);
        }

        public IEnumerable<CustomerModel> List()
        {
            return _context.Customers.ToList();
        }

        public CustomerModel Get(int id)
        {
            return _context.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
        }

    }
}
