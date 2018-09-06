using System.Collections.Generic;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IFormSubmittedDal
    {
        FormSubmitted SaveForm(FormSubmittedDto formSubmittedDto);
    }
}