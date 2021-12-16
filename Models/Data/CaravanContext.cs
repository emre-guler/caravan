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
        public DbSet<MarketPlace> MarketPlaces { get; set; }
        public DbSet<CustomerRole> CustomerRoles { get; set; }
        public DbSet<CustomerRoleCustomerMapping> CustomerRoleCustomerMappings { get; set; }
        public DbSet<CustomerMarketPlaceMapping> CustomerMarketPlaceMappings { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}