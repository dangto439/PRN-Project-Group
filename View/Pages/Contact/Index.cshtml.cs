using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace View.Pages.Contact
{
    public class IndexModel : PageModel
    {
        private readonly IContact _contact;
        public IndexModel(IContact contact)
        {
            _contact = contact;
        }
        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Message { get; set; }

        public string SuccessMessage { get; set; }
        public void OnGet()
        {
        }
        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                var contact = new DataAccessLayer.Entity.Contact
                {
                    Name = Name,
                    Email = Email,
                    Message = Message
                };

                // Lưu thông tin vào cơ sở dữ liệu
                await _contact.Create(contact);
                SuccessMessage = "Cảm ơn bạn đã liên hệ! Chúng tôi sẽ phản hồi sớm nhất.";
            }
        }
    }
}
