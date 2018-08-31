using System.Linq;
using IrsMonkeyApi.Models.DB;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace IrsMonkeyApi.Models.DAL
{
    public class UserDal: IUserDal
    {
        private readonly IRSMonkeyContext _context;

        public UserDal(IRSMonkeyContext context)
        {
            _context = context;
        }

        public bool UserValidation(string Username, string Password)
        {
            var validated = (from u in _context.User
                where u.Email == Username && u.PasswordSalt == Password
                select u).SingleOrDefault();

            return validated != null;
        }
    }
}