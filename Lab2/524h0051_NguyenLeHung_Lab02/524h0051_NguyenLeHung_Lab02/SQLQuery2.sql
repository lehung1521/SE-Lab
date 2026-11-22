USE master;
GO

IF DB_ID('SchoolDB') IS NULL
BEGIN
    CREATE DATABASE SchoolDB;
END
GO

USE SchoolDB;
GO





IF OBJECT_ID('dbo.tblStudents', 'U') IS NULL
BEGIN
    CREATE TABLE tblStudents
    (
        StudentID INT PRIMARY KEY IDENTITY(1,1),
        StudentName NVARCHAR(100) NOT NULL,
        DateOfBirth DATE NOT NULL,
        City NVARCHAR(50) NOT NULL,
        Age INT NOT NULL,
        YearOfEnroll INT NOT NULL,
        Major NVARCHAR(50),
        GPA DECIMAL(3,2)
    );

    INSERT INTO tblStudents
    (StudentName, DateOfBirth, City, Age, YearOfEnroll, Major, GPA)
    VALUES
    ('Trung Pham', '2000-01-15', 'HCMC', 24, 2018, 'Computer Science', 3.5),
    ('Jane Smith', '1999-05-22', 'Los Angeles', 25, 2017, 'Mathematics', 3.8),
    ('Alice Johnson', '2001-03-10', 'Chicago', 23, 2019, 'Physics', 3.6),
    ('Bob Brown', '2002-07-30', 'Houston', 22, 2020, 'Chemistry', 3.7);
END
GO




IF OBJECT_ID('dbo.tblDepartments', 'U') IS NULL
BEGIN
    CREATE TABLE tblDepartments
    (
        DepartmentID INT PRIMARY KEY IDENTITY(1,1),
        DepartmentName NVARCHAR(100) NOT NULL
    );

    INSERT INTO tblDepartments (DepartmentName)
    VALUES
    ('Computer Science'),
    ('Mathematics'),
    ('Physics'),
    ('Chemistry');
END
GO




IF OBJECT_ID('dbo.tblInstructors', 'U') IS NULL
BEGIN
    CREATE TABLE tblInstructors
    (
        InstructorID INT PRIMARY KEY IDENTITY(1,1),
        InstructorName NVARCHAR(100) NOT NULL,
        DepartmentID INT NOT NULL
    );

    INSERT INTO tblInstructors
    (InstructorName, DepartmentID)
    VALUES
    ('Dr. John Smith', 1),
    ('Dr. Jane Doe', 2),
    ('Dr. Alice Brown', 3),
    ('Dr. Bob White', 4);
END
GO



IF OBJECT_ID('dbo.tblCourses', 'U') IS NULL
BEGIN
    CREATE TABLE tblCourses
    (
        CourseID INT PRIMARY KEY IDENTITY(1,1),
        CourseName NVARCHAR(100) NOT NULL,
        Credits INT NOT NULL,
        DepartmentID INT NOT NULL,
        InstructorID INT NOT NULL
    );

    INSERT INTO tblCourses
    (CourseName, Credits, DepartmentID, InstructorID)
    VALUES
    ('Introduction to Computer Science', 3, 1, 1),
    ('Calculus I', 4, 2, 2),
    ('Physics I', 4, 3, 3),
    ('Organic Chemistry', 4, 4, 4);
END
GO




IF NOT EXISTS
(
    SELECT 1
    FROM sys.foreign_keys
    WHERE name = 'FK_Courses_Departments'
)
BEGIN
    ALTER TABLE tblCourses
    ADD CONSTRAINT FK_Courses_Departments
    FOREIGN KEY (DepartmentID)
    REFERENCES tblDepartments(DepartmentID);
END
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.foreign_keys
    WHERE name = 'FK_Courses_Instructors'
)
BEGIN
    ALTER TABLE tblCourses
    ADD CONSTRAINT FK_Courses_Instructors
    FOREIGN KEY (InstructorID)
    REFERENCES tblInstructors(InstructorID);
END
GO




IF OBJECT_ID('dbo.tblStudentCourses', 'U') IS NULL
BEGIN
    CREATE TABLE tblStudentCourses
    (
        StudentID INT NOT NULL,
        CourseID INT NOT NULL,

        PRIMARY KEY (StudentID, CourseID),

        FOREIGN KEY (StudentID)
        REFERENCES tblStudents(StudentID),

        FOREIGN KEY (CourseID)
        REFERENCES tblCourses(CourseID)
    );

    INSERT INTO tblStudentCourses
    (StudentID, CourseID)
    VALUES
    (1, 1),
    (1, 2),
    (2, 3),
    (3, 4),
    (4, 1),
    (4, 3);
END
GO





SELECT * FROM tblStudents;

SELECT * FROM tblDepartments;

SELECT * FROM tblInstructors;

SELECT * FROM tblCourses;

SELECT * FROM tblStudentCourses;
GO