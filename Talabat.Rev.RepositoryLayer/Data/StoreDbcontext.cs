using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;
using Talabat.Rev.RepositoryLayer.Data.Configrations;

namespace Talabat.Rev.RepositoryLayer.Data
{
    public class StoreDbcontext : DbContext
    {
        public StoreDbcontext(DbContextOptions<StoreDbcontext> options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        public DbSet<WishlistItem> WishlistItems { get; set; }


    }
}
