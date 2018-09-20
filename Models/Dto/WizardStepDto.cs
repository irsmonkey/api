using System.Collections.Generic;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.Dto
{
    public class WizardStepDto
    {
        public int? WizardStepId { get; set; }
        public int? WizardId { get; set; }
        public int Order { get; set; }
        public string Header { get; set; }
        public string MotivationalMessage { get; set; }
        public string FactMessage { get; set; }
        public List<FormQuestionDto> FormQuestions { get; set; }
    }
}