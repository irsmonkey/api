using System;
using IrsMonkeyApi.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly IProductItemDal _dal;

        public ItemsController(IProductItemDal dal)
        {
            _dal = dal;
        }
        
        [Route("GetProduct/{id}"), HttpGet]
        public IActionResult Index(int id)
        {
            try
            {
                var products = _dal.GetProductItems(id);
                return products != null ? (IActionResult) Ok(products) : NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}