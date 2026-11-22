using System.Data.Entity;

namespace ASPNETWebAppMVCStudentApp.Models
{
    // Database First: ket noi vao CSDL SchoolDB co san (khong tao / sua CSDL)
    public class SchoolDBEntities : DbContext
    {
        public SchoolDBEntities() : base("name=SchoolDBEntities")
        {
            Database.SetInitializer<SchoolDBEntities>(null);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().Property(d => d.Budget).HasPrecision(18, 2);
            modelBuilder.Entity<Enrollment>().Property(e => e.Grade).HasPrecision(3, 2);
        }
    }
}
