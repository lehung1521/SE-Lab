using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using ASPNETWebAppMVCStudentApp.Models;

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SchoolDBEntities db = new SchoolDBEntities();

        private Department Load(int? id)
        {
            return db.Departments.FirstOrDefault(x => x.DepartmentID == id);
        }

        public ActionResult Index()
        {
            return View(db.Departments.ToList());
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
        public ActionResult Create([Bind(Include = "Name,Budget,StartDate")] Department model)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(model);
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
        public ActionResult Edit([Bind(Include = "DepartmentID,Name,Budget,StartDate")] Department model)
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
                db.Departments.Remove(m);
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
