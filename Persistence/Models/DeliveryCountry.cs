using System;
using System.Collections.Generic;

#nullable disable

namespace ClothingStore.Models
{
    public partial class DeliveryCountry
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? ManufacturerId { get; set; }
        public string CountryName { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Product Product { get; set; }
    }
}
