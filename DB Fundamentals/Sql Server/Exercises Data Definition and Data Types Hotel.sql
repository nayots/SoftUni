--CREATE DATABASE Hotel

CREATE TABLE Employees
(
Id INT NOT NULL IDENTITY PRIMARY KEY,
FirstName NVARCHAR(100) NOT NULL,
LastName NVARCHAR(100) NOT NULL,
Title NVARCHAR(50),
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers
(
AccountNumber INT NOT NULL IDENTITY PRIMARY KEY,
FirstName NVARCHAR(100) NOT NULL,
LastName NVARCHAR(100) NOT NULL,
PhoneNumber NCHAR(10) NOT NULL,
EmergencyName NVARCHAR(200),
EmergencyNumber NCHAR(12),
Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus
(
RoomStatus NVARCHAR(10) NOT NULL DEFAULT 'Ready' PRIMARY KEY,
Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes
(
RoomType NVARCHAR(100) NOT NULL DEFAULT 'Twin Beds Studio' PRIMARY KEY,
Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes
(
BedType NVARCHAR(100) NOT NULL DEFAULT 'Twin Bed' PRIMARY KEY,
Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms
(
RoomNumber INT NOT NULL PRIMARY KEY,
RoomType NVARCHAR(100) NOT NULL,
CONSTRAINT FK_Rooms_RoomTypes FOREIGN KEY (RoomType) REFERENCES RoomTypes (RoomType),
BedType NVARCHAR(100) NOT NULL,
CONSTRAINT FK_Rooms_BedTypes FOREIGN KEY (BedType) REFERENCES BedTypes (BedType),
Rate MONEY NOT NULL DEFAULT 30.50,
CONSTRAINT chk_Price CHECK (Rate >= 0),
RoomStatus NVARCHAR(10) NOT NULL,
CONSTRAINT FK_Rooms_RoomStatus FOREIGN KEY (RoomStatus) REFERENCES RoomStatus (RoomStatus),
Notes NVARCHAR(MAX)
)

CREATE TABLE Payments
(
Id INT NOT NULL IDENTITY PRIMARY KEY,
EmployeeId INT NOT NULL,
CONSTRAINT FK_Payments_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees (Id),
PaymentDate DATE NOT NULL DEFAULT GETDATE(),
AccountNumber INT NOT NULL,
CONSTRAINT FK_Payments_Customers FOREIGN KEY (AccountNumber) REFERENCES Customers (AccountNumber),
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
CONSTRAINT chk_Date CHECK (LastDateOccupied >= FirstDateOccupied),
TotalDays INT NOT NULL DEFAULT 1,
AmountCharged MONEY NOT NULL DEFAULT 0,
TaxRate MONEY NOT NULL DEFAULT 0.10,
TaxAmount MONEY NOT NULL,
PaymentTotal MONEY NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies
(
Id INT NOT NULL IDENTITY PRIMARY KEY,
EmployeeId INT NOT NULL,
CONSTRAINT FK_Occupancies_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees (Id),
DateOccupied DATE NOT NULL,
CONSTRAINT chk_DateOccupied CHECK (DateOccupied <= GETDATE()),
AccountNumber INT NOT NULL,
CONSTRAINT FK_Occupancies_Customers FOREIGN KEY (AccountNumber) REFERENCES Customers (AccountNumber),
RoomNumber INT NOT NULL,
CONSTRAINT FK_Occupancies_Rooms FOREIGN KEY (RoomNumber) REFERENCES Rooms (RoomNumber),
RateApplied MONEY NOT NULL,
PhoneCharge MONEY NOT NULL DEFAULT 0,
Notes NVARCHAR(MAX)
)



INSERT Employees
(FirstName, LastName, Title, Notes)
VALUES
('Pesho', 'Ivanov', 'Mr', 'Noober'),
('Mesho', 'Ivanov', 'Mr', 'Noober'),
('Klesho', 'Ivanov', 'Mr', 'Noober')

INSERT Customers
(FirstName, LastName, PhoneNumber)
VALUES
('Cust1', 'Cust1LN', '0888123456'),
('Cust2', 'Cust2LN', '0886123456'),
('Cust3', 'Cust3LN', '0887123456')

INSERT RoomStatus
(RoomStatus)
VALUES
(DEFAULT),
('Dirty'),
('NotReady')

INSERT RoomTypes
(RoomType)
VALUES
(DEFAULT),
('Bungalo'),
('BigRoom')

INSERT BedTypes
(BedType)
VALUES
(DEFAULT),
('Normal Bed'),
('Huge Bed')

INSERT Rooms
(RoomNumber, RoomType, BedType, Rate, RoomStatus)
VALUES
(111, 'Twin Beds Studio', 'Twin Bed', DEFAULT, 'Ready'),
(222, 'Twin Beds Studio', 'Twin Bed', DEFAULT, 'Ready'),
(333, 'Twin Beds Studio', 'Twin Bed', DEFAULT, 'Ready')

INSERT Payments
( EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES
(1, GETDATE(), 1, '2017-01-01', '2017-01-02', 1, 200.25, DEFAULT, 10, 210.25),
(2, GETDATE(), 2, '2017-01-01', '2017-01-02', 1, 210.25, DEFAULT, 10, 220.25),
(3, GETDATE(), 3, '2017-01-01', '2017-01-02', 1, 220.25, DEFAULT, 10, 230.25)

INSERT Occupancies
(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES
(1, '2017-01-10', 1, 111, 60.50, 11.20),
(2, '2017-01-10', 2, 333, 61.50, 12.20),
(3, '2017-01-10', 3, 222, 62.50, 13.20)