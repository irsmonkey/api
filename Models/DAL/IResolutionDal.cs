using System.Collections.Generic;
using System.Linq;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IResolutionDal
    {
        List<ResolutionDto> GetAllResolutions();
        Resolution GetAResolution();
    }
}