using System;
using System.Collections.Generic;

#nullable disable

namespace ClothingStore.Models
{
    public partial class Member
    {
        public Member()
        {
            MembersProducts = new HashSet<MembersProduct>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<MembersProduct> MembersProducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
