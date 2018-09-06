using System;
using System.Collections.Generic;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;

namespace IrsMonkeyApi.Models.DAL
{
    public class FormSubmittedDal: IFormSubmittedDal
    {
        private readonly IRSMonkeyContext _context;

        public FormSubmittedDal(IRSMonkeyContext context)
        {
            _context = context;
        }
        
        public FormSubmitted SaveForm(FormSubmittedDto formSubmittedDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var formSubmitted = new FormSubmitted()
                    {
                        FormId = formSubmittedDto.FormId,
                        MemberId = formSubmittedDto.MemberId,
                        WizarStepId = formSubmittedDto.WizardStepId
                    };
                    _context.FormSubmitted.Add(formSubmitted);
                    _context.SaveChanges();
                    foreach (var answer in formSubmittedDto.SubmittedAnswers)
                    {
                        answer.FormSubmittedId = formSubmitted.FormSubmittedId;
                        _context.FormSubmittedAnswer.Add(answer);
                        _context.SaveChanges();
                    }
                    
                    transaction.Commit();
                    return formSubmitted ?? null;
                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}