using Caravan.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caravan.Data
{
    public class CaravanContext : DbContext
    {
        public CaravanContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

        // Entities here.
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSupplierAddress> customerSuppliersAddresses { get; set;}
    }
}