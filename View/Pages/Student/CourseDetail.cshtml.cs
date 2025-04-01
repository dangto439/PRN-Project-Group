using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages.Student
{
    public class CourseDetailModel : PageModel
    {
        private readonly ICourse _course;
        private readonly IResource _resource;
        private readonly IEnrollment _enrollment;

        public CourseDetailModel(ICourse course, IResource resource, IEnrollment enrollment)
        {
            _course = course;
            _resource = resource;
            _enrollment = enrollment;
        }
        public Course Course { get; set; }
        public List<Resource> Resources { get; set; }
        public int Percent { get; set; }
        public async Task<IActionResult> OnGet(int? CourseId)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == null)
            {
                Response.Redirect("/AccessDenied");
            }
            if (CourseId == null)
            {
                return NotFound("Khóa học không tồn tại.");
            }

            Course = await _course.GetById(CourseId.Value);
            if (Course == null)
            {
                return NotFound("Không tìm thấy thông tin khóa học.");
            }

            Resources = await _resource.GetByCourseId(CourseId.Value);
            var enrollmentItem = await _enrollment.GetByCourseId(CourseId.Value);
            if (enrollmentItem == null)
            {
                return NotFound("Bạn chưa mua khóa học này");
            }
            Percent = enrollmentItem.Progress;
            return Page();
        }

    }
}
