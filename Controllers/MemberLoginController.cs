using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IrsMonkeyApi.Models.DAL;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class MemberLoginController : Controller
    {
        private readonly IMemberLoginDal _dal;
        private readonly IMapper _mapper;

        public MemberLoginController(IMemberLoginDal dal, IMemberDal memberDal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        [Route("GetMemberLogin/{id}"), HttpGet]
        public ActionResult GetMember(Guid id)
        {
            var memberLogin = _dal.GetMemberLogin(id);
            var memberLoginContract = _mapper.Map<MemberLoginDto>(memberLogin);
            return Ok(memberLoginContract);
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
        public ActionResult Add([FromBody] MemberLogin memberLogin)
        {
            var newMemberLogin = _dal.AddMember(memberLogin);
            try
            {
                return memberLogin != null ? (ActionResult) Accepted(newMemberLogin) : BadRequest("Unable to add");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}