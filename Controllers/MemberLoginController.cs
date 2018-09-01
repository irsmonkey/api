using System;
using System.Collections.Generic;
using System.Linq;
using IrsMonkeyApi.Models.DAL;
using IrsMonkeyApi.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class MemberLoginController : Controller
    {
        private readonly IRSMonkeyContext _context;
        private readonly IMemberLoginDal _dal;

        public MemberLoginController(IRSMonkeyContext context, IMemberLoginDal dal)
        {
            _context = context;
            _dal = dal;
        }

        [HttpPost, Route("ValidateMember")]
        public ActionResult Post([FromBody] MemberLogin member)
        {
            try
            {
                var Validated = _dal.ValidateUser(member.Username, member.Password);
                return Ok(Validated);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost, Route("AddMember")]
        public ActionResult Add([FromBody] MemberLogin Member)
        {
            var newMember = _dal.AddMember(Member);
            try
            {
                if (newMember != null)
                {
                    return Accepted(newMember);
                }
                else
                {
                    return BadRequest("Unable to add");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}