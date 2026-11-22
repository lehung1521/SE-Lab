using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;

namespace SchoolAppCoreMVC.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly SchoolContext _context;

        public EnrollmentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enrollments.Include(x => x.Course).Include(x => x.Student).ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Enrollments.Include(x => x.Course).Include(x => x.Student).FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (item == null) return NotFound();

            return View(item);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            LoadLists(null);
            return View();
        }

        // POST: Enrollments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,StudentID,Grade")] Enrollment item)
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

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Enrollments.FindAsync(id);
            if (item == null) return NotFound();

            LoadLists(item);
            return View(item);
        }

        // POST: Enrollments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentID,CourseID,StudentID,Grade")] Enrollment item)
        {
            if (id != item.EnrollmentID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Enrollments.Any(e => e.EnrollmentID == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            LoadLists(item);
            return View(item);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Enrollments.Include(x => x.Course).Include(x => x.Student).FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Enrollments.FindAsync(id);
            if (item != null)
            {
                try
                {
                    _context.Enrollments.Remove(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    _context.ChangeTracker.Clear();
                    var again = await _context.Enrollments.Include(x => x.Course).Include(x => x.Student).AsNoTracking().FirstOrDefaultAsync(m => m.EnrollmentID == id);
                    ViewData["Error"] = "Cannot delete this record because other records still reference it.";
                    return View("Delete", again);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private void LoadLists(Enrollment? item)
        {
            ViewData["CourseID"] = new SelectList(_context.Courses.ToList(), "CourseID", "Title", item?.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students.ToList(), "StudentID", "FullName", item?.StudentID);
        }
    }
}
