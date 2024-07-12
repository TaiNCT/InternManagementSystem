using IMSBussinessObjects;
using IMSRepositories;

namespace IMSServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int userID)
        {
            return _userRepository.GetUserById(userID);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void RemoveUser(int userID)
        {
            _userRepository.RemoveUser(userID);
        }

        public void UpdateUser(int userID, User newUser)
        {
            _userRepository.UpdateUser(userID, newUser);
        }

        public User GetAccount(string email)
        {
            return _userRepository.GetAccount(email);
        }


    }
}