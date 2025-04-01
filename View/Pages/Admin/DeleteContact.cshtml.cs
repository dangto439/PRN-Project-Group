using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages.Admin
{
    public class DeleteContactModel : PageModel
    {
        private readonly IContact _contact;
        public DeleteContactModel(IContact contact)
        {
            _contact = contact;
            Contact = new DataAccessLayer.Entity.Contact();

        }

        [BindProperty]
        public DataAccessLayer.Entity.Contact Contact { get; set; } = default!;
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contact.GetById(id.Value);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                Contact = contact;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contact.GetById(id.Value);
            if (contact != null)
            {
                Contact = contact;
                await _contact.Delete(id.Value);
            }

            return RedirectToPage("/Admin/ContactManagement");
        }
    }
}
