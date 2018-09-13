using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class FormQuestionAnswer
    {
        public int FormQuestionAnswerId { get; set; }
        public int FormQuestionId { get; set; }
        public string Answer { get; set; }
        public string PdfcontrolId { get; set; }
        public string AssociatedPdfcontrolId { get; set; }
        public string Image { get; set; }
        public string Cssclass { get; set; }
        public string Icon { get; set; }
        public string Label { get; set; }
        public string HtmlControlId { get; set; }

        public FormQuestion FormQuestion { get; set; }
    }
}
