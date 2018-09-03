using System.Collections.Generic;
using System.Linq;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IResolutionDal
    {
        List<Resolution> GetAllResolutions();
        Resolution GetAResolution();
    }
}