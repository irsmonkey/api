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
                var validated = _context.MemberLogin
                    .FirstOrDefault(ml => ml.Username == username && ml.Password == password);
                return validated != null;
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        public MemberLogin GetMemberLogin(Guid id)
        {
            try
            {
                var memberLogin = _context.MemberLogin.Find(id);
                return memberLogin;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}