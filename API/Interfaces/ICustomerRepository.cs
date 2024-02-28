using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        public string Add(CustomerModel obj);
        public string Update(CustomerModel obj);
        public bool Delete(int id);
        public IEnumerable<CustomerModel> List();
        public CustomerModel Get(int id);
    }
}
