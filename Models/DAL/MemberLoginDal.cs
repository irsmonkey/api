using System;
using System.Linq;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Microsoft.EntityFrameworkCore.Storage;

namespace IrsMonkeyApi.Models.DAL
{
    public class MemberLoginDal: IMemberLoginDal
    {
        private readonly IRSMonkeyContext _context;

        public MemberLoginDal(IRSMonkeyContext context)
        {
            _context = context;
        }
        
        public MemberLogin ValidateUser(string username, string password)
        {
            try
            {
                var validated = _context.MemberLogin
                    .FirstOrDefault(ml => ml.Username == username && ml.Password == password);
                return validated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MemberLogin CreateMemberLogin(MemberLoginDto memberLogin)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var memberShip = new MembershipType()
                    {
                        MembershipTypeName = "Individual"
                    };
                    var newMember = new Member
                    {
                        FirstName = memberLogin.FirstName,
                        LastName = memberLogin.LastName,
                        SignUpDate = DateTime.Now,
                        Email = memberLogin.Username,
                        MembershipType = memberShip
                    };
                    var createdMember = _context.Member.Add(newMember);
                    var savedMember = _context.SaveChanges();
                    
                    var newMemberLogin = new MemberLogin
                    {
                        Username = memberLogin.Username,
                        Password = memberLogin.Password,
                        CreatedAt = DateTime.Now
                    };
                    _context.MemberLogin.Add(newMemberLogin);
                    var createdMemberLogin = _context.SaveChanges();
                    transaction.Commit();
                    return createdMemberLogin > 0 ? newMemberLogin : null;
                }
                catch (Exception)
                {
                    throw;
                }
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