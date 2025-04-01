using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        [BindProperty (SupportsGet = true)]
        public string Search { get; set; }
        public async Task OnGet()
        {
            if (String.IsNullOrEmpty(Search))
            {
                Users = await _userService.Get();
            } else
            {
                Users = await _userService.GetByEmail(Search);
            }
            
        }
    }
}
