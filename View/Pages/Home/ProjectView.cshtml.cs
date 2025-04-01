using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.Home
{
    public class ProjectViewModel : PageModel
    {
        private readonly IProject _project;
        public ProjectViewModel(IProject project)
        {
            _project = project;
        }
        public List<Project> ProjectList { get; set; }
        public async Task OnGet()
        {
            ProjectList = await _project.Get();
        }
    }
}
