using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Microsoft.EntityFrameworkCore.Internal;
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
                var formsList = new List<FormDto>();
                var wizardList = new List<WizardDto>();
                var questionList = new List<FormQuestionDto>();
                var wizardStepList = new List<WizardStepDto>();
                var answerList = new List<FormQuestionAnswerDto>();

                var resolutions = from resolution in _context.Resolution
                    join formResolution in _context.FormResolution
                        on resolution.ResolutionId equals formResolution.ResolutionId
                    join form in _context.Form
                        on formResolution.FormId equals form.FormId
                    join wizard in _context.Wizard
                        on form.FormId equals wizard.FormId
                    join formQuestion in _context.FormQuestion
                        on form.FormId equals formQuestion.FormId
                    join formQuestionAnswer in _context.FormQuestionAnswer
                        on formQuestion.FormQuestionId equals formQuestionAnswer.FormQuestionId
                    /*join wizardStep in _context.WizardStep
                        on formQuestion.WizardStepId equals wizardStep.WizardStepId*/
                    where form.FormTypeId == 2
                    select new
                    {
                        resolution.ResolutionId
                        , resolution.Resolution1
                        , form.FormId
                        , form.Descripcion
                        , form.FormName
                        , form.FormTypeId
                        , wizard.WizardId
                        , wizard.Header
                        , wizard.Footer
                        , formQuestion.FormQuestionId
                        , formQuestion.Label
                        /*, wizardStep.WizardStepId
                        , wizardStep.MotivationalMessage
                        , wizardStep.FactsMessage
                        , wizardStep.Order
                        , wizardStepHeader = wizardStep.Header*/
                        , formQuestion.Cssclass
                        , formQuestion.Ordering
                        , formQuestion.ControlId
                        , formQuestion.Image
                        , formQuestion.Icon
                        , formQuestion.Required
                        , formQuestion.HtmlControlId
                        , formQuestion.HtmlControlName
                        /*, formQuestionAnswer.Answer
                        , answerIcon = formQuestionAnswer.Icon
                        , answerCss = formQuestionAnswer.Cssclass
                        , answerId = formQuestionAnswer.FormQuestionAnswerId*/
                    };

                var resolGrouped = resolutions.GroupBy(x => x.ResolutionId).Select(g => g.First());
                var formsGrouped = resolutions.GroupBy(x => x.FormId).Select(g => g.First());
                var wizardGrouped = resolutions.GroupBy(x => x.WizardId).Select(g => g.First());

                foreach (var regrouped in resolGrouped)
                {
                    result.Add(new ResolutionDto()
                    {
                        ResolutionId = regrouped.ResolutionId,
                        Resolution1 = regrouped.Resolution1,
                        FormId = regrouped.FormId,
                        FormDescription = regrouped.Descripcion,
                        FormName = regrouped.FormName
                    });
                }

                
                foreach (var resultForms in formsGrouped)
                {
                    formsList.Add(new FormDto()
                    {
                        FormId = resultForms.FormId,
                        FormName = resultForms.FormName,
                        Description = resultForms.Descripcion,
                        FormTypeId = resultForms.FormTypeId,
                        Questions = resolutions.Where(x => x.FormId == resultForms.FormId).Select(q => new FormQuestionDto()
                        {
                            CssClass = q.Cssclass,
                            Label = q.Label,
                            /*WizardStepId = resultQuestion.WizardStepId,
                            Ordering = resultQuestion.Order,*/
                            ControlId = q.ControlId,
                            Image = q.Image,
                            Icon = q.Icon,
                            Required = q.Required,
                            HtmlControlId = q.HtmlControlId,
                            HtmlControlName = q.HtmlControlName,
                            FormQuestionId = q.FormQuestionId,
                            FormId = q.FormId
                        }).ToList()
                    });
                }


                foreach (var formWizard in result)
                {
                    formWizard.Forms = formsList.Where(x => x.FormId == formWizard.FormId).ToList();
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