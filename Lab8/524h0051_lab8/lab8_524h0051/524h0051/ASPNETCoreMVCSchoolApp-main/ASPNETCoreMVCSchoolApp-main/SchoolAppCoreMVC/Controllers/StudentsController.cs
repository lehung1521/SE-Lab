using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;

namespace SchoolAppCoreMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            if (item == null) return NotFound();

            return View(item);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            LoadLists(null);
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,EnrollmentDate")] Student item)
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

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Students.FindAsync(id);
            if (item == null) return NotFound();

            LoadLists(item);
            return View(item);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,FirstName,LastName,EnrollmentDate")] Student item)
        {
            if (id != item.StudentID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Students.Any(e => e.StudentID == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            LoadLists(item);
            return View(item);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Students.FindAsync(id);
            if (item != null)
            {
                try
                {
                    _context.Students.Remove(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    _context.ChangeTracker.Clear();
                    var again = await _context.Students.AsNoTracking().FirstOrDefaultAsync(m => m.StudentID == id);
                    ViewData["Error"] = "Cannot delete this record because other records still reference it.";
                    return View("Delete", again);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private void LoadLists(Student? item)
        {
            // (khong co khoa ngoai)
        }
    }
}
