namespace IrsMonkeyApi.Models.DAL
{
    public interface IUserDal
    {
        bool UserValidation(string Username, string Password);
    }
}