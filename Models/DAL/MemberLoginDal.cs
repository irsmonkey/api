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
    }
}