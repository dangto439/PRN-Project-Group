using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace View.Pages.Lecturer.CourseManage
{
    public class CreateModel : PageModel
    {
        private readonly ICourse _course;
        private readonly IHubContext<SignalRAdmin> _hubContext;

        public CreateModel(ICourse course, IHubContext<SignalRAdmin> hubContext)
        {
            _course = course;
            _hubContext = hubContext;
        }

        public IActionResult OnGet()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "LECTURER")
            {
                return RedirectToPage("/AccessDenied");
            }
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userId = HttpContext.Session.GetString("UserId");
            if (userId == null) 
            {
                return Page();
            }
            Course.CreatedBy = int.Parse(userId);
            await _course.Create(Course);
            await _hubContext.Clients.All.SendAsync("LoadAdminDashboard");
            return RedirectToPage("/Lecturer/CourseManagement");
        }
    }
}
