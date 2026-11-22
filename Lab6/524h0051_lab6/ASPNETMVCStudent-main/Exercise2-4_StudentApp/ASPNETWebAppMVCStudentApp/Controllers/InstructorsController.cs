using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using ASPNETWebAppMVCStudentApp.Models;

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolDBEntities db = new SchoolDBEntities();

        private Instructor Load(int? id)
        {
            return db.Instructors.FirstOrDefault(x => x.InstructorID == id);
        }

        public ActionResult Index()
        {
            return View(db.Instructors.ToList());
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
        public ActionResult Create([Bind(Include = "FirstName,LastName,HireDate")] Instructor model)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Add(model);
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
        public ActionResult Edit([Bind(Include = "InstructorID,FirstName,LastName,HireDate")] Instructor model)
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
                db.Instructors.Remove(m);
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
