using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly IUser _user;
        private readonly IProject _project;
        private readonly ICourse _course;
        private readonly INewsEvent _newsEvent;
        public DashboardModel(IUser user, IProject project, ICourse course, INewsEvent newsEvent)
        {
            _user = user;
            _project = project;
            _course = course;
            _newsEvent = newsEvent;
        }
        public int TotalUsers { get; set; }
        public int TotalProjects { get; set; }
        public int TotalNews { get; set; }
        public int TotalCourses { get; set; }
        public int TotalTeachers { get; set; }
        public int TotalStudents { get; set; }

        public async Task OnGet()
        {
            TotalUsers = await _user.CoutUser();
            TotalTeachers = await _user.CoutLecturer();
            TotalStudents = await _user.CoutCustomer();
            TotalProjects = await _project.CoutProject();
            TotalCourses = await _course.CountCourse();
            TotalNews = await _newsEvent.CountNews();
        }
    }
}
