using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;

        public CreateModel(SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Item { get; set; } = new Course();
        public SelectList? DepartmentList { get; set; }

        public void OnGet()
        {
            LoadLists();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadLists();
                return Page();
            }

            _context.Courses.Add(Item);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private void LoadLists()
        {
        DepartmentList = new SelectList(_context.Departments.Select(d => new { d.DepartmentID, DisplayText = d.DepartmentID + " - " + d.DepartmentName }).ToList(), "DepartmentID", "DisplayText", Item.DepartmentID);
        }
    }
}
