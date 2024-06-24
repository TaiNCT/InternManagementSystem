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

        public async Task AddUserAsync(User user)
        => await iUserRepository.AddUserAsync(user);

        public async Task DeleteUserAsync(int userId)
                => await iUserRepository.DeleteUserAsync(userId);


        public async Task<User> GetAccountAsync(string username, string password)
                => await iUserRepository.GetAccountAsync(username, password);


        public async Task<User> GetUserAsync(int userId)
                => await iUserRepository.GetUserAsync(userId);


        public async Task<List<User>> GetUsersAsync()
                => await iUserRepository.GetUsersAsync();

        public async Task UpdateUserAsync(int userId, User newUser)
               => await iUserRepository.UpdateUserAsync(userId, newUser);

    }
}
