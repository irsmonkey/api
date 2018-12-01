using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class OrderItem
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int OrderItemId { get; set; }

        public Item Item { get; set; }
        public Order Order { get; set; }
    }
}
