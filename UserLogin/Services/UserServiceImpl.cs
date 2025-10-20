using UserLogin.Models;
using UserLogin.Repository;

namespace UserLogin.Services
{
    public class UserServiceImpl
    {
        // field
        private readonly IUserRepository _userRepository;

        // constructor
        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User AuthenticateUserNameAndPassword(string username, string password)
        {
            return _userRepository.AuthenticateUser(username, password);
        }
    }
}
