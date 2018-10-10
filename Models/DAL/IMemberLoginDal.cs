using System;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IMemberLoginDal
    {
        MemberDto ValidateUser(string username, string password);
        MemberLogin CreateMemberLogin(MemberLoginDto member);
        MemberLogin GetMemberLogin(Guid id);
    }
}