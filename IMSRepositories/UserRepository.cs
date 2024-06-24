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

        public async Task AddUserAsync(User user)
        => await userDAO.AddUserAsync(user);

        public async Task DeleteUserAsync(int userId)
        => await userDAO.DeleteUserAsync(userId);

        public async Task<User> GetAccountAsync(string username, string password)
        => await userDAO.GetAccountAsync(username, password);

        public async Task<User> GetUserAsync(int userId)
        => await userDAO.GetUserAsync(userId);

        public async Task<List<User>> GetUsersAsync()
        => await userDAO.GetUsersAsync();

        public async Task UpdateUserAsync(int userId, User newUser)
        => await userDAO.UpdateUserAsync(userId, newUser);
    }
}
