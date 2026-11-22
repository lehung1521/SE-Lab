# SE Lab 6 – ASP.NET MVC (.NET Framework 4.7.2) + Entity Framework 6

```
Lab6.sql                               <- chay trong SSMS truoc (tao StudentsDB, SchoolDB, tblUser + du lieu mau)
ClassActivity_StudentsApp/StudentsApp.sln          (Class activity: tblStudents, /Students)
Exercise2-4_StudentApp/StudentApp.sln              (Exercise 2 CRUD + 3 Login + 4 Report RDLC)
```

## Chay
1. SSMS: mo `Lab6.sql` > Execute.
2. Mo `StudentApp.sln` (hoac `StudentsApp.sln`) bang Visual Studio 2022 (workload ASP.NET + .NET Framework 4.7.2). Can internet de NuGet tu restore khi Build lan dau.
3. Sua `data source=` trong `Web.config` > `<connectionStrings>` cho dung server cua ban (`.\SQLEXPRESS`, `(localdb)\MSSQLLocalDB`, `(local)`).
4. **F5**. StudentApp mo trang **Login** (admin / Admin@123) > menu Departments, Instructors, Courses, Students, Enrollments, Student Report.

## Luu y
- Model dung EF 6 DbContext (`SchoolDBEntities`, `StudentsDBEntities`) map thang vao bang co san (khong tao/sua DB). Neu giang vien bat buoc file `.edmx`: xoa thu muc `Models/*.cs` + them *ADO.NET Entity Data Model > EF Designer from database* theo de, ten context giu nguyen.
- NuGet bao loi thieu ReportViewer: Package Manager Console > `Update-Package -reinstall`.
- Mo `Reports/StudentReport.rdlc` trong VS can extension *Microsoft RDLC Report Designer*.
- Report: dataset ten `StudentDataSet`, parameter `CourseTitle`; Print Preview mo PDF tab moi, Export to PDF tai file.
- Khong tao reset password (de ghi "hoac").

## Day len GitHub
Tao repo TRONG tren github.com (khong tick README/.gitignore), roi trong thu muc chua file `.sln`:
```bash
git init
git add .
git commit -m "Initial commit of ASP.NET MVC Student App"
git branch -M main
git remote add origin https://github.com/<username>/ASPNETWebAppMVCStudentApp.git
git push -u origin main
```
(Exercise 1: lam tuong tu voi `ClassActivity_StudentsApp`, repo `ASPNETMVCStudent`.) `.gitignore` da co san (bo bin/obj/packages).

## Nop bai
- `StudentID_StudentName.zip` = thu muc nay (da kem `.sql`). Doi ten file zip.
- `StudentID_StudentName.pdf` co bookmarks: Introduction, Exercises (screenshot danh so tung buoc + ket qua F5), Conclusion.
