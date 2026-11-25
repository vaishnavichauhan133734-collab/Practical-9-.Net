CREATE DATABASE PlacementDB;
GO

USE PlacementDB;
GO

CREATE TABLE Students (
    PlacementId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId VARCHAR(20) NOT NULL,
    StudentName VARCHAR(100) NOT NULL,
    CompanyName VARCHAR(100),
    JobRole VARCHAR(100),
    PackageLPA DECIMAL(10,2),
    PlacementStatus VARCHAR(20) NOT NULL DEFAULT 'Unplaced'
);

INSERT INTO Students (StudentId, StudentName, CompanyName, JobRole, PackageLPA, PlacementStatus) VALUES
('92400103501', 'Raj', 'TCS', 'Software Developer', 5.50, 'Placed'),
('92400103502', 'Student 2', 'Infosys', 'System Engineer', 6.25, 'Placed'),
('92400103503', 'Student 3', 'Wipro', 'Project Engineer', 4.75, 'Placed'),
('92400103504', 'Student 4', NULL, NULL, NULL, 'Unplaced');
