using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

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

            return RedirectToPage("/Index");
        }
    }
}
