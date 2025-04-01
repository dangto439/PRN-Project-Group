using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;

namespace View.Pages.Admin.News
{
    public class CreateModel : PageModel
    {
        private readonly INewsEvent _newsEvent;

        public CreateModel(INewsEvent newsEvent)
        {
            _newsEvent = newsEvent;
        }

        public IActionResult OnGet()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "ADMIN")
            {
                return RedirectToPage("/AccessDenied");
            }
            return Page();
        }

        [BindProperty]
        public NewsEvent NewsEvent { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            NewsEvent.CreatedBy = 1;
            await _newsEvent.Create(NewsEvent);
            return RedirectToPage("/Admin/NewsManagement");
        }
    }
}
