using IMSBussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDaos
{
    public class UserDAO
    {
        private readonly IMSDbContext db = null;
        private static UserDAO instance = null;
        public UserDAO() 
        {
            db = new IMSDbContext();
        }
        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }
        public User GetUser(int UserId)
        {
            return db.Users.FirstOrDefault(x => x.UserId.Equals(UserId));
        }
        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }
        public void DeleteSeaArea(int userId)
        {
            User user = GetUser(userId);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        public void UpdateUser(int userId, User newUser)
        {
            User user = GetUser(userId);
            if (user != null)
            {
                user.UserId = newUser.UserId;
                user.UserName = newUser.UserName; 
                user.Password = newUser.Password;
                user.Email = newUser.Email;
                user.Address = newUser.Address;
                user.Avatar = newUser.Avatar;
                user.Status = newUser.Status;
                user.Phone = newUser.Phone;
                user.DoB = newUser.DoB;
                user.Level = newUser.Level;
                user.RoleID = newUser.RoleID;

                db.Users.Update(user);
                db.SaveChanges();
            }
        }
        public void AddUser(User user)
        {
            User newUser = GetUser(user.UserId);
            if (newUser == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
