﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IMSBussinessObjects;

namespace InternManagement.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IMSBussinessObjects.AppDbContext _context;

        public IndexModel(IMSBussinessObjects.AppDbContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Users != null)
            {
                User = await _context.Users.ToListAsync();
            }
        }
    }
}
