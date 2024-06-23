using IMSBussinessObjects;

namespace IMSServices
{
    public interface IUserService
    {
        public void AddUser(User user);

        public void DeleteUser(int userId);

        public User GetUser(int UserId);

        public List<User> GetUsers();
        public void UpdateUser(int userId, User newUser);
        public User GetAccount(string username, string password);

    }
}
