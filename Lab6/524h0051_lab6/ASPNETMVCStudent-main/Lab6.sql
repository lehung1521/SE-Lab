/* ===== Class activity: StudentsDB ===== */
IF DB_ID('StudentsDB') IS NULL CREATE DATABASE StudentsDB;
GO
USE StudentsDB;
GO
CREATE TABLE tblStudents (
  StudentID INT PRIMARY KEY IDENTITY(1,1),
  FirstName NVARCHAR(50) NOT NULL,
  LastName NVARCHAR(50) NOT NULL,
  Email NVARCHAR(100) NOT NULL,
  EnrollmentDate DATE NOT NULL
);
INSERT INTO tblStudents (FirstName, LastName, Email, EnrollmentDate) VALUES
('Trung','Pham','trung.pham@seuni.com','2024-01-15'),
('Michael','Pham','michael.pham@seuni.com','2024-02-20');
GO

/* ===== Exercise 2: SchoolDB ===== */
IF DB_ID('SchoolDB') IS NULL CREATE DATABASE SchoolDB;
GO
USE SchoolDB;
GO
CREATE TABLE Departments (
  DepartmentID INT PRIMARY KEY IDENTITY(1,1),
  Name NVARCHAR(50) NOT NULL,
  Budget DECIMAL(18,2) NOT NULL,
  StartDate DATE NOT NULL
);
CREATE TABLE Instructors (
  InstructorID INT PRIMARY KEY IDENTITY(1,1),
  FirstName NVARCHAR(50) NOT NULL,
  LastName NVARCHAR(50) NOT NULL,
  HireDate DATE NOT NULL
);
CREATE TABLE Courses (
  CourseID INT PRIMARY KEY IDENTITY(1,1),
  Title NVARCHAR(100) NOT NULL,
  Credits INT NOT NULL,
  DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID)
);
CREATE TABLE Students (
  StudentID INT PRIMARY KEY IDENTITY(1,1),
  FirstName NVARCHAR(50) NOT NULL,
  LastName NVARCHAR(50) NOT NULL,
  EnrollmentDate DATE NOT NULL
);
CREATE TABLE Enrollments (
  EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
  CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
  StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
  Grade DECIMAL(3,2)
);
INSERT INTO Departments (Name,Budget,StartDate) VALUES ('Computer Science',120000.00,'2023-01-01');
INSERT INTO Instructors (FirstName,LastName,HireDate) VALUES ('John','Doe','2020-08-15');
INSERT INTO Courses (Title,Credits,DepartmentID) VALUES ('Introduction to Programming',3,1),('Databases',3,1);
INSERT INTO Students (FirstName,LastName,EnrollmentDate) VALUES ('Jane','Smith','2023-09-01'),('Bob','Brown','2023-09-01'),('Alice','Johnson','2023-09-01');
INSERT INTO Enrollments (CourseID,StudentID,Grade) VALUES (1,1,3.5),(1,2,3.0),(1,3,3.8),(2,1,3.2);
GO

/* ===== Exercise 3: login (password stored as SHA-256 hash, never plain text) ===== */
CREATE TABLE tblUser (
  UserID INT PRIMARY KEY IDENTITY(1,1),
  Username NVARCHAR(50) NOT NULL UNIQUE,
  PasswordHash VARBINARY(32) NOT NULL,
  Email NVARCHAR(100) NOT NULL
);
-- login test: admin / Admin@123   (VARCHAR cast => same bytes as UTF-8 in C#)
INSERT INTO tblUser (Username,PasswordHash,Email) VALUES
('admin', HASHBYTES('SHA2_256', CAST('Admin@123' AS VARCHAR(50))), 'admin@school.com');
GO
