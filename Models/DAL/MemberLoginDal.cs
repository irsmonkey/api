using System;
using System.Linq;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public class MemberLoginDal: IMemberLoginDal
    {
        private IRSMonkeyContext _context;

        public MemberLoginDal(IRSMonkeyContext context)
        {
            _context = context;
        }
        
        public bool ValidateUser(string username, string password)
        {
            try
            {
                var validated = (from u in _context.User
                    where u.Email == username && u.PasswordSalt == password
                    select u).SingleOrDefault();

                return validated != null;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}