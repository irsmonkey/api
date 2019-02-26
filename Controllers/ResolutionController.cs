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
                var resolutions = _dal.GetAllResolutions();
                return Ok(resolutions);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("GetMemberResolution/{resolution}/{id}"), HttpGet]
        public IActionResult getMemberResolutions(Guid id, int resolution)
        {
            try
            {
                var memberResolution = _dal.GetAResolution(id, resolution);
                return Ok(memberResolution);
            }
            catch (Exception e)
            {
               return BadRequest(e);
            }
        }
    }
}