----CREATE DATABASE TheNerdHerd
----GO
----USE TheNerdHerd

----Section 1: DDL 1. Database Design

--CREATE TABLE Locations
--(
--Id INT IDENTITY PRIMARY KEY,
--Latitude FLOAT,
--Longitude FLOAT
--)

--CREATE TABLE Credentials
--(
--Id INT IDENTITY PRIMARY KEY,
--Email VARCHAR(30),
--Password VARCHAR(20)
--)

--CREATE TABLE Users
--(
--Id INT IDENTITY PRIMARY KEY,
--Nickname VARCHAR(25),
--Gender CHAR(1),
--Age INT,
--LocationId INT,
--CredentialId INT UNIQUE,
--CONSTRAINT FK_Users_Locations FOREIGN KEY (LocationId) REFERENCES Locations (Id),
--CONSTRAINT FK_Users_Credentials FOREIGN KEY (CredentialId) REFERENCES Credentials (Id)
--)

--CREATE TABLE Chats
--(
--Id INT IDENTITY PRIMARY KEY,
--Title VARCHAR(32),
--StartDate DATE,
--IsActive Bit
--)

--CREATE TABLE Messages
--(
--Id INT IDENTITY PRIMARY KEY,
--Content VARCHAR(200),
--SentOn DATE,
--ChatId INT,
--UserId INT,
--CONSTRAINT FK_Messages_Chats FOREIGN KEY (ChatId) REFERENCES Chats (Id),
--CONSTRAINT FK_Messages_Users FOREIGN KEY (UserId) REFERENCES Users (Id)
--)

--CREATE TABLE UsersChats
--(
--UserId INT,
--ChatId INT,
--CONSTRAINT PK_UsersChats PRIMARY KEY (ChatId, UserId),
--CONSTRAINT FK_UsersChats_Users FOREIGN KEY (UserId) REFERENCES Users (Id),
--CONSTRAINT FK_UsersChats_Chats FOREIGN KEY (ChatId) REFERENCES Chats (Id)
--)


----Section 2. DML 2. Insert

--INSERT Messages
--(Content, SentOn, ChatId, UserId)
--SELECT
--	CONCAT(us.Age, '-', us.Gender, '-', l.Latitude, '-', l.Longitude),
--	CONVERT(DATE, GETDATE()),
--	[ChatId] = CASE
--	WHEN us.Gender = 'F' THEN CEILING(SQRT((us.Age * 2)))
--	WHEN us.Gender = 'M' THEN CEILING(POWER((us.Age / 18), 3))
--	END,
--	us.Id
--FROM Users AS us
--INNER JOIN Locations AS l
--ON l.Id = us.LocationId
--WHERE us.Id >= 10 AND us.Id <= 20


----Section 2. DML 3. Update

--WITH ChatsAndMessages_CTE
--(ChatId, YDate)
--AS
--(
--	SELECT c.Id AS [ChatId], MIN(m.SentOn) AS [YDate]
--	FROM Chats AS c
--	INNER JOIN Messages AS m
--	ON m.ChatId = c.Id
--	GROUP BY c.Id
--)


--UPDATE Chats
--SET StartDate = t.YDate
--FROM
--Chats AS ch
--INNER JOIN ChatsAndMessages_CTE AS t
--ON t.ChatId = ch.Id
--WHERE ch.StartDate > t.YDate

----Section 2. DML 4. Delete

--DELETE FROM Locations
--WHERE Id NOT IN (
--					SELECT LocationId FROM Users AS us
--					WHERE us.LocationId IS NOT NULL
--				)

----Section 3: Querying - 5. Age Range

--SELECT u.Nickname, u.Gender, u.Age
--FROM Users AS u
--WHERE u.Age BETWEEN 22 AND 37

----Section 3: Querying - 6. Messages

--SELECT m.Content, m.SentOn
--FROM Messages AS m
--WHERE m.SentOn > '20140512' 
--AND 
--CHARINDEX('just', m.Content) > 0
--ORDER BY m.Id DESC

----Section 3: Querying - 7. Chats

--SELECT ch.Title, ch.IsActive
--FROM Chats AS ch
--WHERE ch.IsActive = 0
--AND
--LEN(ch.Title) < 5 
--OR (SUBSTRING(ch.Title,3,2) = 'tl')
--ORDER BY ch.Title DESC

----Section 3: Querying - 8. Chat Messages

--SELECT ch.Id, ch.Title, m.Id
--FROM Chats AS ch
--INNER JOIN Messages AS m
--ON m.ChatId = ch.Id
--WHERE m.SentOn < '20120326' AND RIGHT(ch.Title,1) = 'x'
--ORDER BY ch.Id, m.Id

----Section 3: Querying - 9.	Message Count

--SELECT TOP (5) c.Id, COUNT(m.Id) AS [TotalMessages]
--FROM Chats AS c
--RIGHT JOIN Messages AS m
--ON m.ChatId = c.Id
--WHERE m.Id < 90
--GROUP BY c.Id
--ORDER BY TotalMessages DESC, c.Id

----Section 3: Querying - 10. Credentials

--SELECT u.Nickname, cr.Email, cr.Password
--FROM Credentials AS cr
--INNER JOIN Users AS u
--ON u.CredentialId = cr.Id
--WHERE cr.Email LIKE '%co.uk'
--ORDER BY cr.Email

----Section 3: Querying - 11. Locations

--SELECT u.Id, u.Nickname, u.Age
--FROM Users AS u
--WHERE u.LocationId IS NULL

----Section 3: Querying - 12. Left Users

--SELECT m.Id, m.ChatId, m.UserId
--FROM Messages AS m
--WHERE 
--	(m.UserId NOT IN 
--					(SELECT uc.UserId 
--					FROM UsersChats AS uc 
--					INNER JOIN Messages AS m 
--					ON uc.ChatId = m.ChatId 
--					WHERE uc.UserId = m.UserId) 
--						OR m.UserId IS NULL) 
--	AND m.ChatId = 17
--ORDER BY m.Id DESC

----Section 3: Querying - 13. Users in Bulgaria

--SELECT u.Nickname, c.Title, l.Latitude, l.Longitude
--FROM Users AS u
--INNER JOIN Locations AS l
--ON l.Id = u.LocationId
--INNER JOIN UsersChats AS uc
--ON uc.UserId = u.Id
--INNER JOIN Chats AS c
--ON c.Id = uc.ChatId
--WHERE 	l.Latitude BETWEEN 41.14 AND CAST(44.13 AS NUMERIC(18,0))
--		AND
--		l.Longitude BETWEEN 22.21 AND CAST(28.36 AS NUMERIC(18,0))
--ORDER BY c.Title


----Section 3: Querying - 14. Last Chat

--SELECT TOP (1) WITH TIES c.Title, m.Content
--FROM Chats AS c
--LEFT JOIN Messages AS m
--ON m.ChatId = c.Id
--ORDER BY c.StartDate DESC


----Section 4: Programmability - 15. Radians

--CREATE FUNCTION udf_GetRadians(@Degrees FLOAT)
--RETURNS FLOAT
--AS
--BEGIN
--	DECLARE @Result FLOAT
--	SET @Result = ((@Degrees * PI())/180)
--	RETURN @Result
--END


----Section 4: Programmability - 16. Change Password

--CREATE PROCEDURE udp_ChangePassword(@Email VARCHAR(30), @Password VARCHAR(20))
--AS
--BEGIN
--	IF EXISTS (SELECT * FROM Credentials WHERE Email = @Email)
--	BEGIN
--		UPDATE Credentials
--		SET Password = @Password
--		WHERE Email = @Email
--	END
--	ELSE
--	BEGIN
--		RAISERROR('The email does''t exist!', 16, 1)
--	END
--END

----Section 4: Programmability - 17.	Send Message

--CREATE PROCEDURE udp_SendMessage(@UserId INT, @ChatId INT, @Content VARCHAR(200))
--AS
--BEGIN
--	IF EXISTS (SELECT * FROM UsersChats AS uc WHERE uc.ChatId = @ChatId AND uc.UserId = @UserId)
--	BEGIN
--		INSERT Messages
--		(Content, SentOn, ChatId, UserId)
--		VALUES
--		(@Content, CONVERT(DATE, GETDATE()), @ChatId, @UserId)
--	END
--	ELSE
--	BEGIN
--		RAISERROR('There is no chat with that user!',16 ,1)
--	END
--END

----Section 4: Programmability - 18.	Log Messages

--CREATE TABLE MessageLogs
--(
--Id INT PRIMARY KEY,
--Content VARCHAR(200),
--SentOn DATE,
--ChatId INT,
--UserId INT
--)



--CREATE TRIGGER tr_LogDeletedMessages
--ON Messages
--AFTER DELETE
--AS
--BEGIN
--	INSERT MessageLogs
--	(Id, Content, SentOn, ChatId, UserId)
--	SELECT d.Id, d.Content, d.SentOn, d.ChatId, d.UserId
--	FROM deleted AS d
--END


----Section 5: Bonus - 19. Delete users

--CREATE TRIGGER tr_DeleteUsers
--ON Users
--INSTEAD OF DELETE
--AS
--BEGIN

--	DELETE FROM Messages
--	WHERE UserId IN (SELECT d.Id FROM deleted AS d)

--	DELETE FROM UsersChats
--	WHERE UserId IN (SELECT d.Id FROM deleted AS d)

--	DELETE FROM Users
--	WHERE Id IN (SELECT d.Id FROM deleted AS d)
	
--END


