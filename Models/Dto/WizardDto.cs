using System.Collections.Generic;

namespace IrsMonkeyApi.Models.Dto
{
    public class WizardDto
    {
        public int WizardId { get; set; }
        public int FormId { get; set; }
        public string Header { get; set; }
        public List<WizardStepDto> Steps { get; set; }
    }
}    