using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using IrsMonkeyApi.Models.DB;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Remotion.Linq.Clauses;
using IrsMonkeyApi.Models.DAL;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IRSMonkeyContext _context;
        private readonly IUserDal _dal;

        public UserController(IRSMonkeyContext context, IUserDal dal)
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
            var Validated = _dal.UserValidation(user.Email, user.PasswordSalt);
            return Ok(Validated);
        }
    }
}