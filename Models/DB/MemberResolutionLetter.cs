using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class MemberResolutionLetter
    {
        public int MemberResolutionLetterId { get; set; }
        public int ResolutionLetterId { get; set; }
        public Guid MemberId { get; set; }
        public string AnswerParagraph1 { get; set; }
        public string AnswerParagraph2 { get; set; }
        public string AnswerParagraph3 { get; set; }
        public DateTime? DateAdded { get; set; }

        public Member Member { get; set; }
        public ResolutionLetter ResolutionLetter { get; set; }
    }
}
