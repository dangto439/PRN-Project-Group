using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly ICourse _iCourse;
        public IndexModel(ICourse course)
        {
            _iCourse = course;
        }

        public List<Course> Courses { get; set; } = new();
        public async Task OnGet()
        {
            Courses = await _iCourse.Get();
        }
    }
}
