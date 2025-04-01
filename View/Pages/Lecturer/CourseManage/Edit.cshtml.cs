using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;

namespace View.Pages.Lecturer.CourseManage
{
    public class EditModel : PageModel
    {
        private readonly ICourse _course;

        public EditModel(ICourse course)
        {
            _course = course;
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
            Course = course;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var course = await _course.GetById(Course.CourseId);
            if (course == null)
            {
                return NotFound();
            }
            course.ImageUrl = Course.ImageUrl;
            course.CourseName = Course.CourseName;
            course.Description = Course.Description;
            course.Type = Course.Type;
            course.Price = Course.Price;
            await _course.Update(course);
            return RedirectToPage("/Lecturer/CourseManagement");
        }
    }
}
