using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Member
    {
        public Member()
        {
            Folder = new HashSet<Folder>();
            FormSubmitted = new HashSet<FormSubmitted>();
            LogMemberAction = new HashSet<LogMemberAction>();
            MemberResolutionLetter = new HashSet<MemberResolutionLetter>();
            Order = new HashSet<Order>();
            PaymentLog = new HashSet<PaymentLog>();
            Ticket = new HashSet<Ticket>();
            TicketLog = new HashSet<TicketLog>();
        }

        public Guid MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int MembershipTypeId { get; set; }
        public string PasswordSalt { get; set; }
        public int MembershipNumber { get; set; }
        public string Ssn { get; set; }
        public DateTime SignUpDate { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessCity { get; set; }
        public string BusinessState { get; set; }
        public string BusinessZipCode { get; set; }
        public string Tin { get; set; }
        public bool IsFirstLogin { get; set; }
        public bool Deleted { get; set; }
        public int? SignUpTypeId { get; set; }
        public string SubId { get; set; }
        public int? MemberStatusId { get; set; }
        public string ProfileImage { get; set; }
        public long? SubscriptionId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public MemberStatus MemberStatus { get; set; }
        public MembershipType MembershipType { get; set; }
        public ICollection<Folder> Folder { get; set; }
        public ICollection<FormSubmitted> FormSubmitted { get; set; }
        public ICollection<LogMemberAction> LogMemberAction { get; set; }
        public ICollection<MemberResolutionLetter> MemberResolutionLetter { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<PaymentLog> PaymentLog { get; set; }
        public ICollection<Ticket> Ticket { get; set; }
        public ICollection<TicketLog> TicketLog { get; set; }
    }
}
