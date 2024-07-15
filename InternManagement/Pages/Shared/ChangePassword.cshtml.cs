using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace InternManagement.Pages.Account
{
    [Authorize]
    public class ChangePasswordModel : PageModel
    {
        private readonly IUserService _userService;

        public ChangePasswordModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty, Required, DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [BindProperty, Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [BindProperty, Required, DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = _userService.GetAccount(email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                return Page();
            }

            if (!VerifyPassword(OldPassword, user.Password, user.RefreshToken))
            {
                ModelState.AddModelError(string.Empty, "Incorrect old password.");
                return Page();
            }

            _userService.UpdateUser(user.UserId, new User
            {
                Password = NewPassword,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                RefreshToken = user.RefreshToken
            });

            return RedirectToPage("/Index", new { message = "Password changed successfully!" });
        }

        private bool VerifyPassword(string password, string hash, string salt)
        {
            const int keySize = 32;
            const int iterations = 350000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

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
