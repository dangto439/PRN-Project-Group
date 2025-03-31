using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.Admin
{
    public class UserManagementModel : PageModel
    {
        private readonly IUser _userService;

        public UserManagementModel(IUser userService)
        {
            _userService = userService;
        }

        public List<User> Users { get; set; }

        public async Task OnGet()
        {
            Users = await _userService.Get();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostUpdateRole(int userId, string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                return new JsonResult(new { success = false, message = "Vai trò không hợp lệ" });
            }

            var user = await _userService.GetById(userId);
            if (user == null)
            {
                return new JsonResult(new { success = false, message = "Không tìm thấy user" });
            }

            user.Role = role;
            await _userService.Update(user);
            return new JsonResult(new { success = true, message = "Cập nhật thành công" });

        }
    }
}
