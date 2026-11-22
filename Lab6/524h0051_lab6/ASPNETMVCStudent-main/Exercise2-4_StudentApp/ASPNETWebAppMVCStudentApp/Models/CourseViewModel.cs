using System.Collections.Generic;
using System.Web.Mvc;

namespace ASPNETWebAppMVCStudentApp.Models
{
    public class CourseViewModel
    {
        public int SelectedCourseID { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; }
    }
}
