using UserLogin.Models;

namespace UserLogin.Services
{
    public interface IUserService
    {
        // Bussiness Logic Credentials Verification
        User AuthenticateUserNameAndPassword(string username, string password);
    }
}
