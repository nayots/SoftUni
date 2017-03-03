----USE SoftUni

----01. One-To-One Relationship

--CREATE TABLE Persons
--(
--PersonID INT IDENTITY,
--FirstName NVARCHAR(100),
--Salary MONEY,
--PassportID INT
--)

--CREATE TABLE Passports
--(
--PassportID INT PRIMARY KEY,
--PassportNumber NVARCHAR(100)
--)

--INSERT Persons
--(FirstName, Salary, PassportID)
--VALUES
--('Roberto', 43300.00, 102),
--('Tom', 56100.00, 103),
--('Yana', 60200.00, 101)

--INSERT Passports
--(PassportID, PassportNumber)
--VALUES
--(101, 'N34FG21B'),
--(102, 'K65LO4R7'),
--(103, 'ZE657QP2')


--ALTER TABLE Persons
--ADD CONSTRAINT PK_Persons PRIMARY KEY (PersonID),
--CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID) REFERENCES Passports (PassportID)

----DROP TABLE Persons, Passports


----02. One-To-Many Relationship


--CREATE TABLE Manufacturers
--(
--ManufacturerID INT IDENTITY PRIMARY KEY,
--Name NVARCHAR(100),
--EstablishedOn DATE,
--)

--CREATE TABLE Models
--(
--ModelID INT PRIMARY KEY,
--Name NVARCHAR(100),
--ManufacturerID INT,
--)


--ALTER TABLE Models 
--ADD CONSTRAINT FK_Models_Manufacturers FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers (ManufacturerID)

--INSERT Manufacturers
--(Name, EstablishedOn)
--VALUES
--('BMW', '1916/03/07'),
--('Tesla', '2003/01/01'),
--('Lada', '1966/05/01')

--INSERT Models
--(ModelID, Name, ManufacturerID)
--VALUES
--(101, 'X1', 1),
--(102, 'i6', 1),
--(103, 'Model S', 2),
--(104, 'Model X', 2),
--(105, 'Model 3', 2),
--(106, 'Nova', 3)

----DROP TABLE Models, Manufacturers


----03. Many-To-Many Relationship

--CREATE TABLE Students
--(
--StudentID INT IDENTITY PRIMARY KEY,
--Name NVARCHAR(100)
--)

--CREATE TABLE Exams
--(
--ExamID INT PRIMARY KEY,
--Name NVARCHAR(100)
--)

--CREATE TABLE StudentsExams
--(
--StudentID INT,
--ExamID INT,
--CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID),
--CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentID) REFERENCES Students (StudentID),
--CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamID) REFERENCES Exams (ExamID)
--)


--INSERT Students
--(Name)
--VALUES
--('Mila'),
--('Toni'),
--('Ron')


--INSERT Exams
--(ExamID, Name)
--VALUES
--(101, 'Spring MVC'),
--(102, 'Neo4j'),
--(103, 'Oracle 11g')

----DROP TABLE StudentsExams, Students, Exams

----04. Self-Referencing

--CREATE TABLE Teachers
--(
--TeacherID INT PRIMARY KEY,
--Name NVARCHAR(100),
--ManagerID INT,
--CONSTRAINT FK_Teachers_Teachers FOREIGN KEY (ManagerID) REFERENCES Teachers (TeacherID)
--)

--INSERT Teachers
--(TeacherID, Name, ManagerID)
--VALUES
--(101, 'John', NULL),
--(102, 'Maya', 106),
--(103, 'Silvia', 106),
--(104, 'Ted', 105),
--(105, 'Mark', 101),
--(106, 'Greta', 101)


----DROP TABLE Teachers

----05. Online Store Database

--CREATE TABLE Orders
--(
--OrderID INT PRIMARY KEY,
--CustomerID INT
--)

--CREATE TABLE Customers
--(
--CustomerID INT PRIMARY KEY,
--Name VARCHAR(50),
--Birthday DATE,
--CityID INT
--)

--CREATE TABLE Cities
--(
--CityID INT PRIMARY KEY,
--Name VARCHAR(50)
--)

--CREATE TABLE OrderItems
--(
--OrderID INT,
--ItemID INT,
--CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID, ItemID)
--)

--CREATE TABLE Items
--(
--ItemID INT PRIMARY KEY,
--Name VARCHAR(50),
--ItemTypeID INT
--)

--CREATE TABLE ItemTypes
--(
--ItemTypeID INT PRIMARY KEY,
--Name VARCHAR(50)
--)

--ALTER TABLE Orders
--ADD CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)

--ALTER TABLE Customers
--ADD CONSTRAINT FK_Customers_Cities FOREIGN KEY (CityID) REFERENCES Cities (CityID)

--ALTER TABLE OrderItems
--ADD
--CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders (OrderID),
--CONSTRAINT FK_OrderItems_Items FOREIGN KEY (ItemID) REFERENCES Items (ItemID)

--ALTER TABLE Items
--ADD CONSTRAINT FK_Items_ItemTypes FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes (ItemTypeID)



----06. University Database

--CREATE TABLE Students
--(
--StudentID INT PRIMARY KEY,
--StudentNumber INT,
--StudentName NVARCHAR(100),
--MajorID INT
--)

--CREATE TABLE Agenda
--(
--StudentID INT,
--SubjectID INT,
--CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)
--)

--CREATE TABLE Subjects
--(
--SubjectID INT PRIMARY KEY,
--SubjectName NVARCHAR(100)
--)

--CREATE TABLE Majors
--(
--MajorID INT PRIMARY KEY,
--Name NVARCHAR(100)
--)

--CREATE TABLE Payments
--(
--PaymentID INT PRIMARY KEY,
--PaymentDate DATE,
--PaymentAmount MONEY,
--StudentID INT
--)

--ALTER TABLE Students
--ADD CONSTRAINT FK_Students_Majors FOREIGN KEY (MajorID) REFERENCES Majors (MajorID)

--ALTER TABLE Payments
--ADD CONSTRAINT FK_Payments_Students FOREIGN KEY (StudentID) REFERENCES Students (StudentID)

--ALTER TABLE Agenda
--ADD CONSTRAINT FK_Agenda_Students FOREIGN KEY (StudentID) REFERENCES Students (StudentID),
--CONSTRAINT FK_Agenda_Subjects FOREIGN KEY (SubjectID) REFERENCES Subjects (SubjectID)


----09. *Peaks in Rila

--SELECT r.MountainRange, p.PeakName, p.Elevation
--FROM Mountains AS r
--INNER JOIN Peaks AS p
--ON r.Id = p.MountainId
--WHERE r.MountainRange = 'Rila'
--ORDER BY p.Elevation DESC
