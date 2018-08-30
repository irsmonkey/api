using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class MemberStatus
    {
        public MemberStatus()
        {
            Member = new HashSet<Member>();
        }

        public int MemberStatusId { get; set; }
        public string MemberStatusName { get; set; }

        public ICollection<Member> Member { get; set; }
    }
}
