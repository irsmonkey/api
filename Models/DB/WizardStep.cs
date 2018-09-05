using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class WizardStep
    {
        public WizardStep()
        {
            FormQuestion = new HashSet<FormQuestion>();
            FormSubmitted = new HashSet<FormSubmitted>();
        }

        public int WizardStepId { get; set; }
        public int WizardId { get; set; }
        public int Order { get; set; }
        public string Header { get; set; }
        public string MotivationalMessage { get; set; }
        public string FactsMessage { get; set; }
        public string Footer { get; set; }

        public Wizard Wizard { get; set; }
        public ICollection<FormQuestion> FormQuestion { get; set; }
        public ICollection<FormSubmitted> FormSubmitted { get; set; }
    }
}
