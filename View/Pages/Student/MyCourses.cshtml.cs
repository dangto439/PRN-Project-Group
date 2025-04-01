using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.Student
{
    public class MyCoursesModel : PageModel
    {
        private readonly ICourse _course;
        public MyCoursesModel(ICourse course)
        {
            _course = course;
        }

        public List<Course> MyCourses { get; set; }
        public async Task OnGet(int courseId)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == null)
            {
                Response.Redirect("/AccessDenied");
            }
            MyCourses = await _course.GetEnroll();
        }
    }
}
