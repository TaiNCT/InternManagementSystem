using IMSBussinessObjects;

namespace IMSServices
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        public User GetUserById(int userID);
        public List<User> GetUsers();
        public void AddUser(User user);
        public void RemoveUser(int userID);
        public void UpdateUser(int userID, User newUser);
    }
}
