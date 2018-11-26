using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IrsMonkeyApi.Models.DB
{
    public partial class WizarStep
    {
        public WizarStep()
        {
            FormQuestion = new HashSet<FormQuestion>();
            FormSubmitted = new HashSet<FormSubmitted>();
        }

        [Key]
        public int WizardStepId { get; set; }
        public int WizardId { get; set; }
        public int Order { get; set; }
        public string Header { get; set; }
        public string MotivationalMessage { get; set; }
        public string FactsMessage { get; set; }
        public string Footer { get; set; }
        public int? FormId { get; set; }

        public Form Form { get; set; }
        public Wizard Wizard { get; set; }
        public ICollection<FormQuestion> FormQuestion { get; set; }
        public ICollection<FormSubmitted> FormSubmitted { get; set; }
    }
}
