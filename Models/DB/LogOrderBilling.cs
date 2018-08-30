using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class LogOrderBilling
    {
        public int LogOrderBillingId { get; set; }
        public long SubscriptionId { get; set; }
        public string Messages { get; set; }
        public string MessageCodes { get; set; }
        public DateTime DateCreated { get; set; }
        public string IpHost { get; set; }
        public bool Result { get; set; }
        public decimal? Amount { get; set; }
        public int? OrderId { get; set; }

        public Order Order { get; set; }
    }
}
