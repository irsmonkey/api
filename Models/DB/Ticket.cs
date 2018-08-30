using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Ticket
    {
        public Ticket()
        {
            TicketLog = new HashSet<TicketLog>();
        }

        public int TicketId { get; set; }
        public int TicketTypeId { get; set; }
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateClosed { get; set; }
        public Guid MemberId { get; set; }
        public int MembershipTypeId { get; set; }
        public DateTime? DateAssigned { get; set; }
        public int? TicketStatusId { get; set; }
        public int? AssignedTo { get; set; }
        public int? AssignedBy { get; set; }

        public User AssignedByNavigation { get; set; }
        public User AssignedToNavigation { get; set; }
        public Member Member { get; set; }
        public MembershipType MembershipType { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public TicketType TicketType { get; set; }
        public ICollection<TicketLog> TicketLog { get; set; }
    }
}
