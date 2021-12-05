using Aalgro.ECommerce.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MOUGBF3\SQLEXPRESS;Initial Catalog=ECommerce;Integrated Security=True;");
        }
    }
}
