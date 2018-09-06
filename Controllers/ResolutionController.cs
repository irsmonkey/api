using System;
using System.Collections.Generic;
using AutoMapper;
using IrsMonkeyApi.Models.DAL;
using IrsMonkeyApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class ResolutionController : Controller
    {
        private readonly IResolutionDal _dal;
        private readonly IMapper _mapper;

        public ResolutionController(IResolutionDal dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }
        
        [Route("GetAllResolutions"), HttpGet]
        public IActionResult Index()
        {
            try
            {
                var resolutionsDto = new List<ResolutionDto>();
                var resolutions = _dal.GetAllResolutions();
                foreach (var resolution in resolutions)
                {
                    var resolutionForPage = new ResolutionDto()
                    {
                        Resolution1 = resolution.Resolution1,
                        FormResolution = resolution.FormResolution,
                        Wizard =  resolution.Wizard
                    };
                    resolutionsDto.Add(resolutionForPage);
                    
                }
                return Ok(resolutionsDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}