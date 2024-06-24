using IMSBussinessObjects;

namespace IMSServices
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int userId);
        Task<List<User>> GetUsersAsync();
        Task DeleteUserAsync(int userId);
        Task UpdateUserAsync(int userId, User newUser);
        Task AddUserAsync(User user);
        Task<User> GetAccountAsync(string username, string password);
    }
}
