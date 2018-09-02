using System;
using System.Linq;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public class MemberLoginDal: IMemberLoginDal
    {
        private readonly IRSMonkeyContext _context;

        public MemberLoginDal(IRSMonkeyContext context)
        {
            _context = context;
        }
        
        public bool ValidateUser(string username, string password)
        {
            try
            {
                var validated = (from m in _context.MemberLogin
                    where m.Username == username && m.Password == password
                    select m).SingleOrDefault();

                return validated != null;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public MemberLogin AddMember(MemberLogin memberLogin)
        {
            try
            {
                _context.Add(memberLogin);
                var newMemberLogin = _context.SaveChanges();
                return newMemberLogin > 0 ? memberLogin : null;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}