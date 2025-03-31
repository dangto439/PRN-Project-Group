using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.NewInformation
{
    public class IndexModel : PageModel
    {
        private readonly INewsEvent _newsEvent;
        public IndexModel(INewsEvent newsEvent)
        {
            _newsEvent = newsEvent;
        }
        public List<NewsEvent> NewsList { get; set; } = new();

        public async Task OnGet()
        {
            NewsList = await _newsEvent.Get();
        }
    }
}
