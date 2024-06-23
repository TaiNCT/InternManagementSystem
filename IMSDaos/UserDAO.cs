using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;

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
        public User GetAccount(string username, string password)
        {
            return db.Users.FirstOrDefault(x => x.UserName.Equals(username) && x.Password.Equals(password));
        }
        public User GetUser(int UserId)
        {
            return db.Users.FirstOrDefault(x => x.UserId.Equals(UserId));
        }
        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }
        public void DeleteUser(int userId)
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

            var existingUser = GetUser(userId);
            if (existingUser != null)
            {
                existingUser.UserId = newUser.UserId;
                existingUser.UserName = newUser.UserName;
                existingUser.Password = newUser.Password;
                existingUser.Email = newUser.Email;
                existingUser.Address = newUser.Address;
                existingUser.Avatar = newUser.Avatar;
                existingUser.Status = newUser.Status;
                existingUser.Phone = newUser.Phone;
                existingUser.DoB = newUser.DoB;
                existingUser.Level = newUser.Level;
                existingUser.RoleID = newUser.RoleID;

                db.Users.Attach(existingUser);
                db.Entry(existingUser).State = EntityState.Modified;
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
