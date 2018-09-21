using System.Collections.Generic;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.Dto
{
    public class FormQuestionDto
    {
        public int? Ordering { get; set; }
        public string Label { get; set; }
        public string ControlId { get; set; }
        public string Image { get; set; }
        public bool? Required { get; set; }
        public string CssClass { get; set; }
        public string Icon { get; set; }
        public string HtmlControlId { get; set; }
        public string HtmlControlName { get; set; }
        public List<FormQuestionAnswerDto> Answers { get; set; }
        public int FormQuestionId { get; set; }
        public int FormId { get; set; }
        public int? WizardStepId { get; set; }
    }
}