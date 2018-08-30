using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class MembershipType
    {
        public MembershipType()
        {
            Member = new HashSet<Member>();
            Ticket = new HashSet<Ticket>();
        }

        public int MembershipTypeId { get; set; }
        public string MembershipTypeName { get; set; }

        public ICollection<Member> Member { get; set; }
        public ICollection<Ticket> Ticket { get; set; }
    }
}
