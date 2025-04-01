using BusinessLogicLayer.Hubs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace View.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly IUser _user;
        private readonly IHubContext<SignalRAdmin> _hubContext;
        public RegisterModel(IUser user, IHubContext<SignalRAdmin> hubContext)
        {
            _user = user;
            _hubContext = hubContext;
        }
        [BindProperty]
        public string Usernames { get; set; }

        [BindProperty]
        public string Passwords { get; set; }

        [BindProperty]
        public string Emails { get; set; }

        [BindProperty]
        public string FullNames { get; set; }

        public string Messages { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var user = new User()
            {
                Email = Emails,
                Password = Passwords,
                Username = Usernames,
                FullName = FullNames,
                Role = "CUSTOMER"
            };
            await _user.Create(user);
            await _hubContext.Clients.All.SendAsync("LoadAdminDashboard");
            return RedirectToPage("/Login");
            
        }
    }
}
