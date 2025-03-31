using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages.NewInformation
{
    public class NewsDetailModel : PageModel
    {
        private readonly INewsEvent _newsEvent;
        public NewsDetailModel(INewsEvent newsEvent)
        {
            _newsEvent = newsEvent;
        }
        public NewsEvent? News { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            News = await _newsEvent.GetById(id);
            if (News == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
