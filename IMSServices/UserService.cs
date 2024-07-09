using IMSBussinessObjects;
using IMSRepositories;
using System.Security.Cryptography;
using System.Text;

namespace IMSServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            userRepository = userRepository;
        }
        public void AddUser(User user)
        {
            userRepository.AddUser(user);
        }

        public User Authenticate(string email, string password)
        {
            var user = userRepository.GetAccount(email);
            if (user == null)
            {
                return null;
            }
            var isPasswordValid = VerifyPassword(password, user.Password, user.RefreshToken);
            return isPasswordValid ? user : null;
        }

        public User GetUserById(int userID)
        {
            return userRepository.GetUserById(userID);
        }

        public List<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public void RemoveUser(int userID)
        => userRepository.RemoveUser(userID);


        public void UpdateUser(int userID, User newUser)
        => userRepository.UpdateUser(userID, newUser);


        private bool VerifyPassword(string password, string hash, string salt)
        {
            const int keySize = 64;
            const int iterations = 350_000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

            var hashToVerify = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                Convert.FromHexString(salt),
                iterations,
                hashAlgorithm,
                keySize);

            return CryptographicOperations.FixedTimeEquals(hashToVerify, Convert.FromHexString(hash));
        }
    }


}

