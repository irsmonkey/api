using System.Collections.Generic;

namespace IrsMonkeyApi.Models.Dto
{
    public class FormDto
    {
        public int FormId { get; set; }
        public string FormName { get; set; }
        public string Description { get; set; }
        public int? FormTypeId { get; set; }
        public string MotivationalMessage { get; set; }
        public string FactMessage { get; set; }
        public List<FormQuestionDto> Questions { get; set; }
    }
}