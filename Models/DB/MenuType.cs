using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class MenuType
    {
        public MenuType()
        {
            Menu = new HashSet<Menu>();
        }

        public int MenuTypeId { get; set; }
        public string MenuTypeDescription { get; set; }

        public ICollection<Menu> Menu { get; set; }
    }
}
