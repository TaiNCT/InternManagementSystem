﻿using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.UserPage
{
    public class IndexModel : PageModel
    {
        private readonly IUserService userService;

        public IndexModel(IUserService userServ)
        {
            userService = userServ;
        }

        public IList<User> User { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (userService.GetUsers() != null)
            {
                User = userService.GetUsers();
            }
        }
    }
}
