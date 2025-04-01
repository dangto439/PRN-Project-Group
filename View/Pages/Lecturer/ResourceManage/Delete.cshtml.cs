using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;

namespace View.Pages.Lecturer.ResourceManage
{
    public class DeleteModel : PageModel
    {
        private readonly IResource _resourceService;

        public DeleteModel(IResource resource)
        {
            _resourceService = resource;
        }

        [BindProperty]
        public Resource Resource { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "LECTURER")
            {
                return RedirectToPage("/AccessDenied");
            }
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _resourceService.GetById(id.Value);

            if (resource == null)
            {
                return NotFound();
            }
            else
            {
                Resource = resource;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _resourceService.GetById(id.Value);
            if (resource != null)
            {
                Resource = resource;
                await _resourceService.Delete(Resource.ResourceId);
            }

            return RedirectToPage("/Lecturer/ResourceManagement");
        }
    }
}
