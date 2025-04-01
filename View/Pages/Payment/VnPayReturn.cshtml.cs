using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.Payment
{
    public class VnPayReturnModel : PageModel
    {
        private readonly IEnrollment _enrollment;
        public VnPayReturnModel(IEnrollment enrollment)
        {
            _enrollment = enrollment;
        }
        public string Message { get; set; }
        public async Task OnGet()
        {
            var response = Request.Query;
            var vnp_ResponseCode = response["vnp_ResponseCode"];
            var courseId = HttpContext.Session.GetString("CourseId");

            if (vnp_ResponseCode == "00")
            {
                var studentId = HttpContext.Session.GetString("UserId");
                Enrollment item = new Enrollment()
                {
                    StudentId = int.Parse(studentId),
                    PaymentStatus = "Đã thanh toán",
                    CourseId = int.Parse(courseId),
                    Progress = 0
                };
                await _enrollment.Create(item);
                HttpContext.Session.Remove("CourseId");
                Message = "Thanh toán thành công!";
            }
            else
            {
                Message = "Thanh toán thất bại!";
            }
        }
    }
}
