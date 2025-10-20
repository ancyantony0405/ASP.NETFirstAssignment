using UserLogin.Models;

namespace UserLogin.Repository
{
    public interface IUserRepository
    {
        // Credentials Verification
        User AuthenticateUser(string username, string password);
    }
}
