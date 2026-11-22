using System.ComponentModel.DataAnnotations;
namespace SchoolAppCoreRazor.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [Range(0,20)]
        public int Credits { get; set; }
        [Display(Name="Department")]
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
