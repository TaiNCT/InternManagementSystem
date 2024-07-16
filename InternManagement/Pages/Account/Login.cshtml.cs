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
        private readonly IInternService _internService;

        [TempData]
        public string ErrorMessage { get; set; }
        public string ReturnUrl { get; set; }

        [BindProperty, Required]
        public string Email { get; set; }

        [BindProperty, Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginModel(IUserService userService, IInternService internService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
            _internService = internService;
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
            ModelState.Remove("ReturnUrl");

            if (ModelState.IsValid)
            {
                var defaultUser = _configuration.GetSection("DefaultUser").Get<User>();
                // Fetch the most recent user data from the database
                var user = _userService.GetAccount(Email);
                Console.WriteLine($"Login attempt for user: {Email}");

                bool isAuthenticated = false;
                if (user != null)
                {
                    // Verify password for database user
                    isAuthenticated = VerifyPassword(Password, user.Password, user.RefreshToken);
                    Console.WriteLine($"Database user found: {user.Email}, Authenticated: {isAuthenticated}");
                }
                else if (Email == defaultUser.Email)
                {
                    // Verify password for default user
                    isAuthenticated = VerifyPassword(Password, defaultUser.Password, defaultUser.RefreshToken);
                    user = defaultUser;

                    Console.WriteLine($"Default user found: {user.Email}, Authenticated: {isAuthenticated}");
                }
                string userName = user.Username;
                if (isAuthenticated)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, Email),
                        new Claim(ClaimTypes.Role, user.Role == 1 ? "Admin" : user.Role == 2 ? "Supervisor" : "Intern")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    // Sign in with a new session
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    // Safely handle the returnUrl
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        /*  if (_internService.GetInternsByStatus("waiting")!=null && user.Role != 3)
                          {
                              TempData["Approve"] = $"{_internService.GetInternsByStatus("waiting").Count} application is waiting to be approve";
                          }*/
                        TempData["done"] = $"{userName} Login Success";
                        return LocalRedirect(returnUrl);
                    }
                    return LocalRedirect(Url.Content("~/Index"));
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            // If we got this far, something failed, redisplay form
            foreach (var modelStateEntry in ModelState.Values)
            {
                foreach (var error in modelStateEntry.Errors)
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
            }
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