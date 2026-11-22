using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using StudentsApp.Models;

namespace StudentsApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsDBEntities db = new StudentsDBEntities();

        private tblStudent Load(int? id)
        {
            return db.tblStudents.FirstOrDefault(x => x.StudentID == id);
        }

        public ActionResult Index()
        {
            return View(db.tblStudents.ToList());
        }

        public ActionResult Details(int? id)
        {
            var m = Load(id);
            if (m == null) return HttpNotFound();
            return View(m);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Email,EnrollmentDate")] tblStudent model)
        {
            if (ModelState.IsValid)
            {
                db.tblStudents.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            var m = Load(id);
            if (m == null) return HttpNotFound();
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Email,EnrollmentDate")] tblStudent model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
                db.tblStudents.Remove(m);
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
