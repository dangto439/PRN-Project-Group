using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;

namespace View.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly IUser _user;

        public DeleteModel(IUser user)
        {
            _user = user;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _user.GetById(id.Value);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _user.GetById(id.Value);
            if (user != null)
            {
                User = user;
                await _user.Delete(id.Value);
            }

            return RedirectToPage("/Admin/UserManagement");
        }
    }
}
