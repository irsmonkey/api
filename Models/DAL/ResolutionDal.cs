using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace IrsMonkeyApi.Models.DAL
{
    public class ResolutionDal : IResolutionDal
    {
        private readonly IRSMonkeyContext _context;
        private readonly IMapper _mapper;

        public ResolutionDal(IRSMonkeyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<ResolutionDto> GetAllResolutions()
        {
            try
            {

                var resolutions = _context.Resolution.FromSql("select " +
                                                              "r.Resolution" +
                                                              ", f.FormID" +
                                                              ", f.FormName" +
                                                              ", Q2.Label" +
                                                              ", Q2.AnswerEncrypted" +
                                                              ", q2.CSSClass" +
                                                              ", q2.Icon" +
                                                              ", q2.htmlControlId" +
                                                              ", q2.htmlControlName" +
                                                              ", Answer.CSSClass" +
                                                              ", Answer.Answer" +
                                                              ", Answer.Icon" +
                                                              ", s2.WizardStepID" +
                                                              ", s2.Header" +
                                                              ", s2.MotivationalMessage" +
                                                              ", s2.FactsMessage" +
                                                              ", w.WizardID" +
                                                              "from Resolution r " +
                                                              "inner join FormResolution FR on r.ResolutionID = FR.ResolutionID " +
                                                              "inner join Form F on FR.FormID = F.FormID " +
                                                              "inner join FormQuestion Q2 on F.FormID = Q2.FormID " +
                                                              "left join FormQuestionAnswer Answer on Q2.FormQuestionID = Answer.FormQuestionID " +
                                                              "inner join WizardStep S2 on Q2.WizardStepID = S2.WizardStepID " +
                                                              "inner Join Wizard W on S2.WizardID = W.WizardID " +
                                                              "order by F.FormID, s2.WizardStepID")
                    .Select( r =>
                    new ResolutionDto()
                    {
                        Resolution1 = r.Resolution1,
                        ResolutionId = r.ResolutionId,
                    }
                    );
                /*var questionaries = new List<ResolutionDto>();
                var resolutions = (from resolution in _context.Resolution
                    join formResolution in _context.FormResolution
                        on resolution.ResolutionId equals formResolution.ResolutionId
                    join form in _context.Form
                        on formResolution.FormId equals form.FormId
                    where form.FormTypeId == 2
                    select new ResolutionDto()
                    {
                        Resolution1 = resolution.Resolution1,
                        ResolutionId = resolution.ResolutionId,
                        FormId = form.FormId,
                        FormDescription = form.Descripcion,
                        FormName = form.FormName
                    });

                foreach (var resol in resolutions)
                {
                    questionaries.Add(resol);
                    var questions =
                        from quest in _context.FormQuestion.Where(x => x.FormId == resol.FormId).Select(s => s.FormId);

                }*/

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