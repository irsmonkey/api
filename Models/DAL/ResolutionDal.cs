using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace IrsMonkeyApi.Models.DAL
{
    public class ResolutionDal : IResolutionDal
    {
        private readonly IRSMonkeyContext _context;

        public ResolutionDal(IRSMonkeyContext context)
        {
            _context = context;
        }

        public List<ResolutionDto> GetAllResolutions()
        {
            try
            {
                var result = new List<ResolutionDto>();
                var wizardList = new List<WizardDto>();
                
                var resolutions = from resolution in _context.Resolution
                    join formResolution in _context.FormResolution
                        on resolution.ResolutionId equals formResolution.ResolutionId
                    join form in _context.Form
                        on formResolution.FormId equals form.FormId
                    join wizard in _context.Wizard
                        on form.FormId equals wizard.FormId
                    join formQuestion in _context.FormQuestion
                        on form.FormId equals formQuestion.FormId
                    join wizardStep in _context.WizardStep
                        on formQuestion.WizardStepId equals wizardStep.WizardStepId
                    where form.FormTypeId == 2
                    select new { resolution.ResolutionId, resolution.Resolution1, form.FormId, form.Descripcion, wizard.WizardId, formQuestion.FormQuestionId, formQuestion.Label, wizardStep.WizardStepId, wizardStep.MotivationalMessage, wizardStep.FactsMessage};

                
               
                
                foreach (var q in resolutions)
                {
                    

                    wizardList.AddRange(
                        q.resolution.Wizard
                            .Select(w => new WizardDto
                            {
                                FormId = q.form.FormId, Header = w.Header, WizardId = w.WizardId
                            }).Where(re => re.FormId == q.form.FormId));

                    result.Add(new ResolutionDto
                    {
                        Resolution1 = q.resolution.Resolution1,
                        ResolutionId = q.resolution.ResolutionId,
                        FormDescription = q.form.Descripcion,
                        FormId = q.form.FormId,
                        FormName = q.form.FormName,
                        Wizards = wizardList
                    });

                    
                    
                }





                return result.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Resolution GetAResolution()
        {
            throw new NotImplementedException();
        }
    }
}