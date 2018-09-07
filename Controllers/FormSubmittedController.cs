using System;
using AutoMapper;
using IrsMonkeyApi.Models.DAL;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class FormSubmittedController : Controller
    {
        private readonly IFormSubmittedDal _dal;
        private readonly IMapper _mapper;

        public FormSubmittedController(IFormSubmittedDal dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        [Route("SaveFormResolution"), HttpPost]
        public IActionResult Index([FromBody] FormSubmittedDto formSubmitted)
        {
            try
            {
                var memberLoginContract = _mapper.Map<FormSubmittedDto>(formSubmitted);
                var savedAnswers = _dal.SaveForm(memberLoginContract);
                return Ok(memberLoginContract);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("GetFormResolutionSubmitted/{id}"), HttpGet]
        public IActionResult GetForms(Guid id)
        {
            try
            {
                var returnedForms = _dal.GetForm(id);
                return Ok(returnedForms);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("GetFormPercentage/{id}"), HttpGet]
        public IActionResult GetFormsPercentage(Guid memberId)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}