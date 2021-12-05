using Aalgro.ECommerce.DataAccess;
using Aalgro.ECommerce.Domains;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ECommerceDbContext : DbContext, IDbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbContext GetDbContext()
        {
            return this;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MOUGBF3\SQLEXPRESS;Initial Catalog=ECommerce;Integrated Security=True;");
        }
    }
}
