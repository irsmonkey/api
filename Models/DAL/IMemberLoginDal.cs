using System;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IMemberLoginDal
    {
        bool ValidateUser(string username, string password);
        MemberLogin AddMember(MemberLogin member);
        MemberLogin GetMemberLogin(Guid id);
    }
}