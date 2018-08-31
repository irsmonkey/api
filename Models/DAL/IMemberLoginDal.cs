namespace IrsMonkeyApi.Models.DAL
{
    public interface IMemberLoginDal
    {
        bool ValidateUser(string username, string password);
    }
}