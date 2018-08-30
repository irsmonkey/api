using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Resolution
    {
        public Resolution()
        {
            FormResolution = new HashSet<FormResolution>();
            ResolutionLetter = new HashSet<ResolutionLetter>();
            Wizard = new HashSet<Wizard>();
        }

        public int ResolutionId { get; set; }
        public string Resolution1 { get; set; }
        public bool? CollectionIssue { get; set; }
        public int? TaxpediaPageId { get; set; }
        public int? AppealsTaxpediaPageId { get; set; }

        public ICollection<FormResolution> FormResolution { get; set; }
        public ICollection<ResolutionLetter> ResolutionLetter { get; set; }
        public ICollection<Wizard> Wizard { get; set; }
    }
}
