using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace View.Pages.Lecturer
{
    public class ResourceManagementModel : PageModel
    {
        private readonly IResource _resource;
       public ResourceManagementModel (IResource resource)
        {
            _resource = resource;
        }
        public List<Resource> ResourceList { get; set; }
        public async Task OnGet()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "LECTURER")
            {
                Response.Redirect("/AccessDenied");
            }
            ResourceList = await _resource.Get();
        }
    }
}
