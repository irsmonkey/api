using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Order = new HashSet<Order>();
        }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
