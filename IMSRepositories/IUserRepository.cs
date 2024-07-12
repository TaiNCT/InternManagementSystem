using IMSBussinessObjects;

namespace IMSRepositories
{
    public interface IUserRepository
    {
        public User GetAccount(string email);

        public User GetUserById(int userID);
        public Task<User> GetUserBySupervisorIdAsync(int supervisorId);

        public List<User> GetUsers();
        public void AddUser(User user);
        public void RemoveUser(int userID);
        public void UpdateUser(int userID, User newUser);

    }
}
