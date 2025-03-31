using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;

namespace View.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly IUser _user;

        public EditModel(IUser user)
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

            var user =  await _user.GetById(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            User = user;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _user.GetById(id.Value);
            if (user == null) {
                return Page();
            }
            user.Role = User.Role;
            await _user.Update(user);

            return RedirectToPage("/Admin/UserManagement");
        }
    }
}
