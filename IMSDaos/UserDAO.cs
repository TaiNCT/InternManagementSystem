using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace IMSDaos
{
    public class UserDAO
    {
        private readonly AppDbContext db = null;
        private static UserDAO instance = null;

        public UserDAO()
        {
            db = new AppDbContext();
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

        public User GetAccount(string email)
        {
            return db.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public User GetUserById(int userID)
        {
            return db.Users.FirstOrDefault(x => x.UserId == userID);
        }
        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }
        public void AddUser(User user)
        {
            User newUser = GetUserById(user.UserId);
            if (newUser == null)
            {
                HashPassword(user.Password, out string hashedPassword, out string refreshToken);
                user.Password = hashedPassword;
                user.RefreshToken = refreshToken;  // Set the RefreshToken here
                user.Username = newUser.Username;
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        public void RemoveUser(int userID)
        {

            User user = GetUserById(userID);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        public void UpdateUser(int userID, User newUser)
        {
            var existingUser = GetUserById(userID);
            if (existingUser != null)
            {
                if (!string.IsNullOrEmpty(newUser.Password))
                {
                    // Only update the password if a new password is provided
                    HashPassword(newUser.Password, out string hashedPassword, out string refreshToken);
                    existingUser.Password = hashedPassword;
                    existingUser.RefreshToken = refreshToken;
                }

                existingUser.Username = newUser.Username;
                existingUser.Email = newUser.Email;
                existingUser.Role = newUser.Role;

                db.Users.Attach(existingUser);
                db.Entry(existingUser).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private void HashPassword(string password, out string hashedPassword, out string refreshToken)
        {
            const int keySize = 32;
            const int iterations = 350_000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

            var saltInBytes = RandomNumberGenerator.GetBytes(keySize);
            var hashInBytes = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                saltInBytes,
                iterations,
                hashAlgorithm,
                keySize);

            refreshToken = Convert.ToHexString(saltInBytes);
            hashedPassword = Convert.ToHexString(hashInBytes);
        }

    }
}

