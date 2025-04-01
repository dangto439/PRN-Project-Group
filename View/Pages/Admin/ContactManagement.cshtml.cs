using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages.Admin
{
    public class ContactManagementModel : PageModel
    {
        private readonly IContact _contact;
        
        public ContactManagementModel(IContact contact)
        {
            _contact = contact;
            Contacts = new List<DataAccessLayer.Entity.Contact>();
        }
        public List<DataAccessLayer.Entity.Contact> Contacts { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }
        public async Task OnGet()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "ADMIN")
            {
                Response.Redirect("/AccessDenied");
            }
            if (String.IsNullOrEmpty(Search))
            {
                Contacts = await _contact.Get();
            }
            else
            {
                Contacts = await _contact.GetByEmail(Search);
            }
        }
    }
}
