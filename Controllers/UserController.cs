using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IrsMonkeyApi.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IRSMonkeyContext _context;

        public UserController(IRSMonkeyContext context)
        {
            _context = context;
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
        public ActionResult<User> GetById(long id)
        {
            try
            {
                var user = _context.User.Find(id);
                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public ActionResult<User> GetByEmail(string Email)
        {
            try
            {
                var user = from u in _context.User
                    where u.Email.Equals(Email)
                    select u;
                if (!user.Any())
                {
                    return NotFound();
                }

                return Json(user);
            }
            catch (Exception e)
            {
               throw new Exception(e.ToString());
            }
        }
    }
}