using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.Admin
{
    public class NewsManagementModel : PageModel
    {
        private readonly INewsEvent _newsEvent;
        public NewsManagementModel(INewsEvent newsEvent)
        {
            _newsEvent = newsEvent;
        }

        public List<NewsEvent> NewsList { get; set; }
        public async Task OnGet()
        {
            NewsList = await _newsEvent.Get();
        }
    }
}
