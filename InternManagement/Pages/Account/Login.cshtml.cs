using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace InternManagement.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        [TempData]
        public string ErrorMessage { get; set; }

        public string ReturnUrl { get; set; }

        [BindProperty, Required]
        public string Email { get; set; }

        [BindProperty, Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginModel(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public void OnGet(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            returnUrl = returnUrl ?? Url.Content("~/");
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var defaultUser = _configuration.GetSection("DefaultUser").Get<User>();
                var user = _userService.GetAccount(Email);

                bool isAuthenticated = false;

                if (user != null)
                {
                    // Verify password for database user
                    isAuthenticated = VerifyPassword(Password, user.Password, user.RefreshToken);
                }
                else if (Email == defaultUser.Email)
                {
                    // Verify password for default user
                    isAuthenticated = VerifyPassword(Password, defaultUser.Password, defaultUser.RefreshToken);
                }

                if (isAuthenticated)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, Email)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    return LocalRedirect(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            // If we got this far, something failed, redisplay form
            return Page();
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