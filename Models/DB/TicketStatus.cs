using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class TicketStatus
    {
        public TicketStatus()
        {
            Ticket = new HashSet<Ticket>();
            TicketLogNewTicketStatus = new HashSet<TicketLog>();
            TicketLogOldTicketStatus = new HashSet<TicketLog>();
        }

        public int TicketStatusId { get; set; }
        public string TicketStatusName { get; set; }

        public ICollection<Ticket> Ticket { get; set; }
        public ICollection<TicketLog> TicketLogNewTicketStatus { get; set; }
        public ICollection<TicketLog> TicketLogOldTicketStatus { get; set; }
    }
}
