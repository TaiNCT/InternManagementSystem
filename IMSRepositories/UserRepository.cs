using IMSBussinessObjects;
using IMSDaos;

namespace IMSRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO userDAO = null;
        public UserRepository()
        {
            if (userDAO == null)
            {
                userDAO = new UserDAO();
            }
        }
        public void AddUser(User user) => UserDAO.Instance.AddUser(user);

        public void DeleteUser(int userId)
            => UserDAO.Instance.DeleteUser(userId);

        public User GetAccount(string username, string password)
        {
            return userDAO.GetAccount(username, password);
        }

        public User GetUser(int UserId) => UserDAO.Instance.GetUser(UserId);

        public List<User> GetUsers() => UserDAO.Instance.GetUsers();
        public void UpdateUser(int userId, User newUser) => UserDAO.Instance.UpdateUser(userId, newUser);
    }
}
