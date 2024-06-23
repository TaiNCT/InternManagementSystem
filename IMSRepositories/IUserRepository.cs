using IMSBussinessObjects;

namespace IMSRepositories
{
    public interface IUserRepository
    {
        public User GetUser(int UserId);
        public List<User> GetUsers();

        public void DeleteSeaArea(int userId);

        public void UpdateUser(int userId, User newUser);

        public void AddUser(User user);

    }
}
