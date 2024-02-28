using API.Context;
using API.Entities;
using API.Repository;
using Microsoft.EntityFrameworkCore;

namespace API.Utils
{
    public class FakeDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                // Look for any points of interest already in database
                if (context.Customers.Any())
                {
                    return; // Database has been seeded
                }

                var repo = new CustomerRepository(context);

                repo.Add(new CustomerModel()
                {
                    Name = "Name Test",
                    DNI = "81544672",
                    Address = "Address test2",
                    Email = "test@gmail.com",
                    Mobile = "+5491123456789",
                    City = "TestCity",
                    State = "TesteState"
                });

                repo.Add(new CustomerModel()
                {
                    Name = "Name Test2",
                    DNI = "81544670",
                    Address = "Address test2",
                    Email = "test@hotmail.com",
                    Mobile = "+5491123456789",
                    City = "TestCity2",
                    State = "TesteState2"
                });

            }
        }
    }
}
