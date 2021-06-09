using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Persistence.Models
{
    public partial class Product
    {
        public Product()
        {
            DeliveryCountries = new HashSet<DeliveryCountry>();
            MembersProducts = new HashSet<MembersProduct>();
            Orders = new HashSet<Order>();
            Categories = new HashSet<Category>();
            //ProductsCategories = new HashSet<ProductsCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public DateTime ExhibitionDate { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
        public string Model { get; set; }

        public ICollection<Category> Categories { get; set; }
        public virtual ICollection<DeliveryCountry> DeliveryCountries { get; set; }
        public virtual ICollection<MembersProduct> MembersProducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        //public virtual ICollection<ProductsCategory> ProductsCategories { get; set; }
    }
}
