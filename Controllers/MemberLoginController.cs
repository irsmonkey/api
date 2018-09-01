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

        [HttpGet]
        [Route("getAllUsers")]
        public IEnumerable<MemberLogin> GetAll()
        {
            try
            {
                return _context.MemberLogin.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<MemberLogin> GetById(int id)
        {
            try
            {
                var user = _context.MemberLogin.Find(id);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [HttpPost, Route("ValidateUser")]
        public ActionResult Post([FromBody] MemberLogin Member)
        {
            var Validated = _dal.ValidateUser(Member.Username, Member.Password);
            return Ok(Validated);
        }
    }
}