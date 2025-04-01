using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace View.Pages.Admin.News
{
    public class EditModel : PageModel
    {
        private readonly INewsEvent _newsEvent;

        public EditModel(INewsEvent newsEvent)
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

            var newsevent =  await _newsEvent.GetById(id.Value);
            if (newsevent == null)
            {
                return NotFound();
            }
            NewsEvent = newsevent;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newsevent = await _newsEvent.GetById(NewsEvent.NewsId);
            if (newsevent == null)
            {
                return NotFound();
            }
            newsevent.Title = NewsEvent.Title;
            newsevent.Content = NewsEvent.Content;
            newsevent.Category = NewsEvent.Category;
            newsevent.EventDate = NewsEvent.EventDate;
            await _newsEvent.Update(newsevent);

            return RedirectToPage("/Admin/NewsManagement");
        }
    }
}
