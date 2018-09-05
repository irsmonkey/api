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
        public DateTime? DateCreated { get; set; }
        public int? WizarStepId { get; set; }

        public Form Form { get; set; }
        public Member Member { get; set; }
        public WizardStep WizarStep { get; set; }
        public ICollection<FormSubmittedAnswer> FormSubmittedAnswer { get; set; }
    }
}
