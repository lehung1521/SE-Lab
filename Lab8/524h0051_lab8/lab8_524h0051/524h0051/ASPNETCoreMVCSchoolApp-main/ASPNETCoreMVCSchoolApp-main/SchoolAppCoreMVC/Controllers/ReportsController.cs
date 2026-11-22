using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;
using SchoolAppCoreMVC.Services;

namespace SchoolAppCoreMVC.Controllers
{
    public class ReportsController : Controller
    {
        private readonly SchoolContext _context;
        private readonly EnrollmentReportService _report;

        public ReportsController(SchoolContext context, EnrollmentReportService report)
        {
            _context = context;
            _report = report;
        }

        // Form chon bo loc + nut xem bao cao
        public async Task<IActionResult> Index(int? departmentId, bool show = false)
        {
            ViewBag.Departments = new SelectList(await _context.Departments.ToListAsync(), "DepartmentID", "DepartmentName", departmentId);
            ViewBag.DepartmentId = departmentId;
            ViewBag.Show = show;
            return View();
        }

        public async Task<IActionResult> Pdf(int? departmentId)
        {
            var bytes = await _report.RenderAsync(departmentId, "PDF");
            return File(bytes, "application/pdf");
        }

        public async Task<IActionResult> Excel(int? departmentId)
        {
            var bytes = await _report.RenderAsync(departmentId, "EXCELOPENXML");
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EnrollmentReport.xlsx");
        }

        public async Task<IActionResult> Word(int? departmentId)
        {
            var bytes = await _report.RenderAsync(departmentId, "WORDOPENXML");
            return File(bytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "EnrollmentReport.docx");
        }
    }
}
