----Section 1: DDL
--CREATE TABLE DepositTypes
--(
--DepositTypeID INT PRIMARY KEY,
--Name VARCHAR(20)
--)

--CREATE TABLE Deposits
--(
--DepositID INT IDENTITY PRIMARY KEY,
--Amount DECIMAL(10,2),
--StartDate DATE,
--EndDate DATE,
--DepositTypeID INT,
--CustomerID INT,
--CONSTRAINT FK_Deposits_DepositTypes FOREIGN KEY (DepositTypeID) REFERENCES DepositTypes (DepositTypeID),
--CONSTRAINT FK_Deposits_Customers FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)
--)



--CREATE TABLE EmployeesDeposits
--(
--EmployeeID INT,
--DepositID INT,
--CONSTRAINT PK_EmployeesDeposits PRIMARY KEY (EmployeeID, DepositID),
--CONSTRAINT FK_EmployeesDeposits_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees (EmployeeID),
--CONSTRAINT FK_EmployeesDeposits_Deposits FOREIGN KEY (DepositID) REFERENCES Deposits (DepositID)
--)

--CREATE TABLE CreditHistory
--(
--CreditHistoryID INT IDENTITY PRIMARY KEY,
--Mark CHAR(1),
--StartDate DATE,
--EndDate DATE,
--CustomerID INT,
--CONSTRAINT FK_CreditHistory_Customers FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)
--)

--CREATE TABLE Payments
--(
--PayementID INT IDENTITY PRIMARY KEY,
--Date DATE,
--Amount DECIMAL(10,2),
--LoanID INT,
--CONSTRAINT FK_Payments_Loans FOREIGN KEY (LoanID) REFERENCES Loans (LoanID)
--)

--CREATE TABLE Users
--(
--UserID INT IDENTITY PRIMARY KEY,
--UserName VARCHAR(20),
--Password VARCHAR(20),
--CustomerID INT UNIQUE,
--CONSTRAINT FK_Users_Customers FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)
--)

--ALTER TABLE Employees
--ADD ManagerID INT,
--CONSTRAINT FK_Employees_Employees FOREIGN KEY (ManagerID) REFERENCES Employees (EmployeeID)


----Section 2: DML - P01. Inserts


--INSERT DepositTypes
--(DepositTypeID, Name)
--VALUES
--(1, 'Time Deposit'),
--(2, 'Call Deposit'),
--(3, 'Free Deposit')

--INSERT Deposits
--(Amount, StartDate, DepositTypeID, CustomerID)

--SELECT CASE
--	WHEN c.DateOfBirth > '19800101' THEN 1000
--	ELSE 1500
--	END 
--+	CASE
--	WHEN c.Gender = 'M' THEN 100
--	ELSE 200
--	END AS [Amount],
--	GETDATE() AS [StartDate],
--	CASE
--	WHEN c.CustomerID > 15 THEN 3
--	WHEN c.CustomerID % 2 != 0 THEN 1
--	ELSE 2
--	END AS [DeppositType],
--	c.CustomerID
--FROM Customers AS c
--WHERE c.CustomerID < 20


--INSERT EmployeesDeposits
--(EmployeeID, DepositID)
--VALUES
--(15,4),
--(20,15),
--(8,7),
--(4,8),
--(3,13),
--(3,8),
--(4,10),
--(10,1),
--(13,4),
--(14,9)

----Section 2: DML - P02. Update

--UPDATE Employees
--SET ManagerID = 
--				CASE
--				WHEN EmployeeID BETWEEN 2 AND 10 THEN 1
--				WHEN EmployeeID BETWEEN 12 AND 20 THEN 11
--				WHEN EmployeeID BETWEEN 22 AND 30 THEN 21
--				WHEN EmployeeID IN (11, 21) THEN 1
--				END

----Section 2: DML - P03. Delete

--DELETE EmployeesDeposits
--WHERE DepositID = 9 OR EmployeeID = 3


----Section 3: Querying - P01. Employees’ Salary

--SELECT e.EmployeeID, e.HireDate, e.Salary, e.BranchID
--FROM Employees AS e
--WHERE e.Salary > 2000 AND e.HireDate > '2009-12-23'


----Section 3: Querying - P02. Customer Age
--SELECT * FROM
--(
--SELECT c.FirstName, c.DateOfBirth, DATEDIFF(YEAR, c.DateOfBirth, '2016-10-01') AS Age
--FROM Customers AS c
--) AS w
--WHERE w.Age BETWEEN 40 AND 50

----Section 3: Querying - P03. Customer City

--SELECT 
--	c.CustomerID,
--	c.FirstName,
--	c.LastName,
--	c.Gender,
--	s.CityName
--FROM Customers AS c
--INNER JOIN Cities AS s
--ON s.CityID = c.CityID
--WHERE (LEFT(c.LastName,2) = 'Bu' OR RIGHT(c.FirstName,1) = 'a')
--		AND LEN(s.CityName) >= 8
--ORDER BY c.CustomerID

----Section 3: Querying - P04. Employee Accounts

--SELECT TOP (5)
--	e.EmployeeID,
--	e.FirstName,
--	ac.AccountNumber
--FROM Employees AS e
--INNER JOIN EmployeesAccounts AS ec
--ON ec.EmployeeID = e.EmployeeID
--INNER JOIN Accounts AS ac
--ON ac.AccountID = ec.AccountID
--WHERE YEAR(ac.StartDate) > 2012
--ORDER BY e.FirstName DESC



----Section 3: Querying - P05. Count Cities

--SELECT
--	c.CityName,
--	b.Name,
--	COUNT(e.EmployeeID) AS [EmployeesCount]
--FROM Cities AS c
--INNER JOIN Branches AS b
--ON b.CityID = c.CityID
--INNER JOIN Employees AS e
--ON e.BranchID = b.BranchID
--WHERE c.CityID NOT IN (4, 5)
--GROUP BY c.CityName, b.Name
--HAVING COUNT(e.EmployeeID) >= 3

----Section 3: Querying - P06. Loan Statistics

--SELECT
--	SUM(l.Amount) AS [TotalLoanAmount],
--	MAX(l.Interest) AS [MaxInterest],
--	MIN(e.Salary) AS [MinEmployeeSalary]
--FROM Loans AS l
--INNER JOIN EmployeesLoans AS el
--ON el.LoanID = l.LoanID
--INNER JOIN Employees AS e
--ON e.EmployeeID = el.EmployeeID

----Section 3: Querying - P07. Unite People

--SELECT TOP (3)
--	e.FirstName,
--	ci.CityName
--FROM Employees AS e
--INNER JOIN Branches AS b
--ON b.BranchID = e.BranchID
--INNER JOIN Cities AS ci
--ON ci.CityID = b.CityID
--UNION ALL
--SELECT TOP (3)
--	cu.FirstName,
--	cc.CityName
--FROM Customers AS cu
--INNER JOIN Cities AS cc
--ON cc.CityID = cu.CityID

----Section 3: Querying - P08. Customers w/o Accounts


--SELECT
--	c.CustomerID,
--	c.Height
--FROM Customers AS c
--WHERE c.CustomerID NOT IN (
--							SELECT ac.CustomerID 
--							FROM Accounts AS ac
--							) AND 
--							c.Height BETWEEN 1.74 AND 2.04


----Section 3: Querying - P09. Average Loans

--DECLARE @AvgLoanAmountMales DECIMAL(10,2);

--SET @AvgLoanAmountMales = (
--							SELECT AVG(l.Amount)
--							FROM Loans AS l
--							INNER JOIN Customers AS c
--							ON c.CustomerID = l.CustomerID
--							WHERE c.Gender = 'M'
--							)

--SELECT TOP (5)
--	c.CustomerID,
--	l.Amount
--FROM Customers AS c
--INNER JOIN Loans AS l
--ON l.CustomerID = c.CustomerID
--WHERE l.Amount > @AvgLoanAmountMales
--ORDER BY c.LastName


----Section 3: Querying - P10. Oldest Account

--SELECT TOP (1) WITH TIES --Also works without "WITH TIES"
--	c.CustomerID,
--	c.FirstName,
--	a.StartDate
--FROM Customers AS c
--INNER JOIN Accounts AS a
--ON a.CustomerID = c.CustomerID
--ORDER BY a.StartDate

----Section 4: Programmability - P01. String Joiner

--CREATE FUNCTION udf_ConcatString(@StringOne VARCHAR(255), @StringTwo VARCHAR(255))
--RETURNS VARCHAR(510)
--AS
--BEGIN
--	DECLARE @Result VARCHAR(510)

--	SET @Result = CONCAT(REVERSE(@StringOne),REVERSE(@StringTwo))

--	RETURN @Result
--END

----Section 4: Programmability - P02. Inexpired Loans

--CREATE PROCEDURE usp_CustomersWithUnexpiredLoans(@CustomerID INT)
--AS
--BEGIN
--	DECLARE @ResultTable TABLE(CustomerID INT, FirstName VARCHAR(20), LoanID INT)

--	IF EXISTS(SELECT l.CustomerID FROM Loans AS l WHERE l.CustomerID = @CustomerID)
--	BEGIN
--		INSERT @ResultTable
--		SELECT 
--				c.CustomerID,
--				c.FirstName,
--				l.LoanID
--		FROM Customers AS c
--		INNER JOIN Loans AS l
--		ON l.CustomerID = c.CustomerID
--		WHERE c.CustomerID = @CustomerID AND l.ExpirationDate IS NULL
--	END

--	SELECT * FROM @ResultTable
--END

----Section 4: Programmability - P03. Take Loan

--CREATE PROCEDURE usp_TakeLoan(@CustomerID INT, @LoanAmount DECIMAL(10,2), @Interest DECIMAL(4,2), @StartDate DATE)
--AS
--BEGIN
--	BEGIN TRAN
--	IF(@LoanAmount NOT BETWEEN 0.01 AND 100000)
--	BEGIN
--		RAISERROR('Invalid Loan Amount.',16 ,1)
--		ROLLBACK
--	END
--	ELSE
--	BEGIN
--		INSERT Loans
--		(CustomerID, Amount, Interest, StartDate)
--		VALUES
--		(@CustomerID, @LoanAmount, @Interest, @StartDate)
--		COMMIT
--	END
--END


----Section 4: Programmability - P04. Hire Employee

--CREATE TRIGGER tr_LoanInheritance
--ON Employees
--AFTER INSERT
--AS
--BEGIN
--	DECLARE @PrevEmpId INT;
--	DECLARE @NewEmpID INT;

--	SET @NewEmpID = (SELECT i.EmployeeID FROM inserted AS i)

--	SET @PrevEmpId = (SELECT e.EmployeeID 
--						FROM Employees AS e 
--						WHERE e.EmployeeID = (
--												(SELECT i.EmployeeID 
--												FROM inserted AS i) 
--												- 1)
--											)

	
--	INSERT EmployeesLoans
--	(EmployeeID, LoanID)
--	SELECT @NewEmpID, (SELECT el.LoanID 
--						FROM EmployeesLoans AS el 
--						WHERE el.EmployeeID = @PrevEmpId)
--END


----Section 5: Bonus - P01. Delete Trigger

--CREATE TABLE AccountLogs
--(
--	[AccountID] [int] NOT NULL,
--	[AccountNumber] [char](12) NOT NULL,
--	[StartDate] [date] NOT NULL,
--	[CustomerID] [int] NOT NULL
--)
-----------------------------------------------------

--CREATE TRIGGER tr_LogDeletedAcc
--ON Accounts
--INSTEAD OF DELETE
--AS
--BEGIN
--	DELETE FROM EmployeesAccounts
--	WHERE AccountID IN (SELECT d.AccountID FROM deleted AS d)

--	DELETE FROM Accounts
--	WHERE AccountID IN (SELECT d.AccountID FROM deleted AS d)

--	INSERT AccountLogs
--	(AccountID, AccountNumber, StartDate, CustomerID)
--	SELECT
--		d.AccountID, d.AccountNumber, d.StartDate, d.CustomerID
--	FROM deleted AS d
--END