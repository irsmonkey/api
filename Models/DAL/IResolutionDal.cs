using System.Collections.Generic;
using System.Linq;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IResolutionDal
    {
        IQueryable<ResolutionDto> GetAllResolutions();
        Resolution GetAResolution();
    }
}