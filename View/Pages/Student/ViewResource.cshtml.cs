using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Configuration;

namespace View.Pages.Student
{
    public class ViewResourceModel : PageModel
    {
        private readonly IResource _resource;
        private readonly IEnrollment _enrollment;
        public ViewResourceModel(IResource resource, IEnrollment enrollment)
        {
            _resource = resource;
            _enrollment = enrollment;
        }
        public Resource ResourceItem { get; set; }

        public async Task<IActionResult> OnGet(int resourceId)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == null)
            {
                Response.Redirect("/AccessDenied");
            }
            if (resourceId == null)
            {
                return NotFound();
            }
            ResourceItem = await _resource.GetById(resourceId);
            if (ResourceItem == null) 
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int resourceId)
        {
            var resourceItem = await _resource.GetById(resourceId);
            if (resourceItem == null)
            {
                return NotFound();
            }

            await _enrollment.UpdateProgress(resourceItem.CourseId);
            return RedirectToPage("/Student/CourseDetail", new { CourseId = resourceItem.CourseId });
        }
    }
}
