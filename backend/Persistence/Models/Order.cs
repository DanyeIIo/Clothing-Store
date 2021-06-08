using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Persistence.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int CountOfProducts { get; set; }
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Member Member { get; set; }
        public virtual Product Product { get; set; }
    }
}
