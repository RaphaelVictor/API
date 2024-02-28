using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_XUnit.Theory
{
    public class CustomerTheoryData : TheoryData<CustomerModel>
    {
        public CustomerTheoryData() 
        {
            Add(new CustomerModel()
            {
                Name = "Theory Test",
                DNI = "81544670",
                Address = "Address Theory Test",
                Email = "Theory@gmail.com",
                Mobile = "+5491123456789",
                City = "TheoryCity",
                State = "TheoryState",
            });
        }
    }
}
