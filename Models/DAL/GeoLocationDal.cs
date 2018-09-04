using System;
using System.Linq;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{   
    public class GeoLocationDal: IGeoLocationDal
    {
        private readonly IRSMonkeyContext _context;

        public GeoLocationDal(IRSMonkeyContext context)
        {
            _context = context;
        }

        public GeoLocation GetLocationByZip(string zipcode)
        {
            try
            {
                var location = _context.GeoLocation.FirstOrDefault(l => l.ZipCode == zipcode);
                return location ?? null;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}