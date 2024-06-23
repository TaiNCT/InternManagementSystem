using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        private readonly IUserService userService;

        public IndexModel(IUserService userServ)
        {
            userService = userServ;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            // Attempt to retrieve the user from the database
            User user = userService.GetAccount(UserName, Password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserName", UserName);
                HttpContext.Session.SetInt32("RoleID", user.RoleID);
                return RedirectToPage("/UserPage/Index");

            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return Page();
            }
        }
    }
}

