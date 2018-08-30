using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class FormSubmitted
    {
        public FormSubmitted()
        {
            FormSubmittedAnswer = new HashSet<FormSubmittedAnswer>();
        }

        public int FormSubmittedId { get; set; }
        public int? FormId { get; set; }
        public Guid? MemberId { get; set; }
        public string Ip { get; set; }
        public string UserAgentString { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? MembershipTypeId { get; set; }

        public Form Form { get; set; }
        public Member Member { get; set; }
        public ICollection<FormSubmittedAnswer> FormSubmittedAnswer { get; set; }
    }
}
