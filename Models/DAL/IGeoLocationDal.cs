using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IGeoLocationDal
    {
        GeoLocation GetLocationByZip(string zipcode);
    }
}