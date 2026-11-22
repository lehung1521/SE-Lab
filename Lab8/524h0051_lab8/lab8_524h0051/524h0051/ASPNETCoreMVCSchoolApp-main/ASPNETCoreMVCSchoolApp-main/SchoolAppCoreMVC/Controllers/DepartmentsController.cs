using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;

namespace SchoolAppCoreMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SchoolContext _context;

        public DepartmentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (item == null) return NotFound();

            return View(item);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            LoadLists(null);
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentName,Budget,StartDate")] Department item)
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

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Departments.FindAsync(id);
            if (item == null) return NotFound();

            LoadLists(item);
            return View(item);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentID,DepartmentName,Budget,StartDate")] Department item)
        {
            if (id != item.DepartmentID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Departments.Any(e => e.DepartmentID == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            LoadLists(item);
            return View(item);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Departments.FindAsync(id);
            if (item != null)
            {
                try
                {
                    _context.Departments.Remove(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    _context.ChangeTracker.Clear();
                    var again = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(m => m.DepartmentID == id);
                    ViewData["Error"] = "Cannot delete this record because other records still reference it.";
                    return View("Delete", again);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private void LoadLists(Department? item)
        {
            // (khong co khoa ngoai)
        }
    }
}
