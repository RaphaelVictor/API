using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_XUnit.Theory
{
    internal class CustomerTheoryDataError : TheoryData<CustomerModel>
    {
        public CustomerTheoryDataError()
        {
            //DNI Invalid
            Add(new CustomerModel()
            {
                Name = "Theory Test",
                DNI = "8154460",
                Address = "Address Theory Test",
                Email = "Theory@gmail.com",
                Mobile = "+5491123456789",
                City = "TheoryCity",
                State = "TheoryState",
            });
            //Email Invalid
            Add(new CustomerModel()
            {
                Name = "Theory Test",
                DNI = "81544670",
                Address = "Address Theory Test",
                Email = "Theorygmail.com",
                Mobile = "+5491123456789",
                City = "TheoryCity",
                State = "TheoryState",
            });
            //Mobile Invalid
            Add(new CustomerModel()
            {
                Name = "Theory Test",
                DNI = "81544670",
                Address = "Address Theory Test",
                Email = "Theory@gmail.com",
                Mobile = "+5491123456789343",
                City = "TheoryCity",
                State = "TheoryState",
            });
        }
    }
}
