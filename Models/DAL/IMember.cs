using System;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IMember
    {
        Member GetMember(Guid memberId);
        Member SaveMember(Member member);
        Member UpdateMember(Member member);
        bool DeleteMember(Guid memberId);
        bool ChangeMemberStatus(Guid memberId, bool status);
    }
}