using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using ASPNETWebAppMVCStudentApp.Models;

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly SchoolDBEntities db = new SchoolDBEntities();

        private Enrollment Load(int? id)
        {
            return db.Enrollments.Include(x => x.Course).Include(x => x.Student).FirstOrDefault(x => x.EnrollmentID == id);
        }

        private void Lists(Enrollment m)
        {
            ViewBag.CourseID = new SelectList(db.Courses.ToList(), "CourseID", "Title", m == null ? null : (object)m.CourseID);
            ViewBag.StudentID = new SelectList(db.Students.ToList(), "StudentID", "FullName", m == null ? null : (object)m.StudentID);
        }

        public ActionResult Index()
        {
            return View(db.Enrollments.Include(x => x.Course).Include(x => x.Student).ToList());
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
        public ActionResult Create([Bind(Include = "CourseID,StudentID,Grade")] Enrollment model)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(model);
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
        public ActionResult Edit([Bind(Include = "EnrollmentID,CourseID,StudentID,Grade")] Enrollment model)
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
                db.Enrollments.Remove(m);
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
