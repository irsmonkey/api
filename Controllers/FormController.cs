using System;
using IrsMonkeyApi.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class FormController: Controller
    {
        private readonly IFormDal _dal;

        public FormController(IFormDal dal)
        {
            _dal = dal;
        }

        [Route("GetAllForms"), HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var forms = _dal.GetAllForms();
                return Ok(forms);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}