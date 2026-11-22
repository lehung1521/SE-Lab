using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETWebAppMVCStudentApp.Models
{
    [Table("Enrollments")]
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int? CourseID { get; set; }
        public int? StudentID { get; set; }

        [Range(typeof(decimal), "0", "4")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true, NullDisplayText = "")]
        public decimal? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
