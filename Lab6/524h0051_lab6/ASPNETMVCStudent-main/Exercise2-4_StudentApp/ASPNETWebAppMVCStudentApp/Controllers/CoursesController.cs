using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using ASPNETWebAppMVCStudentApp.Models;

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolDBEntities db = new SchoolDBEntities();

        private Course Load(int? id)
        {
            return db.Courses.Include(x => x.Department).FirstOrDefault(x => x.CourseID == id);
        }

        private void Lists(Course m)
        {
            ViewBag.DepartmentID = new SelectList(db.Departments.ToList(), "DepartmentID", "Name", m == null ? null : (object)m.DepartmentID);
        }

        public ActionResult Index()
        {
            return View(db.Courses.Include(x => x.Department).ToList());
        }

        public ActionResult Details(int? id)
        {
            var m = Load(id);
            if (m == null) return HttpNotFound();
            return View(m);
        }

        public ActionResult Create()
        {
            Lists(null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Credits,DepartmentID")] Course model)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            Lists(model);
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            var m = Load(id);
            if (m == null) return HttpNotFound();
            Lists(m);
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")] Course model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            Lists(model);
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            var m = Load(id);
            if (m == null) return HttpNotFound();
            return View(m);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var m = Load(id);
            if (m == null) return HttpNotFound();
            try
            {
                db.Courses.Remove(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Cannot delete: this record is referenced by other records.");
                return View("Delete", m);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
