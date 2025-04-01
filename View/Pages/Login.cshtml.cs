using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace View.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUser _iUser;
        public LoginModel(IUser iUser)
        {
            _iUser = iUser;
        }
        public string Message { get; set; }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Message = "Vui lòng nhập đầy đủ thông tin.";
                return Page();
            }

            var user = await _iUser.Login(Username, Password);

            if (user == null)
            {
                Message = "Sai tên đăng nhập hoặc mật khẩu.";
                return Page();
            }
            HttpContext.Session.SetString("UserRole", user.Role);
            HttpContext.Session.SetString("UserName", user.FullName);
            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            if (user.Role == "ADMIN")
            {
                return RedirectToPage("/Admin/Dashboard");
            }
            if (user.Role == "LECTURER")
            {
                return RedirectToPage("/Lecturer/CourseManagement");
            }

            return RedirectToPage("/Home/Index");
        }
    }
}
