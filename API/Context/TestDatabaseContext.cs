using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public partial class TestDatabaseContext : DbContext
    {
        public virtual DbSet<CustomerModel> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("SampleMemoryDatabase");
            }
        }
    }
}
