using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class ResolutionLetter
    {
        public ResolutionLetter()
        {
            MemberResolutionLetter = new HashSet<MemberResolutionLetter>();
        }

        public int ResolutionLetterId { get; set; }
        public int ResolutionId { get; set; }
        public string TextTemplate { get; set; }

        public Resolution Resolution { get; set; }
        public ICollection<MemberResolutionLetter> MemberResolutionLetter { get; set; }
    }
}
