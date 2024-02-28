using API.Context;
using API.Controllers;
using API.Entities;
using API.Repository;
using API_XUnit.Mock.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_XUnit.Fixture
{
    public class ControllerFixture : IDisposable
    {
        private DatabaseContext testDbContextMock { get; set; }
        private CustomerRepository customerRepository { get; set; }
        public CustomerController customerController { get; private set; }

        public ControllerFixture()
        {
            #region Create mock/memory database
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "Customers");
            testDbContextMock = new DatabaseContext(optionsBuilder.Options);

            // mock data created by https://barisates.github.io/pretend
            testDbContextMock.Customers.AddRange(new CustomerModel[]
            {
                // for delete test
                new CustomerModel()
                {
                    Name = "Name Test",
                    DNI = "81544670",
                    Address = "Address test",
                    Email = "teste@gmail.com",
                    Mobile = "+5491123456789",
                    City = "TestCity",
                    State = "TesteState",
                },
                // for get test
                new CustomerModel()
                {
                    Name = "Name Test",
                    DNI = "81544670",
                    Address = "Address test",
                    Email = "teste@gmail.com",
                    Mobile = "+5491123456789",
                    City = "TestCity",
                    State = "TesteState",
                },
            });

            testDbContextMock.SaveChanges();

            #endregion

            // Create UserService with Memory Database
            customerRepository = new CustomerRepository(testDbContextMock);

            // Create Controller
            customerController = new CustomerController(customerRepository);

        }


        #region ImplementIDisposableCorrectly
        /** https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063?view=vs-2019 */
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~ControllerFixture()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                testDbContextMock.Dispose();
                testDbContextMock = null;

                customerRepository = null;

                customerController = null;
            }
        }
        #endregion
    }
}
