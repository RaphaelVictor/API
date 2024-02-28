using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<CustomerModel> Customers { get; set; }
    }
}
