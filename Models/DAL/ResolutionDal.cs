using System;
using System.Collections.Generic;
using System.Linq;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace IrsMonkeyApi.Models.DAL
{
    public class ResolutionDal : IResolutionDal
    {
        private readonly IRSMonkeyContext _context;

        public ResolutionDal(IRSMonkeyContext context)
        {
            _context = context;
        }

        public IQueryable<ResolutionDto> GetAllResolutions()
        {
            try
            {
                var resolutions = (from resolution in _context.Resolution
                        join formResolution in _context.FormResolution
                            on resolution.ResolutionId equals formResolution.ResolutionId
                        join form in _context.Form
                            on formResolution.FormId equals form.FormId
                        join formQuestion in _context.FormQuestion on formResolution.FormId equals formQuestion.FormId into fq
                        select new ResolutionDto()
                        {
                            Resolution1 = resolution.Resolution1,
                            ResolutionId = resolution.ResolutionId,
                            FormId = form.FormId,
                            FormDescription = form.Descripcion,
                            FormName = form.FormName,
                            QuestionId = fq
                        }
                    );


                /*var resolutions = _context.Resolution
                    .Include(fr => fr.FormResolution)
                    .ThenInclude(f => f.Form)
                    .ThenInclude(q => q.FormQuestion)
                    .ThenInclude(ws => ws.WizardStepId)
                    .ThenInclude(qa => qa.FormQuestionAnswer)
                    .Where(r => r.IsDeleted == false)
                    .ToList();*/

                return resolutions;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Resolution GetAResolution()
        {
            throw new NotImplementedException();
        }
    }
}