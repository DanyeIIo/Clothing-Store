using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Persistence.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            DeliveryCountries = new HashSet<DeliveryCountry>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DeliveryCountry> DeliveryCountries { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
