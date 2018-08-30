using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class TicketLog
    {
        public int TicketLogId { get; set; }
        public int TicketId { get; set; }
        public int OldTicketStatusId { get; set; }
        public int NewTicketStatusId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateStamp { get; set; }
        public int? EnteredByUserId { get; set; }
        public Guid? EnteredByMemberId { get; set; }

        public Member EnteredByMember { get; set; }
        public User EnteredByUser { get; set; }
        public TicketStatus NewTicketStatus { get; set; }
        public TicketStatus OldTicketStatus { get; set; }
        public Ticket Ticket { get; set; }
    }
}
