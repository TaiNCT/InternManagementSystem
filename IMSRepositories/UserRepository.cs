using IMSBussinessObjects;
using IMSDaos;

namespace IMSRepositories
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(User user)
        => UserDAO.Instance.AddUser(user);

        public User GetAccount(string email) => UserDAO.Instance.GetAccount(email);
        public User GetUserById(int userID)
        => UserDAO.Instance.GetUserById(userID);

        public List<User> GetUsers()
        => UserDAO.Instance.GetUsers();

        public void RemoveUser(int userID)
        => UserDAO.Instance.RemoveUser(userID);

        public void UpdateUser(int userID, User newUser)
        => UserDAO.Instance.UpdateUser(userID, newUser);
    }
}
