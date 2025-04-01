using BusinessLogicLayer.Hubs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace View.Pages.Admin
{
    public class DeleteContactModel : PageModel
    {
        private readonly IContact _contact;
        private readonly IHubContext<SignalRAdmin> _hubContext;
        public DeleteContactModel(IContact contact, IHubContext<SignalRAdmin> hubContext)
        {
            _contact = contact;
            Contact = new DataAccessLayer.Entity.Contact();
            _hubContext = hubContext;
        }

        [BindProperty]
        public DataAccessLayer.Entity.Contact Contact { get; set; } = default!;
        public async Task<IActionResult> OnGet(int? id)
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

            var contact = await _contact.GetById(id.Value);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                Contact = contact;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contact.GetById(id.Value);
            if (contact != null)
            {
                Contact = contact;
                await _contact.Delete(id.Value);
            }
            await _hubContext.Clients.All.SendAsync("LoadAdminDashboard");
            return RedirectToPage("/Admin/ContactManagement");
        }
    }
}
