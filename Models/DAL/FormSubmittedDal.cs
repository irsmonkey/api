using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace IrsMonkeyApi.Models.DAL
{
    public class FormSubmittedDal: IFormSubmittedDal
    {
        private readonly IRSMonkeyContext _context;
        private readonly IMapper _mapper;

        public FormSubmittedDal(IRSMonkeyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public FormSubmittedDto SaveForm(FormSubmittedDto formSubmittedDto)
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

                    var formSaved = _mapper.Map<FormSubmittedDto>(formSubmitted);
                    return formSaved ?? null;
                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<FormSubmitted> getForm(Guid memberId)
        {
            try
            {
                var memberForms = _context.FormSubmitted
                    .Where(mf => mf.MemberId == memberId)
                    .Include(sa => sa.FormSubmittedAnswer)
                    .ToList();

                return memberForms.Any() ?  memberForms : null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}