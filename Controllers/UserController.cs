using System.Collections;
using System.Collections.Generic;
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
            return _context.User.ToList();
        }
    }
}