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
                    join wizardStep in _context.WizardStep
                        on formQuestion.WizardStepId equals wizardStep.WizardStepId
                    where form.FormTypeId == 2
                    select new
                    {
                        resolution.ResolutionId, resolution.Resolution1, form.FormId, form.Descripcion, form.FormName,
                        wizard.WizardId, wizard.Header, wizard.Footer, formQuestion.FormQuestionId, formQuestion.Label,
                        wizardStep.WizardStepId, wizardStep.MotivationalMessage, wizardStep.FactsMessage
                        , formQuestion.Cssclass, wizardStep.Order, wizardStepHeader = wizardStep.Header, formQuestion.Ordering
                        , formQuestion.ControlId, formQuestion.Image, formQuestion.Icon, formQuestion.Required, formQuestion.HtmlControlId
                        , formQuestion.HtmlControlName, formQuestionAnswer.Answer, answerIcon = formQuestionAnswer.Icon
                        , answerCss = formQuestionAnswer.Cssclass, answerId = formQuestionAnswer.FormQuestionAnswerId
                    };

                var resolGrouped = resolutions.GroupBy(x => x.ResolutionId).Select(g => g.First());
                var wizardGrouped = resolutions.GroupBy(x => x.WizardId).Select(g => g.First());
                var wizardStepGrouped = resolutions.GroupBy(x => x.WizardStepId).Select(g => g.First());
                var questionGrouped = resolutions.GroupBy(x => x.WizardStepId).Select(g => g.First());
                var answerGrouped = resolutions.GroupBy(x => x.FormQuestionId).Select(g => g.First());

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

                foreach (var resultAnswer in answerGrouped)
                {
                    answerList.Add(new FormQuestionAnswerDto
                    {
                        Answer = resultAnswer.Answer,
                        FormQuestionId = resultAnswer.FormQuestionId,
                        FormQuestionAnswerId = resultAnswer.answerId,
                        css = resultAnswer.answerCss
                    });
                }
                
                foreach (var resultQuestion in questionGrouped)
                {
                    questionList.Add(new FormQuestionDto
                    {
                        CssClass = resultQuestion.Cssclass,
                        Label = resultQuestion.Label,
                        WizardStepId = resultQuestion.WizardStepId,
                        Ordering = resultQuestion.Order,
                        ControlId = resultQuestion.ControlId,
                        Image = resultQuestion.Image,
                        Icon = resultQuestion.Icon,
                        Required = resultQuestion.Required,
                        HtmlControlId = resultQuestion.HtmlControlId,
                        HtmlControlName = resultQuestion.HtmlControlName,
                        FormQuestionId = resultQuestion.FormQuestionId,
                        Answers = answerList.Where(x => x.FormQuestionId == resultQuestion.FormQuestionId).ToList()
                    });
                }

                foreach (var resultWizardStep in wizardStepGrouped)
                {
                        wizardStepList.Add(new WizardStepDto()
                        {
                            WizardId = resultWizardStep.WizardId,
                            WizardStepId = resultWizardStep.WizardStepId,
                            Order = resultWizardStep.Order,
                            Header = resultWizardStep.wizardStepHeader,
                            MotivationalMessage = resultWizardStep.MotivationalMessage,
                            FactMessage = resultWizardStep.FactsMessage,
                            FormQuestions = questionList.Where(x => x.WizardStepId == resultWizardStep.WizardStepId).ToList()
                        });
                }
                
                foreach (var resultWizard in wizardGrouped)
                {
                    wizardList.Add(new WizardDto()
                    {
                        FormId = resultWizard.FormId,
                        Header = resultWizard.Header,
                        WizardId = resultWizard.WizardId,
                        Steps = wizardStepList.Where(x=>x.WizardId == resultWizard.WizardId).ToList()
                    });
                }

                foreach (var resultWizard in result)
                {
                    resultWizard.Wizards = wizardList.Where(x => x.FormId == resultWizard.FormId).ToList();
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