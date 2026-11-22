-- SchoolDB.sql  (SE Lab 7 - DB First)
-- Chay trong SQL Server Management Studio (SSMS)
IF DB_ID('SchoolDB') IS NULL
    CREATE DATABASE SchoolDB;
GO
USE SchoolDB;
GO

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Budget DECIMAL(18, 2) NOT NULL,
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
    Grade DECIMAL(3, 2)
);
GO

-- Sample data (5 dong dau theo de bai, them du lieu de bao cao dep hon)
INSERT INTO Departments (Name, Budget, StartDate) VALUES ('Computer Science', 120000.00, '2023-01-01');
INSERT INTO Departments (Name, Budget, StartDate) VALUES ('Mathematics', 90000.00, '2022-09-01');
INSERT INTO Departments (Name, Budget, StartDate) VALUES ('Physics', 75000.00, '2021-06-15');

INSERT INTO Instructors (FirstName, LastName, HireDate) VALUES ('John', 'Doe', '2020-08-15');
INSERT INTO Instructors (FirstName, LastName, HireDate) VALUES ('Mary', 'Johnson', '2019-03-10');
INSERT INTO Instructors (FirstName, LastName, HireDate) VALUES ('Peter', 'Nguyen', '2021-01-20');

INSERT INTO Courses (Title, Credits, DepartmentID) VALUES ('Introduction to Programming', 3, 1);
INSERT INTO Courses (Title, Credits, DepartmentID) VALUES ('Database Systems', 3, 1);
INSERT INTO Courses (Title, Credits, DepartmentID) VALUES ('Calculus I', 4, 2);
INSERT INTO Courses (Title, Credits, DepartmentID) VALUES ('Linear Algebra', 3, 2);
INSERT INTO Courses (Title, Credits, DepartmentID) VALUES ('General Physics', 4, 3);

INSERT INTO Students (FirstName, LastName, EnrollmentDate) VALUES ('Jane', 'Smith', '2023-09-01');
INSERT INTO Students (FirstName, LastName, EnrollmentDate) VALUES ('Minh', 'Tran', '2023-09-01');
INSERT INTO Students (FirstName, LastName, EnrollmentDate) VALUES ('Lan', 'Pham', '2024-02-15');
INSERT INTO Students (FirstName, LastName, EnrollmentDate) VALUES ('Huy', 'Le', '2024-09-01');

INSERT INTO Enrollments (CourseID, StudentID, Grade) VALUES (1, 1, 3.5);
INSERT INTO Enrollments (CourseID, StudentID, Grade) VALUES (2, 1, 3.8);
INSERT INTO Enrollments (CourseID, StudentID, Grade) VALUES (1, 2, 3.2);
INSERT INTO Enrollments (CourseID, StudentID, Grade) VALUES (3, 2, 2.9);
INSERT INTO Enrollments (CourseID, StudentID, Grade) VALUES (4, 3, 3.6);
INSERT INTO Enrollments (CourseID, StudentID, Grade) VALUES (5, 3, 3.1);
INSERT INTO Enrollments (CourseID, StudentID, Grade) VALUES (2, 4, 2.7);
INSERT INTO Enrollments (CourseID, StudentID, Grade) VALUES (3, 4, 3.4);
GO

SELECT * FROM Departments;
SELECT * FROM Instructors;
SELECT * FROM Courses;
SELECT * FROM Students;
SELECT * FROM Enrollments;
