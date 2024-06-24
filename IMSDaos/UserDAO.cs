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

        public static async Task<UserDAO> InstanceAsync()
        {
            if (instance == null)
            {
                instance = new UserDAO();
            }
            return instance;
        }

        public async Task<User> GetAccountAsync(string username, string password)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.UserName.Equals(username) && x.Password.Equals(password));
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.UserId.Equals(userId));
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await GetUserAsync(userId);
            if (user != null)
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(int userId, User newUser)
        {
            var existingUser = await GetUserAsync(userId);
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

                db.Users.Update(existingUser);
                await db.SaveChangesAsync();
            }
        }

        public async Task AddUserAsync(User user)
        {
            var newUser = await GetUserAsync(user.UserId);
            if (newUser == null)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
