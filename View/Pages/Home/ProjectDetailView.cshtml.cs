using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.Home
{
    public class ProjectDetailViewModel : PageModel
    {
        private readonly IProject _project;
        public ProjectDetailViewModel(IProject project)
        {
            _project = project;
        }
        public Project Projects { get; set; }
        public async Task OnGet(int id)
        {
            Projects = await _project.GetById(id);
        }
    }
}
