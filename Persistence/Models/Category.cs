using System;
using System.Collections.Generic;

#nullable disable

namespace ClothingStore.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductsCategories = new HashSet<ProductsCategory>();
        }
        public Category(string name)
        {
            ProductsCategories = new HashSet<ProductsCategory>();
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductsCategory> ProductsCategories { get; set; }
    }
}
