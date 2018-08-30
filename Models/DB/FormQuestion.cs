using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class FormQuestion
    {
        public FormQuestion()
        {
            FormQuestionAnswer = new HashSet<FormQuestionAnswer>();
            FormSubmittedAnswer = new HashSet<FormSubmittedAnswer>();
        }

        public int FormQuestionId { get; set; }
        public int? FormId { get; set; }
        public int? FormSectionId { get; set; }
        public int? Ordering { get; set; }
        public string Label { get; set; }
        public string ControlId { get; set; }
        public bool? AnswerEncrypted { get; set; }
        public int? FormControlTypeId { get; set; }
        public string Tip { get; set; }
        public string PdfcontrolId { get; set; }
        public int? FormPredefinedFieldId { get; set; }
        public decimal? PdfposX { get; set; }
        public decimal? PdfposY { get; set; }
        public int? PdffontSize { get; set; }
        public string PdffontName { get; set; }
        public int? PdfpageNumber { get; set; }
        public string Image { get; set; }
        public bool? Required { get; set; }
        public int? WizardStepId { get; set; }
        public string Cssclass { get; set; }
        public bool? GroupAsOther { get; set; }
        public string Icon { get; set; }

        public Form Form { get; set; }
        public FormControlType FormControlType { get; set; }
        public FormPredefinedField FormPredefinedField { get; set; }
        public WizardStep WizardStep { get; set; }
        public ICollection<FormQuestionAnswer> FormQuestionAnswer { get; set; }
        public ICollection<FormSubmittedAnswer> FormSubmittedAnswer { get; set; }
    }
}
