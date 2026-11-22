using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;

namespace SchoolAppCoreMVC.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;

        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Instructors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instructors.ToListAsync());
        }

        // GET: Instructors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Instructors.FirstOrDefaultAsync(m => m.InstructorID == id);
            if (item == null) return NotFound();

            return View(item);
        }

        // GET: Instructors/Create
        public IActionResult Create()
        {
            LoadLists(null);
            return View();
        }

        // POST: Instructors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,HireDate")] Instructor item)
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

        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Instructors.FindAsync(id);
            if (item == null) return NotFound();

            LoadLists(item);
            return View(item);
        }

        // POST: Instructors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorID,FirstName,LastName,HireDate")] Instructor item)
        {
            if (id != item.InstructorID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Instructors.Any(e => e.InstructorID == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            LoadLists(item);
            return View(item);
        }

        // GET: Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Instructors.FirstOrDefaultAsync(m => m.InstructorID == id);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Instructors.FindAsync(id);
            if (item != null)
            {
                try
                {
                    _context.Instructors.Remove(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    _context.ChangeTracker.Clear();
                    var again = await _context.Instructors.AsNoTracking().FirstOrDefaultAsync(m => m.InstructorID == id);
                    ViewData["Error"] = "Cannot delete this record because other records still reference it.";
                    return View("Delete", again);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private void LoadLists(Instructor? item)
        {
            // (khong co khoa ngoai)
        }
    }
}
