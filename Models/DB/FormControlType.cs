using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class FormControlType
    {
        public FormControlType()
        {
            FormQuestion = new HashSet<FormQuestion>();
        }

        public int FormControlTypeId { get; set; }
        public string FormControlTypeName { get; set; }

        public ICollection<FormQuestion> FormQuestion { get; set; }
    }
}
