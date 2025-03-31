using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ICourse _ICourse;
        private readonly IUser _IUser;
        public DetailsModel(ICourse course,IUser user)
        {
            _ICourse = course;
            _IUser = user;
        }
        public Course Course { get; set; }
        public string TeacherName { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Course = await _ICourse.GetById(id);
            if (Course == null)
            {
                return NotFound();
            }
            var user = await _IUser.GetById(Course.CreatedBy);
            TeacherName = user.FullName;
            return Page();
        }
    }
}
