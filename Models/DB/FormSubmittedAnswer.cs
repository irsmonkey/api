using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class FormSubmittedAnswer
    {
        public int FormSubmittedAnswerId { get; set; }
        public int? FormSubmittedId { get; set; }
        public int? QuestionId { get; set; }
        public string Answer { get; set; }
        public int? SectionId { get; set; }
        public string ControlId { get; set; }

        public FormSubmitted FormSubmitted { get; set; }
        public FormQuestion Question { get; set; }
    }
}
