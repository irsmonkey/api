using System;
using System.Collections.Generic;
using System.Linq;
using IrsMonkeyApi.Models.DAL;
using IrsMonkeyApi.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IRSMonkeyContext _context;
        private readonly IMemberLoginDal _dal;

        public UserController(IRSMonkeyContext context, IMemberLoginDal dal)
        {
            _context = context;
            _dal = dal;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public IEnumerable<User> GetAll()
        {
            try
            {
                return _context.User.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetById(int id)
        {
            try
            {
                var user = _context.User.Find(id);
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
        public ActionResult Post([FromBody] User user)
        {
            var Validated = _dal.ValidateUser(user.Email, user.PasswordSalt);
            return Ok(Validated);
        }
    }
}