using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Item
    {
        public Item()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal? Price { get; set; }
        public string ItemNumber { get; set; }
        public bool? Recurring { get; set; }
        public bool? UpSell { get; set; }
        public bool? Waivable { get; set; }
        public int? AmountTypeId { get; set; }

        public AmountType AmountType { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
