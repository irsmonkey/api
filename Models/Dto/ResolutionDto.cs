using System.Collections.Generic;
using IrsMonkeyApi.Models.DB;
using Microsoft.CodeAnalysis;

namespace IrsMonkeyApi.Models.Dto
{
    public class ResolutionDto
    {
        public int ResolutionId { get; set; }
        public string Resolution1 { get; set; }
        public int FormId { get; set; }
        public string FormDescription { get; set; }
        public string FormName { get; set; }
        public List<WizardDto> Wizards { get; set; }
        public List<FormDto> Forms { get; set; }
    }
}    