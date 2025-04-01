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

namespace View.Pages.Lecturer.ResourceManage
{
    public class EditModel : PageModel
    {
        private readonly IResource _resourceService;
        private readonly ICourse _courseService;

        public EditModel(IResource resourceService, ICourse courseService)
        {
            _resourceService = resourceService;
            _courseService = courseService;
        }

        [BindProperty]
        public Resource Resource { get; set; } = default!;
        public List<SelectListItem> CourseList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "LECTURER")
            {
                return RedirectToPage("/AccessDenied");
            }
            var courseList = await _courseService.Get();
            CourseList = courseList.Select(c => new SelectListItem
            {
                Value = c.CourseId.ToString(),
                Text = c.CourseName
            }).ToList();
            if (id == null)
            {
                return NotFound();
            }

            var resource =  await _resourceService.GetById(id.Value);
            if (resource == null)
            {
                return NotFound();
            }
            Resource = resource;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var courseList = await _courseService.Get();
            CourseList = courseList.Select(c => new SelectListItem
            {
                Value = c.CourseId.ToString(),
                Text = c.CourseName
            }).ToList();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var resource = await _resourceService.GetById(Resource.ResourceId);
            if (resource == null)
            {
                return NotFound();
            }
            resource.CourseId = Resource.CourseId;
            resource.ResourceName = Resource.ResourceName;
            resource.ResourceType = Resource.ResourceType;
            resource.FileUrl = Resource.FileUrl;
            await _resourceService.Update(resource);
            return RedirectToPage("/Lecturer/ResourceManagement");
        }
    }
}
