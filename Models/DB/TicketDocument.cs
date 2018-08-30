using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class TicketDocument
    {
        public int TicketDocumentId { get; set; }
        public int TicketId { get; set; }
        public int FileId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
