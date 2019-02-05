using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class FormControlType
    {
        public FormControlType()
        {
            FormQuestion = new HashSet<FormQuestion>();
            ResolutionControl = new HashSet<ResolutionControl>();
        }

        public int FormControlTypeId { get; set; }
        public string FormControlTypeName { get; set; }

        public ICollection<FormQuestion> FormQuestion { get; set; }
        public ICollection<ResolutionControl> ResolutionControl { get; set; }
    }
}
