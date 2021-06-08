using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Models;

namespace ClothingStore.Data
{
    public class ClothingStoreContext : DbContext
    {
        public ClothingStoreContext(DbContextOptions<ClothingStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Infrastructure.Persistence.Models.Order> Order { get; set; }

        public DbSet<Infrastructure.Persistence.Models.Category> Category { get; set; }

        public DbSet<Infrastructure.Persistence.Models.DeliveryCountry> DeliveryCountry { get; set; }

        public DbSet<Infrastructure.Persistence.Models.Manufacturer> Manufacturer { get; set; }

        public DbSet<Infrastructure.Persistence.Models.Member> Member { get; set; }

        public DbSet<Infrastructure.Persistence.Models.Product> Product { get; set; }

        public DbSet<Infrastructure.Persistence.Models.Role> Role { get; set; }

        public DbSet<Infrastructure.Persistence.Models.ProductsCategory> ProductsCategory { get; set; }

        public DbSet<Infrastructure.Persistence.Models.MembersProduct> MembersProduct { get; set; }
    }
}