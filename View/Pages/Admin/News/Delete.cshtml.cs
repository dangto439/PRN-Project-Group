using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;

namespace View.Pages.Admin.News
{
    public class DeleteModel : PageModel
    {
        private readonly INewsEvent _newsEvent;

        public DeleteModel(INewsEvent newsEvent)
        {
            _newsEvent = newsEvent;
        }

        [BindProperty]
        public NewsEvent NewsEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsevent = await _newsEvent.GetById(id.Value);

            if (newsevent == null)
            {
                return NotFound();
            }
            else
            {
                NewsEvent = newsevent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsevent = await _newsEvent.GetById(id.Value);
            if (newsevent != null)
            {
                NewsEvent = newsevent;
                await _newsEvent.Delete(id.Value);
            }

            return RedirectToPage("/Admin/NewsManagement");
        }
    }
}
