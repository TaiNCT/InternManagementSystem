using IMSBussinessObjects;
using IMSRepositories;

namespace IMSServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository? iUserRepository = null;
        public UserService()
        {
            iUserRepository ??= new UserRepository();
        }

        public void AddUser(User user)
        {
            iUserRepository.AddUser(user);
        }

        public void DeleteUser(int userId)
        {
            iUserRepository.DeleteUser(userId);
        }

        public User GetAccount(string username, string password)
        {
            return iUserRepository.GetAccount(username, password);
        }

        public User GetUser(int UserId)
        {
            return iUserRepository.GetUser(UserId);
        }

        public List<User> GetUsers()
        {
            return iUserRepository.GetUsers();
        }

        public void UpdateUser(int userId, User newUser)
        {
            iUserRepository.UpdateUser(userId, newUser);
        }
    }
}
