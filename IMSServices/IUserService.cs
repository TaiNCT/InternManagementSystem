using IMSBussinessObjects;
using IMSDaos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public interface IUserService
    {
        public void AddUser(User user);

        public void DeleteSeaArea(int userId);

        public User GetUser(int UserId);

        public List<User> GetUsers();
        public void UpdateUser(int userId, User newUser);
    }
}
