using System;
using System.Collections.Generic;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.Dto
{
    public class FormSubmittedDto
    {
        public int FormId { get; set; }
        public Guid MemberId { get; set; }
        public int WizardStepId { get; set; }
        public List<FormSubmittedAnswer> SubmittedAnswers { get; set; }
    }
}