using System.Linq;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using ASPNETWebAppMVCStudentApp.Models;

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly SchoolDBEntities db = new SchoolDBEntities();

        public ActionResult Index()
        {
            return View(new CourseViewModel
            {
                Courses = new SelectList(db.Courses.ToList(), "CourseID", "Title")
            });
        }

        [HttpPost]
        public ActionResult Generate(int selectedCourseID, string action)
        {
            var course = db.Courses.Find(selectedCourseID);
            if (course == null) return HttpNotFound();

            var rows = db.Enrollments
                .Where(e => e.CourseID == selectedCourseID)
                .Select(e => new StudentReportRow
                {
                    StudentID = e.Student.StudentID,
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName,
                    Grade = e.Grade
                }).ToList();

            var report = new LocalReport { ReportPath = Server.MapPath("~/Reports/StudentReport.rdlc") };
            report.DataSources.Add(new ReportDataSource("StudentDataSet", rows));
            report.SetParameters(new ReportParameter("CourseTitle", course.Title));
            byte[] pdf = report.Render("PDF");

            // preview: mo PDF ngay tren trinh duyet; export: tai file ve
            if (action == "export")
                return File(pdf, "application/pdf", "StudentReport.pdf");
            return File(pdf, "application/pdf");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
