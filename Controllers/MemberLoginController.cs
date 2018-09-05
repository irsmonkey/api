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
        private readonly IMemberLoginDal _dal;
        private readonly IMemberDal _memberDal;

        public MemberLoginController(IMemberLoginDal dal, IMemberDal memberDal)
        {
            _dal = dal;
            _memberDal = memberDal;
        }

        [HttpPost, Route("ValidateMember")]
        public ActionResult Post([FromBody] MemberLogin member)
        {
            try
            {
                var validated = _dal.ValidateUser(member.Username, member.Password);
                return Ok(validated);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost, Route("AddMember")]
        public ActionResult Add([FromBody] MemberLogin member)
        {
            
            var memberLogin = _dal.AddMember(member);
            try
            {
                return memberLogin != null ? (ActionResult) Accepted(memberLogin) : BadRequest("Unable to add");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}