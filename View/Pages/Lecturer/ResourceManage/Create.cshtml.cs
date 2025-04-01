using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Entity;
using BusinessLogicLayer.Interfaces;

namespace View.Pages.Lecturer.ResourceManage
{
    public class CreateModel : PageModel
    {
        private readonly IResource _resourceService;
        private readonly ICourse _courseService;

        public CreateModel(IResource resourceService, ICourse courseService)
        {
            _resourceService = resourceService;
            _courseService = courseService;
        }

        public async Task<IActionResult> OnGet()
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

            return Page();
        }

        [BindProperty]
        public Resource Resource { get; set; } = default!;
        public List<SelectListItem> CourseList { get; set; } = default!;


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
            var userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                return Page();
            }
            Resource.CreatedBy = int.Parse(userId);
            await _resourceService.Create(Resource);

            return RedirectToPage("/Lecturer/ResourceManagement");
        }
    }
}
