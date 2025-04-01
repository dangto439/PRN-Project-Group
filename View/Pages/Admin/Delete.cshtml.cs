using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace View.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly IUser _user;
        private readonly IHubContext<SignalRAdmin> _hubContext;

        public DeleteModel(IUser user, IHubContext<SignalRAdmin> hubContext)
        {
            _user = user;
            _hubContext = hubContext;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "ADMIN")
            {
                return RedirectToPage("/AccessDenied");
            }
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
            await _hubContext.Clients.All.SendAsync("LoadAdminDashboard");
            return RedirectToPage("/Admin/UserManagement");
        }
    }
}
