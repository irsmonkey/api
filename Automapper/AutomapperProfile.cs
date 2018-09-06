using AutoMapper;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;

namespace IrsMonkeyApi.Automapper
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<MemberLogin, MemberLoginDto>()
                .ReverseMap();
            CreateMap<FormSubmitted, FormSubmittedDto>()
                .ReverseMap();
        }
    }
}