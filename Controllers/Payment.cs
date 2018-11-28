using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class Payment : Controller
    {
        [Route("chargeCard"), HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}