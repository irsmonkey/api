using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Remotion.Linq.Clauses;

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

        public List<ResolutionDto> GetAllResolutions()
        {
            try
            {
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
                        FormName = form.FormName,
                    }).ToList();

                foreach (var resolutionItem in resolutions)
                {
                    var wizardStep = (from wizardStepData in _context.WizardStep
                            where wizardStepData.FormId == resolutionItem.FormId
                            select new WizardStepDto()
                            {
                                WizardStepId = wizardStepData.WizardStepId,
                                WizardId = wizardStepData.WizardId,
                                Order = wizardStepData.Order,
                                Header = wizardStepData.Header,
                                MotivationalMessage = wizardStepData.MotivationalMessage,
                                FactMessage = wizardStepData.FactsMessage
                            }
                        ).ToList();
                    
                    foreach (var wzrstp in wizardStep)
                    {
                        var formQuestion = (from formQuestionData in _context.FormQuestion
                            where formQuestionData.FormId == resolutionItem.FormId 
                                  && formQuestionData.WizardStepId == wzrstp.WizardStepId
                            orderby formQuestionData.WizardStepId, formQuestionData.Ordering
                            select new FormQuestionDto()
                            {
                                FormQuestionId = formQuestionData.FormQuestionId,
                                Ordering = formQuestionData.Ordering,
                                Label = formQuestionData.Label,
                                ControlId = formQuestionData.ControlId,
                                Image = formQuestionData.Image,
                                Required = formQuestionData.Required,
                                CssClass = formQuestionData.Cssclass,
                                Icon = formQuestionData.Icon,
                                HtmlControlId = formQuestionData.HtmlControlId,
                                HtmlControlName = formQuestionData.HtmlControlName,
                                WizardStepId = formQuestionData.WizardStepId
                            }).ToList();

                        foreach (var frmQstn in formQuestion)
                        {
                            var questionAnswer = (from formQuestionAnswerData in _context.FormQuestionAnswer
                                where formQuestionAnswerData.FormQuestionId == frmQstn.FormQuestionId
                                select new FormQuestionAnswerDto()
                                {
                                    FormQuestionId = formQuestionAnswerData.FormQuestionId,
                                    FormQuestionAnswerId = formQuestionAnswerData.FormQuestionAnswerId,
                                    Answer = formQuestionAnswerData.Answer,
                                    Icon = formQuestionAnswerData.Icon
                                }).ToList();
                            frmQstn.Answers = questionAnswer;
                        }
                        
                        wzrstp.FormQuestions = formQuestion;
                    }

                    resolutionItem.WizardStep = wizardStep;
                }


                _context.SaveChanges();
                
                return resolutions;
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