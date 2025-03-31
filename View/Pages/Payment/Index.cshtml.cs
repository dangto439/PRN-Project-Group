using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.Payment
{
    public class IndexModel : PageModel
    {
        private readonly IVnPay _vnPayService;
        private readonly ICourse _course;
        public IndexModel(IVnPay vnPayService, ICourse course)
        {
            _vnPayService = vnPayService;
            _course = course;
        }

        public Course Course { get; set; }
        public double Amount { get; set; }
        public async Task<IActionResult> OnGet(int? courseId)
        {
            if (courseId == null) return RedirectToPage("/Home/Index");

            Course = await _course.GetById(courseId.Value);
            if (Course == null) return RedirectToPage("/Home/Index");

            Amount = (double)Course.Price;
            return Page();
        }

        public IActionResult OnPost(double amount)
        {
            if (amount <= 0) return Page();
            PaymentInformationModel model = new PaymentInformationModel();
            model.OrderDescription = "thanh toán khóa học";
            model.Amount = amount;
            model.Name = "Khách hàng";
            model.OrderType = "VNPay";

            var paymentUrl = _vnPayService.CreatePaymentUrl(model,HttpContext);
            return Redirect(paymentUrl);
            //return Page();
        }
    }
}
