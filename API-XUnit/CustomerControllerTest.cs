using API.Controllers;
using API.Entities;
using API_XUnit.Fixture;
using API_XUnit.Theory;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_XUnit
{
    public class CustomerControllerTest : IClassFixture<ControllerFixture>
    {
        CustomerController customerController;

        public CustomerControllerTest(ControllerFixture fixture)
        {
            customerController = fixture.customerController;
        }

        [Fact]
        public void GetAllValues()
        {
            var result = customerController.Get() as OkObjectResult;
            Assert.Equal(200, result?.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        public void GetValue(int id)
        {
            var result = customerController.Get(id) as OkObjectResult;
            Assert.Equal(200, result?.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        public void DeleteValue(int id)
        {
            var result = customerController.Get(id) as OkObjectResult;
            Assert.Equal(200, result?.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public void ErrorDeleteValue(int id)
        {
            var result = customerController.Delete(id) as NotFoundObjectResult;
            Assert.Equal(404, result?.StatusCode);
        }

        [Theory]
        [ClassData(typeof(CustomerTheoryData))]
        public void AddValue(CustomerModel obj)
        {
            var result = customerController.Add(obj) as OkObjectResult;
            Assert.Equal(200, result?.StatusCode);
        }

        [Theory]
        [ClassData(typeof(CustomerTheoryData))]
        public void UpdateValue(CustomerModel obj)
        {
            obj.CustomerId = 2;
            var result = customerController.Update(obj) as OkObjectResult;
            Assert.Equal(200, result?.StatusCode);
        }

        [Theory]
        [ClassData(typeof(CustomerTheoryDataError))]
        public void AddErrorValue(CustomerModel obj)
        {
            var result = customerController.Add(obj) as BadRequestObjectResult;
            Assert.Equal(400, result?.StatusCode);
        }
    }
}