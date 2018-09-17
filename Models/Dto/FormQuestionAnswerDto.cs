namespace IrsMonkeyApi.Models.Dto
{
    public class FormQuestionAnswerDto
    {
        public int FormQuestionAnswerId { get; set; }
        public int FormQuestionId { get; set; }
        public string Answer { get; set; }
        public string Icon { get; set; }
    }
}