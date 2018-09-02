using System;
using IrsMonkeyApi.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Models.DAL
{
    public class MemberDal : IMemberDal
    {
        private readonly IRSMonkeyContext _context;

        public MemberDal(IRSMonkeyContext context)
        {
            _context = context;
        }

        public Member GetMember(Guid memberId)
        {
            try
            {
                var member = _context.Member.Find(memberId);
                return member;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public Member SaveMember(Member member)
        {
            try
            {
                _context.Member.Add(member);
                var newMember = _context.SaveChanges();
                return newMember > 0 ? member : null;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public Member UpdateMember(Member member)
        {
            try
            {
                _context.Update(member);
                var updatedMember = _context.SaveChanges();
                return updatedMember > 0 ? member : null;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}