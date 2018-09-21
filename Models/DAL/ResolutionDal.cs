using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                var resolutions = (from resolution in _context.Resolution
                    join formResolution in _context.FormResolution
                        on resolution.ResolutionId equals formResolution.ResolutionId
                    join form in _context.Form
                        on formResolution.FormId equals form.FormId
                    join wizard in _context.Wizard
                        on form.FormId equals wizard.FormId
                    join wizardStep in _context.WizardStep
                        on wizard.WizardId equals wizardStep.WizardId
//                    join formQuestion in _context.FormQuestion
//                        on form.FormId equals formQuestion.FormId
//                    join formQuestionAnswer in _context.FormQuestionAnswer
//                        on formQuestion.FormQuestionId equals formQuestionAnswer.FormQuestionId
                    /*join wizardStep in _context.WizardStep
                        on formQuestion.WizardStepId equals wizardStep.WizardStepId*/
                    where form.FormTypeId == 2
                    select new
                    {
                        resolution.ResolutionId, resolution.Resolution1, form.FormId,
                        formDescription = form.Descripcion, form.FormName, form.FormTypeId, wizard.WizardId,
                        wizard.Header, wizard.Footer, wizardFormId = wizard.FormId
//                        , formQuestion.FormQuestionId
//                        , formQuestion.Label
                        ,
                        wizardStep.WizardStepId, wizardStep.MotivationalMessage, wizardStep.FactsMessage,
                        wizardStep.Order, wizardStepHeader = wizardStep.Header, wizardStepWizardId = wizardStep.WizardId
//                        , formQuestion.Cssclass
//                        , formQuestion.Ordering
//                        , formQuestion.ControlId
//                        , formQuestion.Image
//                        , formQuestion.Icon
//                        , formQuestion.Required
//                        , formQuestion.HtmlControlId
//                        , formQuestion.HtmlControlName
                        /*, formQuestionAnswer.Answer
                        , answerIcon = formQuestionAnswer.Icon
                        , answerCss = formQuestionAnswer.Cssclass
                        , answerId = formQuestionAnswer.FormQuestionAnswerId*/
                    }).ToList();

                var distinctResolutions =
                    resolutions.Select(x => new {x.ResolutionId, x.Resolution1, x.FormId}).Distinct();
                var distinctWizard = resolutions.Select(x => new {x.WizardId, x.wizardFormId, x.Header}).Distinct();
                var distinctWizardStep = resolutions.Select(x => new
                    {
                        x.WizardStepId, x.MotivationalMessage, x.FactsMessage, x.Order, x.wizardStepHeader, x.wizardStepWizardId
                    })
                    .Distinct();
                var distinctForm = resolutions.Select(x => new {x.FormId, x.formDescription, x.FormName}).Distinct();

                var wizardStepList = distinctWizardStep.Select(
                    wizardStep => new WizardStepDto()
                    {
                        WizardStepId = wizardStep.WizardStepId, Order = wizardStep.Order,
                        Header = wizardStep.wizardStepHeader, MotivationalMessage = wizardStep.MotivationalMessage,
                        FactMessage = wizardStep.FactsMessage, WizardId = wizardStep.wizardStepWizardId
                    }).ToList();
                var wizardList = distinctWizard.Select(
                    wizard => new WizardDto
                    {
                        FormId = wizard.wizardFormId, Header = wizard.Header, WizardId = wizard.WizardId,
                        Steps = wizardStepList.Where(x => x.WizardId == wizard.WizardId).ToList()
                    }).ToList();
                var resolutionsList = distinctResolutions.Select(
                    resolution => new ResolutionDto
                    {
                        Resolution1 = resolution.Resolution1, ResolutionId = resolution.ResolutionId,
                        Wizards = wizardList.Where(x => x.FormId == resolution.FormId).ToList()
                    }).ToList();


                return resolutionsList.ToList();
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