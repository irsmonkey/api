using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Role
    {
        public Role()
        {
            MenuRole = new HashSet<MenuRole>();
            UserRole = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string RoleDescription { get; set; }

        public ICollection<MenuRole> MenuRole { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
