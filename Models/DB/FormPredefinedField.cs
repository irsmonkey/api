using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class FormPredefinedField
    {
        public FormPredefinedField()
        {
            FormQuestion = new HashSet<FormQuestion>();
        }

        public int FormPredefinedFieldlId { get; set; }
        public string FormPredefinedFieldName { get; set; }

        public ICollection<FormQuestion> FormQuestion { get; set; }
    }
}
