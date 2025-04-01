using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace View.Pages.Admin.News
{
    public class DeleteModel : PageModel
    {
        private readonly INewsEvent _newsEvent;
        private readonly IHubContext<SignalRAdmin> _hubContext;
        public DeleteModel(INewsEvent newsEvent, IHubContext<SignalRAdmin> hubContext)
        {
            _newsEvent = newsEvent;
            _hubContext = hubContext;
        }

        [BindProperty]
        public NewsEvent NewsEvent { get; set; } = default!;

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

            var newsevent = await _newsEvent.GetById(id.Value);

            if (newsevent == null)
            {
                return NotFound();
            }
            else
            {
                NewsEvent = newsevent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsevent = await _newsEvent.GetById(id.Value);
            if (newsevent != null)
            {
                NewsEvent = newsevent;
                await _newsEvent.Delete(id.Value);
            }
            await _hubContext.Clients.All.SendAsync("LoadAdminDashboard");
            return RedirectToPage("/Admin/NewsManagement");
        }
    }
}
