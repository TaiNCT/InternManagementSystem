using System.Security.Cryptography;
using System.Text;

namespace PasswordHasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int keySize = 64;
            const int iterations = 350_000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

            // Generate a random salt
            var saltInBytes = RandomNumberGenerator.GetBytes(keySize);

            // Prompt user for password
            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            // Generate the hash
            var hashInBytes = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password!),
                saltInBytes,
                iterations,
                hashAlgorithm,
                keySize);

            // Convert hash and salt to hex string for storage
            var refreshToken = Convert.ToHexString(saltInBytes);
            var hash = Convert.ToHexString(hashInBytes);

            // Display the hash and salt
            Console.WriteLine($"RefreshToken: \n{refreshToken}");
            Console.WriteLine();
            Console.WriteLine($"Hash: \n{hash}");

            // Wait for a key press before closing
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
