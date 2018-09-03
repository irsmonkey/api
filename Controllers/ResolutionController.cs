using System;
using IrsMonkeyApi.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class ResolutionController : Controller
    {
        private readonly IResolutionDal _dal;

        public ResolutionController(IResolutionDal dal)
        {
            _dal = dal;
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
    }
}