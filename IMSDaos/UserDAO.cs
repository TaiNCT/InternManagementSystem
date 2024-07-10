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
            return db.Users.FirstOrDefault(x => x.Email.Equals(email));
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
                HashPassword(user.Password, out string hashedPassword, out string salt);
                user.Password = hashedPassword;
                user.RefreshToken = salt;

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
            var existUser = GetUserById(userID);
            if (existUser != null)
            {
                HashPassword(newUser.Password, out string hashedPassword, out string salt);
                existUser.Password = hashedPassword;
                existUser.RefreshToken = salt;

                existUser.Username = newUser.Username;
                existUser.Role = newUser.Role;

                db.Users.Attach(existUser);
                db.Entry(existUser).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private void HashPassword(string password, out string hashedPassword, out string salt)
        {
            const int keySize = 64;
            const int iterations = 350_000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

            var saltInBytes = RandomNumberGenerator.GetBytes(keySize);
            var hashInBytes = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                saltInBytes,
                iterations,
                hashAlgorithm,
                keySize);

            salt = Convert.ToHexString(saltInBytes);
            hashedPassword = Convert.ToHexString(hashInBytes);
        }

    }
}

