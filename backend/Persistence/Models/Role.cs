using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Persistence.Models
{
    public partial class Role
    {
        public Role()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string RoleType { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
