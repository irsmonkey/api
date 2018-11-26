using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Form
    {
        public Form()
        {
            FormQuestion = new HashSet<FormQuestion>();
            FormResolution = new HashSet<FormResolution>();
            FormSubmitted = new HashSet<FormSubmitted>();
            Wizard = new HashSet<Wizard>();
            WizardStep = new HashSet<WizarStep>();
        }

        public int FormId { get; set; }
        public string FormCode { get; set; }
        public string FormName { get; set; }
        public DateTime? RevDate { get; set; }
        public string CatalogNumber { get; set; }
        public int? NumberSections { get; set; }
        public int? TotalNumberControls { get; set; }
        public string Url { get; set; }
        public string Pdffile { get; set; }
        public string Descripcion { get; set; }
        public int? FormTypeId { get; set; }
        public string MotivationalMessage { get; set; }
        public string FactMessage { get; set; }

        public FormType FormType { get; set; }
        public ICollection<FormQuestion> FormQuestion { get; set; }
        public ICollection<FormResolution> FormResolution { get; set; }
        public ICollection<FormSubmitted> FormSubmitted { get; set; }
        public ICollection<Wizard> Wizard { get; set; }
        public ICollection<WizarStep> WizardStep { get; set; }
    }
}
