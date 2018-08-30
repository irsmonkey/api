using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Order
    {
        public Order()
        {
            LogOrderBilling = new HashSet<LogOrderBilling>();
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public int? OrderStatusId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Discount { get; set; }
        public string DiscountType { get; set; }
        public string DiscountCode { get; set; }
        public Guid? MemberId { get; set; }
        public decimal? OrderTotal { get; set; }
        public int? PaymentTypeId { get; set; }
        public string SubscriptionId { get; set; }
        public DateTime? PaymentStartDate { get; set; }

        public Member Member { get; set; }
        public PaymentType PaymentType { get; set; }
        public ICollection<LogOrderBilling> LogOrderBilling { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
