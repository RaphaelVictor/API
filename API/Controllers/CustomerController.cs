using API.Context;
using API.Entities;
using API.Interfaces.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customer;

        public CustomerController(ICustomerRepository context)
        {
            _customer = context;
        }


        [HttpGet("Get")]
        public IActionResult Get()
        {
            var customers = _customer.List();

            if (customers.Count() == 0) { return NotFound(new { message = $"No customers found" }); };

            return Ok(new { message = customers });
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            var customer = _customer.Get(id);

            if (customer == null) { return NotFound(new { message = $@"No customer found with ID '{id}'" }); };

            return Ok(new { message = customer });
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!_customer.Delete(id)) { return NotFound(new { message = $@"No customer found with ID '{id}'" }); }

            return Ok(new { message = $"Customer '{id}' was deleted." });
        }

        [HttpPost("Update")]
        public IActionResult Update(CustomerModel customer)
        {
            var message = _customer.Update(customer);

            if (!string.IsNullOrEmpty(message)) { return BadRequest(new { message }); }

            return Ok(new { message = $"Customer '{customer.CustomerId}' was updated.", ID = customer.CustomerId });
        }

        [HttpPost("Add")]
        public IActionResult Add(CustomerModel customer)
        {
            var message = _customer.Add(customer);

            if (!int.TryParse(message, out int n)) { return BadRequest(new { message }); }

            return Ok(new { message = $"Customer '{n}' was created.", ID = n }); ;
        }
    }
}
