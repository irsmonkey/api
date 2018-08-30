using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class AmountType
    {
        public AmountType()
        {
            Item = new HashSet<Item>();
        }

        public int AmountTypeId { get; set; }
        public string AmountTypeName { get; set; }

        public ICollection<Item> Item { get; set; }
    }
}
