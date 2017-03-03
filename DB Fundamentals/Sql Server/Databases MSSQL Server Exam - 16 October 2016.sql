----CREATE DATABASE AMS
----GO
----USE AMS

----Section 1: DDL

--CREATE TABLE Towns (
--	TownID INT,
--	TownName VARCHAR(30) NOT NULL,
--	CONSTRAINT PK_Towns PRIMARY KEY(TownID)
--)

--CREATE TABLE Airports (
--	AirportID INT,
--	AirportName VARCHAR(50) NOT NULL,
--	TownID INT NOT NULL,
--	CONSTRAINT PK_Airports PRIMARY KEY(AirportID),
--	CONSTRAINT FK_Airports_Towns FOREIGN KEY(TownID) REFERENCES Towns(TownID)
--)

--CREATE TABLE Airlines (
--	AirlineID INT,
--	AirlineName VARCHAR(30) NOT NULL,
--	Nationality VARCHAR(30) NOT NULL,
--	Rating INT DEFAULT(0),
--	CONSTRAINT PK_Airlines PRIMARY KEY(AirlineID)
--)

--CREATE TABLE Customers (
--	CustomerID INT,
--	FirstName VARCHAR(20) NOT NULL,
--	LastName VARCHAR(20) NOT NULL,
--	DateOfBirth DATE NOT NULL,
--	Gender VARCHAR(1) NOT NULL CHECK (Gender='M' OR Gender='F'),
--	HomeTownID INT NOT NULL,
--	CONSTRAINT PK_Customers PRIMARY KEY(CustomerID),
--	CONSTRAINT FK_Customers_Towns FOREIGN KEY(HomeTownID) REFERENCES Towns(TownID)
--)

--CREATE TABLE Flights
--(
--FlightID INT,
--DepartureTime DATETIME NOT NULL,
--ArrivalTime DATETIME NOT NULL,
--Status VARCHAR(9) NOT NULL CHECK (Status IN ('Departing', 'Delayed', 'Arrived', 'Cancelled')),
--OriginAirportID INT,
--DestinationAirportID INT,
--AirlineID INT,
--CONSTRAINT PK_Flights PRIMARY KEY  (FlightID),
--CONSTRAINT FK_Flights_Airports_Origin FOREIGN KEY (OriginAirportID) REFERENCES Airports (AirportID),
--CONSTRAINT FK_Flights_Airports_Destination FOREIGN KEY (DestinationAirportID) REFERENCES Airports (AirportID),
--CONSTRAINT FK_Flights_Airlines FOREIGN KEY (AirlineID) REFERENCES Airlines (AirlineID)
--)

--CREATE TABLE Tickets
--(
--TicketID INT,
--Price DECIMAL(8,2) NOT NULL,
--Class VARCHAR(6) CHECK (Class IN('First', 'Second', 'Third')),
--Seat VARCHAR(5) NOT NULL,
--CustomerID INT,
--FlightID INT,
--CONSTRAINT PK_Tickets PRIMARY KEY (TicketID),
--CONSTRAINT FK_Tickets_Customers FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID),
--CONSTRAINT FK_Tickets_Flights FOREIGN KEY (FlightID) REFERENCES Flights (FlightID)
--)

--INSERT INTO Towns(TownID, TownName)
--VALUES
--(1, 'Sofia'),
--(2, 'Moscow'),
--(3, 'Los Angeles'),
--(4, 'Athene'),
--(5, 'New York')

--INSERT INTO Airports(AirportID, AirportName, TownID)
--VALUES
--(1, 'Sofia International Airport', 1),
--(2, 'New York Airport', 5),
--(3, 'Royals Airport', 1),
--(4, 'Moscow Central Airport', 2)

--INSERT INTO Airlines(AirlineID, AirlineName, Nationality, Rating)
--VALUES
--(1, 'Royal Airline', 'Bulgarian', 200),
--(2, 'Russia Airlines', 'Russian', 150),
--(3, 'USA Airlines', 'American', 100),
--(4, 'Dubai Airlines', 'Arabian', 149),
--(5, 'South African Airlines', 'African', 50),
--(6, 'Sofia Air', 'Bulgarian', 199),
--(7, 'Bad Airlines', 'Bad', 10)

--INSERT INTO Customers(CustomerID, FirstName, LastName, DateOfBirth, Gender, HomeTownID)
--VALUES
--(1, 'Cassidy', 'Isacc', '19971020', 'F', 1),
--(2, 'Jonathan', 'Half', '19830322', 'M', 2),
--(3, 'Zack', 'Cody', '19890808', 'M', 4),
--(4, 'Joseph', 'Priboi', '19500101', 'M', 5),
--(5, 'Ivy', 'Indigo', '19931231', 'F', 1)


----Section 2: DML - 01. Data Insertion

--INSERT Flights
--(FlightID, DepartureTime, ArrivalTime, Status, OriginAirportID, DestinationAirportID, AirlineID)
--VALUES
--(1, '2016-10-13 06:00 AM', '2016-10-13 10:00 AM', 'Delayed', 1, 4, 1),
--(2, '2016-10-12 12:00 PM', '2016-10-12 12:01 PM', 'Departing', 1, 3, 2),
--(3, '2016-10-14 03:00 PM', '2016-10-20 04:00 AM', 'Delayed', 4, 2, 4),
--(4, '2016-10-12 01:24 PM', '2016-10-12 4:31 PM', 'Departing', 3, 1, 3),
--(5, '2016-10-12 08:11 AM', '2016-10-12 11:22 PM', 'Departing', 4, 1, 1),
--(6, '1995-06-21 12:30 PM', '1995-06-22 08:30 PM', 'Arrived', 2, 3, 5),
--(7, '2016-10-12 11:34 PM', '2016-10-13 03:00 AM', 'Departing', 2, 4, 2),
--(8, '2016-11-11 01:00 PM', '2016-11-12 10:00 PM', 'Delayed', 4, 3, 1),
--(9, '2015-10-01 12:00 PM', '2015-12-01 01:00 AM', 'Arrived', 1, 2, 1),
--(10, '2016-10-12 07:30 PM', '2016-10-13 12:30 PM', 'Departing', 2, 1, 7)

--INSERT Tickets
--(TicketID, Price, Class, Seat, CustomerID, FlightID)
--VALUES
--(1, 3000.00, 'First', '233-A', 3, 8),
--(2, 1799.90, 'Second', '123-D', 1, 1),
--(3, 1200.50, 'Second', '12-Z', 2, 5),
--(4, 410.68, 'Third', '45-Q', 2, 8),
--(5, 560.00, 'Third', '201-R', 4, 6),
--(6, 2100.00, 'Second', '13-T', 1, 9),
--(7, 5500.00, 'First', '98-O', 2, 7)

----Section 2: DML - 02. Update Flights

--UPDATE Flights
--SET AirlineID = 1
--WHERE Status = 'Arrived'

----Section 2: DML - 03. Update Tickets

--UPDATE Tickets
--SET Price = Price * 1.5
--WHERE FlightID IN 
--				(
--					SELECT FlightID FROM Flights
--					WHERE AirlineID = 
--										(
--										SELECT TOP (1) AirlineID FROM Airlines
--										ORDER BY Rating DESC
--										)
--				)


----Section 2: DML - 04. Table Creation

--CREATE TABLE CustomerReviews
--(
--ReviewID INT,
--ReviewContent VARCHAR(255) NOT NULL,
--ReviewGrade INT CHECK (ReviewGrade BETWEEN 0 AND 10),
--AirlineID INT,
--CustomerID INT,
--CONSTRAINT PK_CustomerReviews PRIMARY KEY (ReviewID),
--CONSTRAINT FK_CustomerReviews_Airlines FOREIGN KEY (AirlineID) REFERENCES Airlines (AirlineID),
--CONSTRAINT FK_CustomerReviews_Customers FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)
--)

--CREATE TABLE CustomerBankAccounts
--(
--AccountID INT,
--AccountNumber VARCHAR(10) NOT NULL UNIQUE,
--Balance DECIMAL(10,2) NOT NULL,
--CustomerID INT,
--CONSTRAINT PK_CustomerBankAccounts PRIMARY KEY (AccountID),
--CONSTRAINT FK_CustomerBankAccounts_Customers FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)
--)

----Section 2: DML - 05. Fillin New Tables

--INSERT CustomerReviews
--(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID)
--VALUES
--(1, 'Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
--(2, 'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
--(3, 'Meh...', 5, 4, 3),
--(4, 'Well Ive seen better, but Ive certainly seen a lot worse...', 7, 3, 5)

--INSERT CustomerBankAccounts
--(AccountID, AccountNumber, Balance, CustomerID)
--VALUES
--(1, '123456790', 2569.23, 1),
--(2, '18ABC23672', 14004568.23, 2),
--(3, 'F0RG0100N3', 19345.20, 5)


----Section 3: Querying - 01. Extract All Tickets

--SELECT t.TicketID, t.Price, t.Class, t.Seat
--FROM Tickets AS t
--ORDER BY t.TicketID

----Section 3: Querying - 02. Extract All Customers

--SELECT c.CustomerID, CONCAT(c.FirstName, ' ', c.LastName) AS [FullName], c.Gender
--FROM Customers AS c
--ORDER BY FullName, c.CustomerID

----Section 3: Querying - 03. Extract Delayed Flights

--SELECT f.FlightID, f.DepartureTime, f.ArrivalTime
--FROM Flights AS f
--WHERE f.Status = 'Delayed'
--ORDER BY f.FlightID

----Section 3: Querying - 04. Top 5 Airlines

--SELECT TOP (5) a.AirlineID, a.AirlineName, a.Nationality, a.Rating
--FROM Airlines AS a
--WHERE a.AirlineID IN (SELECT DISTINCT AirlineID FROM Flights)
--ORDER BY a.Rating DESC, a.AirlineID

----Section 3: Querying - 05. All Tickets Below 5000

--SELECT t.TicketID, a.AirportName AS [Destination], CONCAT(c.FirstName, ' ', c.LastName) AS [CustomerName]
--FROM Tickets AS t
--INNER JOIN Flights AS f
--ON f.FlightID = t.FlightID
--INNER JOIN Airports AS a
--ON a.AirportID = f.DestinationAirportID
--INNER JOIN Customers AS c
--ON c.CustomerID = t.CustomerID
--WHERE t.Price < 5000 AND t.Class = 'First'
--ORDER BY t.TicketID

----Section 3: Querying - 06. Customers From Home

--SELECT DISTINCT c.CustomerID, CONCAT(c.FirstName, ' ', c.LastName) AS [FullName], t.TownName AS [HomeTown]
--FROM Customers AS c
--INNER JOIN Tickets AS ti
--ON ti.CustomerID = c.CustomerID
--INNER JOIN Flights AS f
--ON f.FlightID = ti.FlightID
--INNER JOIN Airports AS a
--ON a.AirportID = f.OriginAirportID
--INNER JOIN Towns AS t
--ON t.TownID = a.TownID
--WHERE c.HomeTownID = a.TownID
--ORDER BY c.CustomerID


----Section 3: Querying - 07. Customers who will fly

--SELECT DISTINCT c.CustomerID, CONCAT(c.FirstName, ' ', c.LastName) AS [FullName],  DATEDIFF(YEAR,c.DateOfBirth, '20160101') AS Age
--FROM Customers AS c
--INNER JOIN Tickets AS t
--ON t.CustomerID = c.CustomerID
--INNER JOIN Flights AS f
--ON f.FlightID = t.FlightID
--WHERE f.Status = 'Departing'
--ORDER BY AGE, c.CustomerID

----Section 3: Querying - 08. Top 3 Customers Delayed


--SELECT TOP (3)
--		c.CustomerID, 
--		CONCAT(c.FirstName, ' ', c.LastName) AS [FullName],
--		t.Price AS [TicketPrice],
--		a.AirportName AS [Destination]
--FROM Customers AS c
--INNER JOIN Tickets AS t
--ON t.CustomerID = c.CustomerID
--INNER JOIN Flights AS f
--ON f.FlightID = t.FlightID
--INNER JOIN Airports AS a
--ON f.DestinationAirportID = a.AirportID
--WHERE f.Status = 'Delayed'
--ORDER BY TicketPrice DESC, c.CustomerID


----Section 3: Querying - 09. Last 5 Departing Flights

--WITH Flights_CTE
--(FlightID, DepartureTime, ArrivalTime, Origin, Destination)
--AS
--(
--SELECT TOP (5)
--		f.FlightID AS [FlightID],
--		f.DepartureTime AS [DepartureTime],
--		f.ArrivalTime AS [ArrivalTime] ,
--		ao.AirportName AS [Origin],
--		ad.AirportName AS [Destination]
--FROM Flights AS f
--INNER JOIN Airports AS ao
--ON ao.AirportID = f.OriginAirportID
--INNER JOIN Airports AS ad
--ON ad.AirportID = f.DestinationAirportID
--WHERE f.Status = 'Departing'
--ORDER BY f.DepartureTime DESC, f.FlightID
--)

--SELECT * FROM Flights_CTE
--ORDER BY DepartureTime, FlightID


----Section 3: Querying - 10. Customers Below 21


--SELECT DISTINCT * FROM
--(
--	SELECT
--			c.CustomerID,
--			CONCAT(c.FirstName, ' ', c.LastName) AS [FullName],
--			2016 - YEAR(c.DateOfBirth) AS [Age]
--	FROM Customers AS c
--	INNER JOIN Tickets AS t
--	ON t.CustomerID = c.CustomerID
--	INNER JOIN Flights AS f
--	ON f.FlightID = t.FlightID
--	WHERE f.Status = 'Arrived'
--) s
--WHERE s.Age < 21
--ORDER BY s.Age DESC, s.Customer

----Section 3: Querying - 11. AIrports and Passengers

--SELECT
--		a.AirportID,
--		a.AirportName,
--		COUNT(t.TicketID) AS [Passengers]
--FROM Airports AS a
--INNER JOIN Flights AS ff
--ON ff.OriginAirportID = a.AirportID
--INNER JOIN Tickets AS t
--ON t.FlightID = ff.FlightID
--WHERE ff.Status = 'Departing'
--GROUP BY a.AirportID, a.AirportName
--ORDER BY a.AirportID

----Section 4: Programmibility - 01. Submit Review

--CREATE PROCEDURE usp_SubmitReview(
--						@CustomerID INT, 
--						@ReviewContent VARCHAR(255), 
--						@ReviewGrade INT, 
--						@AirlineName VARCHAR(MAX)
--						)
--AS
--BEGIN
--	DECLARE @AirlineID INT = (SELECT a.AirlineID 
--								FROM Airlines AS a
--								WHERE a.AirlineName = @AirlineName)
--	BEGIN TRAN
--	IF (@ReviewGrade NOT BETWEEN 0 AND 10)
--		BEGIN
--		ROLLBACK
--		END
	
--	IF (@AirlineID IS NULL)
--		BEGIN
--		RAISERROR('Airline does not exist.',16,1)
--		ROLLBACK
--		END
--	ELSE
--		BEGIN
--		INSERT CustomerReviews
--		(ReviewID, CustomerID, ReviewContent, ReviewGrade, AirlineID)
--		VALUES
--		(1, @CustomerID, @ReviewContent, @ReviewGrade, @AirlineID)
--		COMMIT
--		END
--END

----Section 4: Programmibility - 02. Ticket Purchase

--CREATE PROCEDURE usp_PurchaseTicket(
--									@CustomerID INT,
--									@FlightID INT,
--									@TicketPrice DECIMAL(19,2),
--									@Class VARCHAR(6),
--									@Seat VARCHAR(5)
--									)
--AS
--BEGIN
--	DECLARE @CustomerBankBalance DECIMAL(19,2) = (
--									SELECT cb.Balance
--									FROM CustomerBankAccounts AS cb
--									WHERE cb.CustomerID = @CustomerID
--									)
--	BEGIN TRAN
--		IF (@CustomerBankBalance - @TicketPrice < 0) OR @CustomerBankBalance IS NULL
--		BEGIN
--			RAISERROR('Insufficient bank account balance for ticket purchase.',16 ,1)
--			ROLLBACK
--		END
--		ELSE
--		BEGIN
--			INSERT Tickets
--			(TicketID, Price, Class, Seat, CustomerID, FlightID)
--			VALUES
--			(86 ,@TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

--			UPDATE CustomerBankAccounts
--			SET Balance = Balance - @TicketPrice
--			WHERE CustomerID = @CustomerID

--			COMMIT
--		END
--END


----BONUS Section 5: Update Trigger

--CREATE TABLE ArrivedFlights
--(
--FlightID INT PRIMARY KEY,
--ArrivalTime DATETIME NOT NULL,
--Origin VARCHAR(50) NOT NULL,
--Destination VARCHAR(50) NOT NULL,
--Passengers INT NOT NULL
--)

--CREATE TRIGGER tr_SuccesFullFlight
--ON
--Flights
--AFTER UPDATE
--AS
--BEGIN
--	DECLARE @NewFlightStatus VARCHAR(9) = (SELECT DISTINCT ins.Status FROM inserted AS ins);
--	IF(@NewFlightStatus = 'Arrived')
--	BEGIN
--		INSERT ArrivedFlights
--		(FlightID, ArrivalTime, Origin, Destination, Passengers)
--		SELECT * FROM
--		(
--		SELECT 
--				ins.FlightID, 
--				ins.ArrivalTime,
--				[Origin] = (
--					SELECT AirportName 
--					FROM Airports AS a 
--					INNER JOIN Flights AS f ON f.OriginAirportID = a.AirportID 
--					WHERE f.FlightID = ins.FlightID),
--				[Destination] = (
--					SELECT AirportName 
--					FROM Airports AS a 
--					INNER JOIN Flights AS f ON f.DestinationAirportID = a.AirportID 
--					WHERE f.FlightID = ins.FlightID),
--				[Passengers] = (
--					SELECT COUNT(t.TicketID) 
--					FROM Tickets AS t 
--					INNER JOIN Flights AS f ON f.FlightID = t.FlightID 
--					WHERE f.FlightID = ins.FlightID)
--		FROM inserted AS ins
--		) w
--	END
--END

