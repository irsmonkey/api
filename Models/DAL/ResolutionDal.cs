using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;
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
                    join formQuestion in _context.FormQuestion
                        on wizardStep.WizardStepId equals formQuestion.WizardStepId
                    join formQuestionAnswer in _context.FormQuestionAnswer
                        on formQuestion.FormQuestionId equals formQuestionAnswer.FormQuestionId into
                        formQuestionAnswerJoin
                    from formQuestionAnswer in formQuestionAnswerJoin.DefaultIfEmpty()
                    where form.FormTypeId == 2
                    select new
                    {
                        resolution.ResolutionId, resolution.Resolution1, form.FormId,
                        formDescription = form.Descripcion, form.FormName, form.FormTypeId, wizard.WizardId,
                        wizard.Header, wizard.Footer, wizardFormId = wizard.FormId,
                        wizardStep.WizardStepId, wizardStep.MotivationalMessage, wizardStep.FactsMessage,
                        wizardStep.Order, wizardStepHeader = wizardStep.Header,
                        wizardStepWizardId = wizardStep.WizardId, formQuestion.Cssclass,
                        questionOrder = formQuestion.Ordering,
                        formQuestion.ControlId, formQuestion.Image, formQuestion.Icon, formQuestion.Required,
                        formQuestion.HtmlControlId, formQuestion.HtmlControlName, formQuestion.FormQuestionId,
                        formQuestion.Label, questionWizardStep = formQuestion.WizardStepId,
                        formQuestion.FormControlTypeId,
                        formQuestion.TriggerFunction, answer = formQuestionAnswer.Answer ?? "",
                        answerIcon = formQuestionAnswer.Icon ?? "", answerCss = formQuestionAnswer.Cssclass ?? "",
                        answerId = (formQuestionAnswer.FormQuestionAnswerId == 0)
                            ? 0
                            : formQuestionAnswer.FormQuestionAnswerId,
                        answerQuestionId =
                            (formQuestionAnswer.FormQuestionId == 0)
                                ? 0
                                : formQuestionAnswer.FormQuestionId
                    }).ToList();

                var distinctResolutions =
                    resolutions.Select(x => new {x.ResolutionId, x.Resolution1, x.FormId}).Distinct();
                var distinctWizard = resolutions.Select(x => new {x.WizardId, x.wizardFormId, x.Header}).Distinct();
                var distinctWizardStep = resolutions.Select(x => new
                    {
                        x.WizardStepId, x.MotivationalMessage, x.FactsMessage, x.Order, x.wizardStepHeader,
                        x.wizardStepWizardId
                    })
                    .Distinct();
                var distinctFormQuestion = resolutions.Select(x => new
                {
                    x.questionOrder, x.Label, x.ControlId, x.Image, x.Required, x.Cssclass, x.Icon, x.HtmlControlId,
                    x.HtmlControlName, x.FormQuestionId, x.FormId, x.questionWizardStep, x.TriggerFunction,
                    x.FormControlTypeId
                }).Distinct();
                var distinctFormQuestionAnswer = resolutions
                    .Select(x => new {x.answerId, x.answerQuestionId, x.answer, x.answerIcon, x.answerCss}).Distinct();

                var formQuestionAnswerList = distinctFormQuestionAnswer.Select(formQuestionAnswer =>
                    new FormQuestionAnswerDto()
                    {
                        Answer = formQuestionAnswer.answer, css = formQuestionAnswer.answerCss,
                        FormQuestionAnswerId = formQuestionAnswer.answerId,
                        FormQuestionId = formQuestionAnswer.answerQuestionId, Icon = formQuestionAnswer.answerIcon
                    }).ToList();
                var formQuestionList = distinctFormQuestion.Select(formQuestion => new FormQuestionDto
                {
                    ControlId = formQuestion.ControlId, CssClass = formQuestion.Cssclass,
                    FormId = formQuestion.FormId,
                    FormQuestionId = formQuestion.FormQuestionId, HtmlControlId = formQuestion.HtmlControlId,
                    HtmlControlName = formQuestion.HtmlControlName, Ordering = formQuestion.questionOrder,
                    Icon = formQuestion.Icon, Image = formQuestion.Image, Label = formQuestion.Label,
                    WizardStepId = formQuestion.questionWizardStep, Function = formQuestion.TriggerFunction,
                    ControlType = formQuestion.FormControlTypeId,
                    Answers = formQuestionAnswerList.Where(
                    x => x.FormQuestionId == formQuestion.FormQuestionId
                    ).ToList()
                }).ToList();

                var wizardStepList = distinctWizardStep.Select(
                    wizardStep => new WizardStepDto
                    {
                        WizardStepId = wizardStep.WizardStepId, Order = wizardStep.Order,
                        Header = wizardStep.wizardStepHeader, MotivationalMessage = wizardStep.MotivationalMessage,
                        FactMessage = wizardStep.FactsMessage, WizardId = wizardStep.wizardStepWizardId,
                        Questions = formQuestionList.Where(x => x.WizardStepId == wizardStep.WizardStepId).ToList()
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

        [Route("GetUserResolution/{resolution}/{id}"), HttpGet]
        public List<FormSubmitted> GetAResolution(Guid id, int resolution)
        {
            try
            {
                var memberForms = _context.FormSubmitted
                    .Where(mf => mf.MemberId == id)
                    .Where(rl => rl.FormId == resolution)
                    .OrderByDescending(o => o.FormSubmittedId)
                    .Take(1)
                    .ToList();

                return memberForms.Any() ?  memberForms : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }   
}