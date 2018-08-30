using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class TicketType
    {
        public TicketType()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int TicketTypeId { get; set; }
        public string TicketTypeName { get; set; }
        public bool? Reserved { get; set; }

        public ICollection<Ticket> Ticket { get; set; }
    }
}
