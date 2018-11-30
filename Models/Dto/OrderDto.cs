using System;

namespace IrsMonkeyApi.Models.Dto
{
    public class OrderDto
    {
        public int OrderStatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public float Discount { get; set; }
        public string DiscountType { get; set; }
        public string DiscountCode { get; set; }
        public Guid MemberId { get; set; }
        public float OrderTotal { get; set; }
        public int PaymentTypeID { get; set; }
        public string SubscriptionID { get; set; }
        public DateTime PaymentStartDate { get; set; }
    }
}