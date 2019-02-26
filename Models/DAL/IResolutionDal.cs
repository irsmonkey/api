using System;
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
        List<FormSubmitted> GetAResolution(Guid id, int resolution);
    }
}