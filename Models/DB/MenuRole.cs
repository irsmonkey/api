using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class MenuRole
    {
        public int MenuRoleId { get; set; }
        public int MenuId { get; set; }
        public int RoleId { get; set; }

        public Menu Menu { get; set; }
        public Role Role { get; set; }
    }
}
