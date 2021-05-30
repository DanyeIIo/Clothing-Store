using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClothingStore.Models;

namespace ClothingStore.Data
{
    public class ClothingStoreContext : DbContext
    {
        public ClothingStoreContext (DbContextOptions<ClothingStoreContext> options)
            : base(options)
        {
        }

        public DbSet<ClothingStore.Models.Order> Order { get; set; }

        public DbSet<ClothingStore.Models.Category> Category { get; set; }

        public DbSet<ClothingStore.Models.DeliveryCountry> DeliveryCountry { get; set; }

        public DbSet<ClothingStore.Models.Manufacturer> Manufacturer { get; set; }

        public DbSet<ClothingStore.Models.Member> Member { get; set; }

        public DbSet<ClothingStore.Models.Product> Product { get; set; }

        public DbSet<ClothingStore.Models.Role> Role { get; set; }

        public DbSet<ClothingStore.Models.ProductsCategory> ProductsCategory { get; set; }

        public DbSet<ClothingStore.Models.MembersProduct> MembersProduct { get; set; }
    }
}
