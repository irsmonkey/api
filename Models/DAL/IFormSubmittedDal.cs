using System;
using System.Collections.Generic;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IFormSubmittedDal
    {
        FormSubmittedDto SaveForm(FormSubmittedDto formSubmittedDto);
        List<FormSubmitted> getForm(Guid memberId);
    }
}