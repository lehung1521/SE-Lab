using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAppCoreRazor.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required, StringLength(50)]
        public string DepartmentName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; }
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
