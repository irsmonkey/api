using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class User
    {
        public User()
        {
            LogUserAction = new HashSet<LogUserAction>();
            TicketAssignedByNavigation = new HashSet<Ticket>();
            TicketAssignedToNavigation = new HashSet<Ticket>();
            TicketLog = new HashSet<TicketLog>();
            UserRole = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? MemberId { get; set; }
        public bool? IsFirstLogin { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<LogUserAction> LogUserAction { get; set; }
        public ICollection<Ticket> TicketAssignedByNavigation { get; set; }
        public ICollection<Ticket> TicketAssignedToNavigation { get; set; }
        public ICollection<TicketLog> TicketLog { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
