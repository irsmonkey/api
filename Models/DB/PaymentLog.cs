using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class PaymentLog
    {
        public int PaymentLogId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public DateTime? DateStamp { get; set; }
        public string Description { get; set; }
        public int? SubscriptionId { get; set; }
        public Guid? MemberId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string TransactionStatus { get; set; }
        public bool? Approved { get; set; }

        public Member Member { get; set; }
    }
}
