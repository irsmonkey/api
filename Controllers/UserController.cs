using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Formatting;
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
        public ActionResult<User> GetById(int id)
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

        [HttpPost, Route("ValidateUser")]
        public string ValidateUser([FromBody] string postBody)
        {
            try
            {
                return postBody;
            }
            catch (Exception e)
            {
               throw new Exception(e.ToString());
            }
        }
    }
}