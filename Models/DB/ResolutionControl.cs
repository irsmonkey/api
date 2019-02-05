using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class ResolutionControl
    {
        public Guid ResolutionControlId { get; set; }
        public int? FormResolutionId { get; set; }
        public int? FormQuestionId { get; set; }
        public int? FormControlType { get; set; }
        public string FormControl { get; set; }
        public string Label { get; set; }

        public FormControlType FormControlTypeNavigation { get; set; }
    }
}
