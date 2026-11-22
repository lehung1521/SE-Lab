using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;

namespace SchoolAppCoreMVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.Include(x => x.Department).ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Courses.Include(x => x.Department).FirstOrDefaultAsync(m => m.CourseID == id);
            if (item == null) return NotFound();

            return View(item);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            LoadLists(null);
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Credits,DepartmentID")] Course item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            LoadLists(item);
            return View(item);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Courses.FindAsync(id);
            if (item == null) return NotFound();

            LoadLists(item);
            return View(item);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,Title,Credits,DepartmentID")] Course item)
        {
            if (id != item.CourseID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Courses.Any(e => e.CourseID == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            LoadLists(item);
            return View(item);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Courses.Include(x => x.Department).FirstOrDefaultAsync(m => m.CourseID == id);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Courses.FindAsync(id);
            if (item != null)
            {
                try
                {
                    _context.Courses.Remove(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    _context.ChangeTracker.Clear();
                    var again = await _context.Courses.Include(x => x.Department).AsNoTracking().FirstOrDefaultAsync(m => m.CourseID == id);
                    ViewData["Error"] = "Cannot delete this record because other records still reference it.";
                    return View("Delete", again);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private void LoadLists(Course? item)
        {
            ViewData["DepartmentID"] = new SelectList(_context.Departments.Select(d => new { d.DepartmentID, DisplayText = d.DepartmentID + " - " + d.DepartmentName }).ToList(), "DepartmentID", "DisplayText", item?.DepartmentID);
        }
    }
}
