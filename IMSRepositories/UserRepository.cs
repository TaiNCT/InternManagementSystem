using IMSBussinessObjects;
using IMSDaos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public class UserRepository : IUserRepository
    {

        public void AddUser(User user) => UserDAO.Instance.AddUser(user);

        public void DeleteSeaArea(int userId) => UserDAO.Instance.DeleteSeaArea(userId);

        public User GetUser(int UserId) => UserDAO.Instance.GetUser(UserId);    

        public List<User> GetUsers() => UserDAO.Instance.GetUsers();
        public void UpdateUser(int userId, User newUser) => UserDAO.Instance.UpdateUser(userId, newUser);
    }
}
