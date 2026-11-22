using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolAppCoreRazor.Models;

#nullable disable
namespace SchoolAppCoreRazor.Migrations
{
    [DbContext(typeof(SchoolContext))]
    public partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");
            modelBuilder.Entity("SchoolAppCoreRazor.Models.Department", b => { b.Property<int>("DepartmentID").ValueGeneratedOnAdd().HasColumnType("int").HasAnnotation("SqlServer:Identity", "1, 1"); b.Property<decimal>("Budget").HasColumnType("decimal(18,2)"); b.Property<string>("DepartmentName").IsRequired().HasMaxLength(50); b.Property<DateTime>("StartDate").HasColumnType("date"); b.HasKey("DepartmentID"); b.ToTable("Departments"); });
            modelBuilder.Entity("SchoolAppCoreRazor.Models.Instructor", b => { b.Property<int>("InstructorID").ValueGeneratedOnAdd().HasAnnotation("SqlServer:Identity", "1, 1"); b.Property<string>("FirstName").IsRequired().HasMaxLength(50); b.Property<string>("LastName").IsRequired().HasMaxLength(50); b.Property<DateTime>("HireDate").HasColumnType("date"); b.HasKey("InstructorID"); b.ToTable("Instructors"); });
            modelBuilder.Entity("SchoolAppCoreRazor.Models.Student", b => { b.Property<int>("StudentID").ValueGeneratedOnAdd().HasAnnotation("SqlServer:Identity", "1, 1"); b.Property<string>("FirstName").IsRequired().HasMaxLength(50); b.Property<string>("LastName").IsRequired().HasMaxLength(50); b.Property<DateTime>("EnrollmentDate").HasColumnType("date"); b.HasKey("StudentID"); b.ToTable("Students"); });
            modelBuilder.Entity("SchoolAppCoreRazor.Models.Course", b => { b.Property<int>("CourseID").ValueGeneratedOnAdd().HasAnnotation("SqlServer:Identity", "1, 1"); b.Property<int>("Credits"); b.Property<int>("DepartmentID"); b.Property<string>("Title").IsRequired().HasMaxLength(100); b.HasKey("CourseID"); b.HasIndex("DepartmentID"); b.ToTable("Courses"); });
            modelBuilder.Entity("SchoolAppCoreRazor.Models.Enrollment", b => { b.Property<int>("EnrollmentID").ValueGeneratedOnAdd().HasAnnotation("SqlServer:Identity", "1, 1"); b.Property<int>("CourseID"); b.Property<int>("StudentID"); b.Property<decimal>("Grade").HasColumnType("decimal(3,2)"); b.HasKey("EnrollmentID"); b.HasIndex("CourseID"); b.HasIndex("StudentID"); b.ToTable("Enrollments"); });
            modelBuilder.Entity("SchoolAppCoreRazor.Models.Course", b => { b.HasOne("SchoolAppCoreRazor.Models.Department", "Department").WithMany("Courses").HasForeignKey("DepartmentID").OnDelete(DeleteBehavior.Cascade).IsRequired(); b.Navigation("Department"); });
            modelBuilder.Entity("SchoolAppCoreRazor.Models.Enrollment", b => { b.HasOne("SchoolAppCoreRazor.Models.Course", "Course").WithMany("Enrollments").HasForeignKey("CourseID").OnDelete(DeleteBehavior.Cascade).IsRequired(); b.HasOne("SchoolAppCoreRazor.Models.Student", "Student").WithMany("Enrollments").HasForeignKey("StudentID").OnDelete(DeleteBehavior.Cascade).IsRequired(); b.Navigation("Course"); b.Navigation("Student"); });
        }
    }
}
