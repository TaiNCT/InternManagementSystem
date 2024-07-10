using IMSBussinessObjects;
using IMSRepositories;
using System.Security.Cryptography;
using System.Text;

namespace IMSServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetUserById(int userID)
        {
            return _userRepository.GetUserById(userID);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void RemoveUser(int userID)
        {
            _userRepository.RemoveUser(userID);
        }

        public void UpdateUser(int userID, User newUser)
        {
            _userRepository.UpdateUser(userID, newUser);
        }

        private bool VerifyPassword(string password, string hash, string salt)
        {
            const int keySize = 32;
            const int iterations = 350_000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

            var hashToVerify = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                Convert.FromHexString(salt),
                iterations,
                hashAlgorithm,
                keySize);

            return CryptographicOperations.FixedTimeEquals(hashToVerify, Convert.FromHexString(hash));
        }

        public User GetAccount(string email)
        {
            return _userRepository.GetAccount(email);
        }
    }
}
