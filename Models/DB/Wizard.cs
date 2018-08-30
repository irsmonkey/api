using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Wizard
    {
        public Wizard()
        {
            WizardStep = new HashSet<WizardStep>();
        }

        public int WizardId { get; set; }
        public int? FormId { get; set; }
        public int? ResolutionId { get; set; }
        public string Header { get; set; }
        public string MotivationalMessage { get; set; }
        public string FactsMessage { get; set; }
        public string Footer { get; set; }
        public int? ParentWizardId { get; set; }

        public Form Form { get; set; }
        public Resolution Resolution { get; set; }
        public ICollection<WizardStep> WizardStep { get; set; }
    }
}
