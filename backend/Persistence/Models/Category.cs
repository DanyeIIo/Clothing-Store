using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Persistence.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductsCategories = new HashSet<ProductsCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductsCategory> ProductsCategories { get; set; }
    }
}
