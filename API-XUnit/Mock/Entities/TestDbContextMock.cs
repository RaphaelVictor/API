using API.Context;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_XUnit.Mock.Entities
{
    public partial class TestDbContextMock : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /**
             * At this stage, a copy of the actual database is created as a memory database.
             * You do not need to create a separate test database.
             */
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }
        }
        public DbSet<CustomerModel> Customers { get; set; }
    }
}
