----01. Employees with Salary Above 35000

--CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
--AS
--BEGIN
--	SELECT FirstName, LastName FROM Employees
--	WHERE Salary > 35000
--END


----02. Employees with Salary Above Number

--CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@TargetSalary MONEY)
--AS
--BEGIN
--	SELECT FirstName, LastName FROM Employees
--	WHERE Salary >= @TargetSalary
--END


----03. Town Names Starting With

--CREATE PROCEDURE usp_GetTownsStartingWith(@TownStringStart VARCHAR(max))
--AS
--BEGIN
--	SELECT Name AS 'Town' FROM Towns
--	WHERE Name LIKE @TownStringStart + '%'
--END

--EXEC usp_GetTownsStartingWith 'bot'
--DROP PROCEDURE usp_GetTownsStartingWith

----04. Employees from Town

--CREATE PROCEDURE usp_GetEmployeesFromTown(@TownName VARCHAR(MAX))
--AS
--BEGIN
--	SELECT FirstName, LastName 
--	FROM Employees as e
--	INNER JOIN Addresses AS a
--	ON e.AddressID=a.AddressID
--	INNER JOIN Towns AS t
--	ON a.TownID=t.TownID
--	WHERE t.Name = @TownName
--END

--EXEC usp_GetEmployeesFromTown 'Sofia'
--DROP PROCEDURE usp_GetEmployeesFromTown

----05. Salary Level Function

--CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
--RETURNS VARCHAR(50)
--AS
--BEGIN
--	DECLARE @SalaryLevel VARCHAR(50);
--	SET @SalaryLevel= CASE 
--	WHEN @salary < 30000 THEN 'Low'
--	WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
--	WHEN @salary > 50000 THEN 'High'
--	END
--	RETURN @SalaryLevel;
--END
--GO
----SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] FROM Employees

----06. Employees by Salary Level

--CREATE PROCEDURE usp_EmployeesBySalaryLevel(@SalaryLevel VARCHAR(MAX))
--AS
--BEGIN
--	SELECT e.FirstName, e.LastName FROM Employees AS e
--	WHERE @SalaryLevel = dbo.ufn_GetSalaryLevel(e.Salary)
--END

--EXEC usp_EmployeesBySalaryLevel 'High'

----07. Define Function

--CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
--RETURNS BIT
--AS
--BEGIN
--	DECLARE @index INT = 1
--	DECLARE @Lenght INT = LEN(@word)
--	DECLARE @Letter CHAR(1)
--	WHILE(@index <= @Lenght)
--	BEGIN
--		SET @Letter = SUBSTRING(@word, @index, 1)
--		IF (CHARINDEX(@Letter, @setOfLetters) > 0)
--		SET @index += 1
--		ELSE
--		RETURN 0
--	END
--	RETURN 1
--END


----08. Delete Employees and Departments
--ALTER TABLE Departments
--ALTER COLUMN ManagerID INT

--DELETE FROM EmployeesProjects
--WHERE EmployeeID IN (SELECT EmployeeID FROM Employees 
--					 WHERE DepartmentID IN (SELECT DepartmentID 
--						FROM Departments
--						WHERE Name IN ('Production','Production Control'))
--					)
--ALTER TABLE Employees
--DROP CONSTRAINT FK_Employees_Departments
--ALTER TABLE Employees
--DROP CONSTRAINT FK_Employees_Employees
--ALTER TABLE Departments
--DROP CONSTRAINT FK_Departments_Employees

--DELETE FROM Employees
--WHERE DepartmentID IN	(
--						SELECT DepartmentID 
--						FROM Departments
--						WHERE Name IN ('Production','Production Control')
--						)

--DELETE FROM Departments
--WHERE Name IN ('Production','Production Control')


----09. Employees with Three Projects

--CREATE PROCEDURE usp_AssignProject(@emloyeeID INT, @ProjectID INT)
--AS
--BEGIN
--	DECLARE @MaxProjectsPerEmployee INT = 3
--	DECLARE @EmplojeeProjectCount INT
--			BEGIN TRAN
--			INSERT EmployeesProjects (EmployeeID, ProjectID)
--			VALUES
--			(@emloyeeID, @ProjectID)

--			SET @EmplojeeProjectCount = (SELECT COUNT(*) FROM EmployeesProjects
--										WHERE EmployeeID = @emloyeeID
--									)
--			IF(@EmplojeeProjectCount > @MaxProjectsPerEmployee)
--			BEGIN
--				RAISERROR('The employee has too many projects!',16,1)
--				ROLLBACK
--			END
--			ELSE
--			BEGIN
--				COMMIT
--			END
--END

----10. Find Full Name

--CREATE PROCEDURE usp_GetHoldersFullName
--AS
--BEGIN
--	SELECT CONCAT(a.FirstName, ' ', a.LastName) AS 'Full Name' FROM AccountHolders AS a
--END

----11. People with Balance Higher Than

--CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@TargetBalance MONEY)
--AS
--BEGIN
--	----SELECT a.FirstName AS 'First Name', a.LastName AS 'Last Name' FROM AccountHolders AS a
--	----WHERE a.Id IN (
--	----				SELECT AccountHolderId FROM Accounts
--	----				GROUP BY AccountHolderId
--	----				HAVING SUM(Balance) > @TargetBalance
--	----			  )

--	SELECT a.FirstName AS 'First Name', a.LastName AS 'Last Name' FROM AccountHolders AS a
--	INNER JOIN Accounts AS ac
--	ON a.Id = ac.AccountHolderId
--	GROUP BY a.FirstName, a.LastName
--	HAVING SUM(ac.Balance) > @TargetBalance
--END

--DROP PROCEDURE usp_GetHoldersWithBalanceHigherThan

--EXEC usp_GetHoldersWithBalanceHigherThan 20000

----12. Future Value Function

--CREATE FUNCTION ufn_CalculateFutureValue(@sum MONEY, @YIR FLOAT, @NumberOfYears INT)
--RETURNS MONEY
--AS
--BEGIN
--	DECLARE @FutureValue MONEY
--	SET @FutureValue = @sum * (POWER((1+ @YIR),@NumberOfYears))
--	RETURN @FutureValue
--END

--SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS 'Output'

----13. Calculating Interest

--CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AccountId INT, @YIR FLOAT)
--AS
--BEGIN
--	SELECT @AccountId AS 'Account Id', a.FirstName, a.LastName, ac.Balance, dbo.ufn_CalculateFutureValue(ac.Balance, @YIR, 5) AS 'Balance in 5 years'
--	FROM AccountHolders AS a
--	INNER JOIN Accounts AS ac
--	ON a.Id = ac.AccountHolderId
--	WHERE ac.Id = @AccountId
--END

--EXEC usp_CalculateFutureValueForAccount 1, 0.1

----14. Deposit Money Procedure

--CREATE PROCEDURE usp_DepositMoney(@AccountId INT, @moneyAmount MONEY)
--AS
--	BEGIN TRAN
--		UPDATE Accounts
--		SET Balance = Balance + @moneyAmount
--		WHERE Accounts.Id = @AccountId
--		BEGIN
--			COMMIT
--		END

----15. Withdraw Money Procedure

--CREATE PROCEDURE usp_WithdrawMoney(@AccountId INT, @moneyAmount MONEY)
--AS
--BEGIN
--	DECLARE @CurrentAccountBalance MONEY
--	BEGIN TRAN
--		UPDATE Accounts
--		SET Balance = Balance - @moneyAmount
--		WHERE Accounts.Id = @AccountId
		
--		SET @CurrentAccountBalance = (SELECT Balance FROM Accounts AS a WHERE a.Id = @AccountId)
		
--		IF (@CurrentAccountBalance < 0)
--		BEGIN
--			ROLLBACK
--		END
--		ELSE
--		BEGIN
--			COMMIT
--		END
--END


----16. Money Transfer

--CREATE PROCEDURE usp_TransferMoney(@senderId INT, @receiverId INT, @amount MONEY)
--AS
--BEGIN
--	DECLARE @SenderBalance MONEY = (SELECT ac.Balance FROM Accounts AS ac WHERE ac.Id = @senderId)
--	BEGIN TRAN
--		IF(@amount < 0)
--		BEGIN
--			ROLLBACK
--		END
--		ELSE
--		BEGIN
--			IF(@SenderBalance - @amount >= 0)
--			BEGIN
--				EXEC usp_WithdrawMoney @senderId, @amount
--				EXEC usp_DepositMoney @receiverId, @amount
--				COMMIT
--			END
--			ELSE
--			BEGIN
--				ROLLBACK
--			END
--		END
--END


----17. Create Table Logs

--CREATE TABLE Logs
--(
--LogId INT IDENTITY PRIMARY KEY,
--AccountId INT,
--OldSum MONEY,
--NewSum MONEY
--)
--GO


--CREATE TRIGGER tr_LogBalanceChange
--ON Accounts
--AFTER UPDATE
--AS
--BEGIN
--	INSERT Logs(AccountId, OldSum, NewSum)
--	SELECT inserted.Id, deleted.Balance, inserted.Balance
--	FROM deleted, inserted
--END


--GO
--EXEC usp_TransferMoney 1, 2, 100
--GO
--EXEC usp_TransferMoney 2, 1, 100

----18. Create Table Emails

--CREATE TABLE NotificationEmails
--(
--Id INT IDENTITY PRIMARY KEY,
--Recipient VARCHAR(100),
--Subject NVARCHAR(100),
--Body NVARCHAR(MAX)
--)
--GO

--CREATE TRIGGER tr_EmailNotification
--ON Logs
--AFTER INSERT
--AS
--BEGIN
--	INSERT NotificationEmails(Recipient, Subject, Body)
--	SELECT inserted.AccountId, 
--			CONCAT('Balance change for account: ', inserted.AccountId), 
--			CONCAT('On ', GETDATE(), ' your balance was changed from ', inserted.OldSum, ' to ', inserted.NewSum)
--	FROM inserted
--END

----19. *Cash in User Games Odd Rows

--CREATE FUNCTION ufn_CashInUsersGames(@GameName VARCHAR(MAX))
--RETURNS @RtnTable TABLE
--(
--SumCash MONEY
--)
--AS
--	BEGIN
--	DECLARE @CashSum MONEY

--	SET @CashSum =  (SELECT SUM(ug.Cash) AS 'SumCash'
--	FROM (
--			SELECT Cash, GameId, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RoWNum
--			FROM UsersGames
--			WHERE GameId = (SELECT Id FROM Games WHERE Name = @GameName)
--		 ) ug
--	WHERE ug.RoWNum % 2 != 0
--	)

--	INSERT @RtnTable SELECT @CashSum
--	RETURN
--END

--SELECT * INTO TestTable FROM  dbo.ufn_CashInUsersGames('Bali')

----21. *Massive Shopping

--DECLARE @User VARCHAR(MAX) = 'Stamat'
--DECLARE @GameName VARCHAR(MAX) = 'Safflower'
--DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = @User)
--DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = @GameName)
--DECLARE @UserMoney MONEY = (SELECT Cash FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
--DECLARE @ItemsBulkPrice MONEY
--DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)

--BEGIN TRAN--11 to 12
--		SET @ItemsBulkPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)
--		IF (@UserMoney - @ItemsBulkPrice >= 0)
--		BEGIN
--			INSERT UserGameItems
--			SELECT i.Id, @UserGameId FROM Items AS i
--			WHERE i.id IN (Select Id FROM Items WHERE MinLevel BETWEEN 11 AND 12)
--			UPDATE UsersGames
--			SET Cash = Cash - @ItemsBulkPrice
--			WHERE GameId = @GameId AND UserId = @UserId
--			COMMIT
--		END
--		ELSE
--		BEGIN
--			ROLLBACK
--		END
			

--SET @UserMoney = (SELECT Cash FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
--BEGIN TRAN--19 to 21
--		SET @ItemsBulkPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)
--		IF (@UserMoney - @ItemsBulkPrice >= 0)
--		BEGIN
--			INSERT UserGameItems
--			SELECT i.Id, @UserGameId FROM Items AS i
--			WHERE i.id IN (Select Id FROM Items WHERE MinLevel BETWEEN 19 AND 21)
--			UPDATE UsersGames
--			SET Cash = Cash - @ItemsBulkPrice
--			WHERE GameId = @GameId AND UserId = @UserId
--			COMMIT
--		END
--		ELSE
--		BEGIN
--			ROLLBACK
--		END

-- SELECT Name AS 'Item Name' FROM Items
-- WHERE Id IN (SELECT ItemId FROM UserGameItems WHERE UserGameId = @UserGameId)
-- ORDER BY [Item Name]


----22. Number of Users for Email Provider

--SELECT x.[Email Provider], COUNT(*) AS [Number Of Users]
--FROM
--(
--	SELECT  SUBSTRING(Email,(CHARINDEX('@',Email)+1),LEN(Email))AS [Email Provider] 
--	FROM Users
--) x
--GROUP BY x.[Email Provider]
--ORDER BY [Number Of Users] DESC, x.[Email Provider]

----23. All Users in Games

--SELECT g.Name AS [Game], gt.Name AS [Game Type], us.Username, ug.Level, ug.Cash, ch.Name AS [Character] FROM Games AS g
--INNER JOIN GameTypes AS gt
--ON g.GameTypeId = gt.Id
--INNER JOIN UsersGames AS ug
--ON g.Id = ug.GameId
--INNER JOIN Users AS us
--ON ug.UserId = us.Id
--INNER JOIN Characters AS ch
--ON ug.CharacterId = ch.Id
--ORDER BY ug.Level DESC, us.Username, Game

----24. Users in Games with Their Items

--SELECT us.Username AS [Username], ga.Name AS [Game], COUNT(ugi.ItemId) AS [Items Count], SUM(it.Price) AS [Items Price]
--FROM Users AS us
--INNER JOIN UsersGames AS ug
--ON ug.UserId = us.Id
--INNER JOIN Games AS ga
--ON ga.Id = ug.GameId
--INNER JOIN UserGameItems AS ugi
--ON ugi.UserGameId = ug.Id
--INNER JOIN Items AS it
--ON ugi.ItemId = it.Id
--GROUP BY us.Username, ga.Name
--HAVING COUNT(ugi.ItemId) >= 10
--ORDER BY [Items Count] DESC, [Items Price] DESC, [Username]


----25. * User in Games with Their Statistics

--SELECT 
--	us.Username AS [Username],
--	ga.Name AS [Game],
--	MAX(cha.Name) AS [Character],
--	SUM(sta.Strength) + MAX(gtst.Strength) + MAX(chst.Strength) AS [Strength],
--	SUM(sta.Defence) + MAX(gtst.Defence) + MAX(chst.Defence) AS [Defence],
--	SUM(sta.Speed) + MAX(gtst.Speed) + MAX(chst.Speed) AS [Speed],
--	SUM(sta.Mind) + MAX(gtst.Mind) + MAX(chst.Mind) AS [Mind],
--	SUM(sta.Luck) + MAX(gtst.Luck) + MAX(chst.Luck) AS [Luck]

--FROM Users AS us
--INNER JOIN UsersGames AS ug
--ON us.Id = ug.UserId
--INNER JOIN Games AS ga
--ON ug.GameId = ga.Id
--INNER JOIN Characters AS cha
--ON ug.CharacterId = cha.Id
--INNER JOIN UserGameItems AS ugi
--ON ug.Id = ugi.UserGameId
--INNER JOIN Items AS itms
--ON ugi.ItemId = itms.Id
--INNER JOIN [Statistics] AS sta
--ON itms.StatisticId = sta.Id
--INNER JOIN GameTypes AS gt
--ON ga.GameTypeId = gt.Id
--INNER JOIN [Statistics] AS chst
--ON cha.StatisticId = chst.Id
--INNER JOIN [Statistics] AS gtst
--ON gt.BonusStatsId = gtst.Id
--GROUP BY us.Username, ga.Name
--ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC


----26. All Items with Greater than Average Statistics
--WITH AVGStats_CTE
--	( AVGSpeed, AVGLuck, AVGMind)
--AS
--(
--SELECT AVG(st.Speed) AS AVGSpeed, AVG(st.Luck) AS AVGLuck, AVG(st.Mind) AS AVGMind 
--FROM [Statistics] as st
--)

--SELECT i.Name, i.Price, i.MinLevel, ista.Strength, ista.Defence, ista.Speed, ista.Luck, ista.Mind
--FROM Items AS i
--INNER JOIN [Statistics] AS ista
--ON ista.Id = i.StatisticId
--WHERE ista.Speed > (SELECT AVGSpeed FROM AVGStats_CTE) AND
--		ista.Luck > (SELECT AVGLuck FROM AVGStats_CTE) AND
--		ista.Mind > (SELECT AVGMind FROM AVGStats_CTE)
--ORDER BY i.Name


----27. Display All Items about Forbidden Game Type

--SELECT  it.Name AS [Item], it.Price AS [Price], it.MinLevel AS [MinLevel], gt.Name AS [Forbidden Game Type]
--FROM Items AS it
--LEFT JOIN GameTypeForbiddenItems AS gtfi
--ON gtfi.ItemId = it.Id
--LEFT JOIN GameTypes AS gt
--ON gt.Id = gtfi.GameTypeId
--ORDER BY gt.Name DESC, it.Name

----28. Buy Items for User in Game

--DECLARE @AlexUserGameId  INT = (
--								SELECT Id 
--								FROM UsersGames AS ug
--								WHERE ug.GameId = 
--									  (SELECT Id FROM Games WHERE Name = 'Edinburgh') AND
--									  ug.UserId =
--									  (SELECT Id FROM Users WHERE Username = 'Alex')
--								)

--DECLARE @AlexItemsPrice MONEY = (
--								SELECT SUM(Price) FROM Items
--								WHERE Name IN ('Blackguard', 
--								'Bottomless Potion of Amplification', 
--								'Eye of Etlich (Diablo III)', 
--								'Gem of Efficacious Toxin', 
--								'Golden Gorget of Leoric', 
--								'Hellfire Amulet')
--								)

--DECLARE @GameID INT = (Select GameId FROM UsersGames WHERE Id = @AlexUserGameId)

--INSERT UserGameItems
--SELECT it.Id, @AlexUserGameId
--FROM Items AS it
--WHERE it.Name IN ('Blackguard', 
--					'Bottomless Potion of Amplification', 
--					'Eye of Etlich (Diablo III)', 
--					'Gem of Efficacious Toxin', 
--					'Golden Gorget of Leoric', 
--					'Hellfire Amulet')

--UPDATE UsersGames
--SET Cash = Cash - @AlexItemsPrice
--WHERE Id = @AlexUserGameId

--SELECT us.Username, ga.Name, ug.Cash, its.Name AS [Item Name]
--FROM Users AS us
--INNER JOIN UsersGames AS ug
--ON ug.UserId = us.Id
--INNER JOIN Games AS ga
--ON ga.Id = ug.GameId
--INNER JOIN UserGameItems AS ugi
--ON ugi.UserGameId = ug.Id
--INNER JOIN Items AS its
--ON its.Id = ugi.ItemId
--WHERE ug.GameId = @GameID
--ORDER BY [Item Name]

----29. Peaks and Mountains

--SELECT p.PeakName AS [PeakName], m.MountainRange AS [Mountain] , p.Elevation AS [Elevation]
--FROM Peaks AS p
--INNER JOIN Mountains AS m
--ON m.Id = p.MountainId
--ORDER BY Elevation DESC, PeakName

----30. Peaks with Mountain, Country and Continent

--SELECT p.PeakName AS [PeakName], 
--		m.MountainRange AS [Mountain],
--		c.CountryName AS [CountryName],
--		co.ContinentName AS [ContinentName]
--FROM Peaks AS p
--INNER JOIN Mountains AS m
--ON m.Id = p.MountainId
--INNER JOIN MountainsCountries AS mc
--ON mc.MountainId = m.Id
--INNER JOIN Countries AS c
--ON c.CountryCode = mc.CountryCode
--INNER JOIN Continents AS co
--ON co.ContinentCode = c.ContinentCode
--ORDER BY PeakName, CountryName

----31. Rivers by Country

--SELECT c.CountryName,
--		con.ContinentName,
--		COUNT(ri.Id) AS [RiversCount],
--		ISNULL(SUM(ri.Length), 0) AS [TotalLength]
--FROM Countries AS c
--LEFT JOIN Continents AS con
--ON con.ContinentCode = c.ContinentCode
--LEFT JOIN CountriesRivers AS cr
--ON cr.CountryCode = c.CountryCode
--LEFT JOIN Rivers AS ri
--ON ri.Id = cr.RiverId
--GROUP BY c.CountryName, con.ContinentName
--ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName


----32. Count of Countries by Currency

--SELECT cu.CurrencyCode, 
--		cu.Description AS [Currency], 
--		COUNT(co.CurrencyCode) AS [NumberOfCountries]
--FROM Currencies AS cu
--LEFT JOIN Countries AS co
--ON co.CurrencyCode = cu.CurrencyCode
--GROUP BY cu.CurrencyCode, cu.Description
--ORDER BY NumberOfCountries DESC, Currency


----33. Population and Area by Continent

--SELECT
--		co.ContinentName,
--		SUM(CAST(c.AreaInSqKm AS bigint)) AS [CountriesArea],
--		SUM(CAST(c.Population AS bigint)) AS [CountriesPopulation]
--FROM Continents AS co
--INNER JOIN Countries AS c
--ON c.ContinentCode = co.ContinentCode
--GROUP BY co.ContinentName
--ORDER BY CountriesPopulation DESC

----34. Monasteries by Country

--CREATE TABLE Monasteries
--(
--Id INT IDENTITY PRIMARY KEY,
--Name VARCHAR(200),
--CountryCode CHAR(2),
--CONSTRAINT FK_Monasteries_Countries FOREIGN KEY (CountryCode) REFERENCES Countries (CountryCode)
--)

--INSERT INTO Monasteries(Name, CountryCode) VALUES
--('Rila Monastery “St. Ivan of Rila”', 'BG'), 
--('Bachkovo Monastery “Virgin Mary”', 'BG'),
--('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
--('Kopan Monastery', 'NP'),
--('Thrangu Tashi Yangtse Monastery', 'NP'),
--('Shechen Tennyi Dargyeling Monastery', 'NP'),
--('Benchen Monastery', 'NP'),
--('Southern Shaolin Monastery', 'CN'),
--('Dabei Monastery', 'CN'),
--('Wa Sau Toi', 'CN'),
--('Lhunshigyia Monastery', 'CN'),
--('Rakya Monastery', 'CN'),
--('Monasteries of Meteora', 'GR'),
--('The Holy Monastery of Stavronikita', 'GR'),
--('Taung Kalat Monastery', 'MM'),
--('Pa-Auk Forest Monastery', 'MM'),
--('Taktsang Palphug Monastery', 'BT'),
--('Sümela Monastery', 'TR');


----ALTER TABLE Countries
----ADD IsDeleted BIT NOT NULL
----CONSTRAINT DF_Countries_IsDeleted DEFAULT 0



--WITH CountriesWithMoreThan3Rivers_CTE
--(CountryCode)
--AS
--(
--SELECT c.CountryCode FROM Countries AS c
--INNER JOIN CountriesRivers AS cr
--ON cr.CountryCode = c.CountryCode
--INNER JOIN Rivers AS ri
--ON ri.Id = cr.RiverId
--GROUP BY c.CountryCode
--HAVING COUNT(ri.RiverName) > 3
--)

--UPDATE Countries
--SET IsDeleted = 1
--WHERE CountryCode IN (SELECT CountryCode FROM CountriesWithMoreThan3Rivers_CTE)



--SELECT
--	mo.Name AS [Monastery],
--	c.CountryName AS [Country]
--FROM Monasteries AS mo
--INNER JOIN Countries AS c
--ON c.CountryCode = mo.CountryCode
--WHERE c.IsDeleted = 0
--ORDER BY Monastery

----35. Monasteries by Continents and Countries

--UPDATE Countries
--SET CountryName = 'Burma'
--WHERE CountryName = 'Myanmar'

--INSERT [dbo].[Monasteries]
--(Name, CountryCode)
--VALUES
--('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania')),
--('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar'))

--SELECT
--	co.ContinentName,
--	c.CountryName,
--	COUNT(mo.Id) AS [MonasteriesCount]
--FROM Continents AS co
--INNER JOIN Countries AS c
--ON c.ContinentCode = co.ContinentCode
--LEFT JOIN Monasteries AS mo
--ON mo.CountryCode = c.CountryCode
--WHERE c.IsDeleted = 0
--GROUP BY co.ContinentName, c.CountryName
--ORDER BY MonasteriesCount DESC, c.CountryName