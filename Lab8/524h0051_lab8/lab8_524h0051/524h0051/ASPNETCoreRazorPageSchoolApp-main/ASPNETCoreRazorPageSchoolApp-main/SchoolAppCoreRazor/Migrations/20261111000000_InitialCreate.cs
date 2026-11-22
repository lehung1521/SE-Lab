using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolAppCoreRazor.Models;

#nullable disable
namespace SchoolAppCoreRazor.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20261111000000_InitialCreate")]
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Departments", columns: table => new
            {
                DepartmentID = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                StartDate = table.Column<DateTime>(type: "date", nullable: false)
            }, constraints: table => table.PrimaryKey("PK_Departments", x => x.DepartmentID));
            migrationBuilder.CreateTable(name: "Instructors", columns: table => new
            {
                InstructorID = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                HireDate = table.Column<DateTime>(type: "date", nullable: false)
            }, constraints: table => table.PrimaryKey("PK_Instructors", x => x.InstructorID));
            migrationBuilder.CreateTable(name: "Students", columns: table => new
            {
                StudentID = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                EnrollmentDate = table.Column<DateTime>(type: "date", nullable: false)
            }, constraints: table => table.PrimaryKey("PK_Students", x => x.StudentID));
            migrationBuilder.CreateTable(name: "Courses", columns: table => new
            {
                CourseID = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Credits = table.Column<int>(type: "int", nullable: false),
                DepartmentID = table.Column<int>(type: "int", nullable: false)
            }, constraints: table => { table.PrimaryKey("PK_Courses", x => x.CourseID); table.ForeignKey("FK_Courses_Departments_DepartmentID", x => x.DepartmentID, "Departments", "DepartmentID", onDelete: ReferentialAction.Cascade); });
            migrationBuilder.CreateTable(name: "Enrollments", columns: table => new
            {
                EnrollmentID = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                CourseID = table.Column<int>(type: "int", nullable: false),
                StudentID = table.Column<int>(type: "int", nullable: false),
                Grade = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
            }, constraints: table => { table.PrimaryKey("PK_Enrollments", x => x.EnrollmentID); table.ForeignKey("FK_Enrollments_Courses_CourseID", x => x.CourseID, "Courses", "CourseID", onDelete: ReferentialAction.Cascade); table.ForeignKey("FK_Enrollments_Students_StudentID", x => x.StudentID, "Students", "StudentID", onDelete: ReferentialAction.Cascade); });
            migrationBuilder.CreateIndex(name: "IX_Courses_DepartmentID", table: "Courses", column: "DepartmentID");
            migrationBuilder.CreateIndex(name: "IX_Enrollments_CourseID", table: "Enrollments", column: "CourseID");
            migrationBuilder.CreateIndex(name: "IX_Enrollments_StudentID", table: "Enrollments", column: "StudentID");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Enrollments");
            migrationBuilder.DropTable(name: "Instructors");
            migrationBuilder.DropTable(name: "Courses");
            migrationBuilder.DropTable(name: "Students");
            migrationBuilder.DropTable(name: "Departments");
        }
    }
}
