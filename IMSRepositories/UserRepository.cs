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
        public void AddUser(User user)
        => UserDAO.Instance.AddUser(user);

        public User GetAccount(string email)
        {
            return userDAO.GetAccount(email);
        }

        public User GetUserById(int userID)
        => UserDAO.Instance.GetUserById(userID);

        public Task<User> GetUserBySupervisorIdAsync(int supervisorId)
    => UserDAO.Instance.GetUserBySupervisorIdAsync(supervisorId);
        public List<User> GetUsers()
        => UserDAO.Instance.GetUsers();

        public void RemoveUser(int userID)
        => UserDAO.Instance.RemoveUser(userID);

        public void UpdateUser(int userID, User newUser)
        => UserDAO.Instance.UpdateUser(userID, newUser);


    }
}
