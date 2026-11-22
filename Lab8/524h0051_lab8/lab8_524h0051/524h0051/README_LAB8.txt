LAB 8 - ASP.NET CORE CODE FIRST - 2 DU AN

1. Exercise 1: StudentID_StudentName/ASPNETCoreRazorPageSchoolApp/SchoolAppCoreRazor.sln
   Database: SchoolDBRazor
2. Exercise 2: StudentID_StudentName/ASPNETCoreMVCSchoolApp/SchoolAppCoreMVC.sln
   Database: SchoolDBMVC

YEU CAU: Visual Studio 2022, .NET 8 SDK, SQL Server Express (SQLEXPRESS), Entity Framework Core 8.
- Mo tung solution trong Visual Studio, Restore NuGet packages, Build Solution.
- Kiem tra appsettings.json -> SchoolDBConnectionString theo ten SQL Server tren may.
- Tools > NuGet Package Manager > Package Manager Console, chon project hien tai.
- Chay Update-Database (InitialCreate migration DA DUOC THEM).
- F5 va thu CRUD cho Departments, Students, Courses, Instructors, Enrollments.
- Them Department truoc khi them Course; them Course va Student truoc khi them Enrollment.
- Department dropdown tren Create/Edit Course hien 'ID - DepartmentName'.

IMPORTANT: SQL script SchoolDB.sql trong ZIP goc la LAB 7 DATABASE FIRST, KHONG dung script do de tao SchoolDBRazor/SchoolDBMVC.
Lab 8 dung EF Core migration Update-Database de tao bang tu model C#.
Migrations duoc tao theo yeu cau bai, nhung chua the xac nhan dotnet build / update database tren may chu vi moi truong hien tai khong co .NET SDK va SQL Server.

Exercise 3: Can day ca hai project len GitHub bang tai khoan cua ban; khong the push tu ZIP.
Bao cao PDF ban dau trong ZIP la ban cu, can cap nhat anh minh chung Lab 8, ket qua F5 va GitHub URL de nop theo PDF huong dan.
