USE master;
GO

IF DB_ID('SchoolDB') IS NULL
BEGIN
    CREATE DATABASE SchoolDB;
END
GO

USE SchoolDB;
GO


DROP TABLE IF EXISTS tblUsers;

CREATE TABLE tblUsers (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL
);

INSERT INTO tblUsers (Username, Password)
VALUES ('user1', 'password1');

INSERT INTO tblUsers (Username, Password)
VALUES ('user2', 'password2');
Select * from tblUsers