using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace View.Pages.Admin.News
{
    public class CreateModel : PageModel
    {
        private readonly INewsEvent _newsEvent;
        private readonly IHubContext<SignalRAdmin> _hubContext;
        public CreateModel(INewsEvent newsEvent, IHubContext<SignalRAdmin> hubContext)
        {
            _newsEvent = newsEvent;
            _hubContext = hubContext;
        }

        public IActionResult OnGet()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "ADMIN")
            {
                return RedirectToPage("/AccessDenied");
            }
            return Page();
        }

        [BindProperty]
        public NewsEvent NewsEvent { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            NewsEvent.CreatedBy = 1;
            await _newsEvent.Create(NewsEvent);
            await _hubContext.Clients.All.SendAsync("LoadAdminDashboard");
            return RedirectToPage("/Admin/NewsManagement");
        }
    }
}
