using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages.Lecturer
{
    public class CourseManagementModel : PageModel
    {
        private readonly ICourse _course;
        public CourseManagementModel(ICourse course)
        {
            _course = course;
        }

        public List<Course> CourseList { get; set; }
        public async Task OnGet()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "LECTURER")
            {
                Response.Redirect("/AccessDenied");
            }
            CourseList = await _course.Get();
        }
    }
}
