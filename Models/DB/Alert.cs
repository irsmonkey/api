using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Alert
    {
        public int AlertId { get; set; }
        public string AlertName { get; set; }
        public string AlertDescription { get; set; }
        public string AlertLink { get; set; }
        public DateTime DateAdded { get; set; }
        public bool? Active { get; set; }
        public Guid MemberId { get; set; }
        public DateTime? AlertStartDate { get; set; }
        public DateTime? AlertEndDate { get; set; }
        public string RefId { get; set; }
        public int? AlertTypeId { get; set; }

        public AlertType AlertType { get; set; }
    }
}
