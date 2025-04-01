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

namespace View.Pages.Lecturer.CourseManage
{
    public class DeleteModel : PageModel
    {
        private readonly ICourse _course;
        private readonly IHubContext<SignalRAdmin> _hubContext;

        public DeleteModel(ICourse course, IHubContext<SignalRAdmin> hubContext)
        {
            _course = course;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "LECTURER")
            {
                return RedirectToPage("/AccessDenied");
            }
            if (id == null)
            {
                return NotFound();
            }

            var course = await _course.GetById(id.Value);

            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Course = course;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _course.GetById(id.Value);
            if (course != null)
            {
                Course = course;
                await _course.Delete(Course.CourseId);
            }
            await _hubContext.Clients.All.SendAsync("LoadAdminDashboard");
            return RedirectToPage("/Lecturer/CourseManagement");
        }
    }
}
