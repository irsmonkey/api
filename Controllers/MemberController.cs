using System;
using IrsMonkeyApi.Models.DAL;
using IrsMonkeyApi.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly IMemberDal _dal;

        public MemberController(IRSMonkeyContext context, IMemberDal dal)
        {
            _dal = dal;
        }

        [Route("GetMember/{id}"), HttpGet]
        public IActionResult Index(Guid id)
        {
            try
            {
                var member = _dal.GetMember(id);
                if (member != null)
                {
                    return Ok(member);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("CreateMember"), HttpPost]
        public IActionResult Save([FromBody] Member member)
        {
            try
            {
                var savedMember = _dal.SaveMember(member);
                if (savedMember != null)
                {
                    return Accepted(savedMember);
                }
                else
                {
                    return BadRequest("Data could not be saved");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}