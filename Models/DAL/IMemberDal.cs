using System;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IMemberDal
    {
        Member GetMember(Guid memberId);
        Member SaveMember(Member member);
        Member UpdateMember(Member member);
    }
}