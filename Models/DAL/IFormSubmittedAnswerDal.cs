using System.Collections.Generic;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IFormSubmittedAnswerDal
    {
        bool SaveAnswers(List<FormSubmittedAnswer> answers, FormSubmitted form);
        List<FormSubmittedAnswer> GetAnswers(int formId);
    }
}