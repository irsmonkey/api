using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
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
                    var formQuestion = (from formQuestionData in _context.FormQuestion
                        where formQuestionData.FormId == resolutionItem.FormId
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
                            WizardStep = formQuestionData.WizardStep
                        }).ToList();

                    foreach (var formQuestionItem in formQuestion)
                    {
                        
                        var formQuestionAnswer = (from formQuestionAnswerData in _context.FormQuestionAnswer
                                where formQuestionAnswerData.FormQuestionId == formQuestionItem.FormQuestionId
                                      select new FormQuestionAnswerDto()
                                      {
                                          FormQuestionId = formQuestionAnswerData.FormQuestionId,
                                          FormQuestionAnswerId = formQuestionAnswerData.FormQuestionAnswerId,
                                          Answer = formQuestionAnswerData.Answer,
                                          Icon = formQuestionAnswerData.Icon
                                      }).ToList();
                        formQuestionItem.Answers = formQuestionAnswer;
                    }
                    
                    resolutionItem.FormQuestions = formQuestion;
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