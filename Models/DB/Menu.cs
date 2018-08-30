using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Menu
    {
        public Menu()
        {
            MenuRole = new HashSet<MenuRole>();
        }

        public int MenuId { get; set; }
        public string MenuDescription { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public int? ParentMenuId { get; set; }
        public string Icon { get; set; }
        public bool? Visible { get; set; }
        public int? MenuTypeId { get; set; }

        public MenuType MenuType { get; set; }
        public ICollection<MenuRole> MenuRole { get; set; }
    }
}
