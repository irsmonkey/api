using System.Linq;
using IrsMonkeyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Any()) return;
            _context.TodoItems.Add(new TodoItem{Name= "Item 1"});
            _context.SaveChanges();
        }
    }
}