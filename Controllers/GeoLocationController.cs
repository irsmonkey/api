using System;
using IrsMonkeyApi.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class GeoLocationController : Controller
    {
        private readonly IGeoLocationDal _dal;

        public GeoLocationController(IGeoLocationDal dal)
        {
            _dal = dal;
        }

        [Route("GetLocation/{zipcode}"), HttpGet]
        public IActionResult GetGeoByZipCode(string zipcode)
        {
            try
            {
                var location = _dal.GetLocationByZip(zipcode);
                return location != null ? (IActionResult) Ok(location) : NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}