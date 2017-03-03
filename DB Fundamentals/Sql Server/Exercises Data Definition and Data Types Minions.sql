--CREATE DATABASE Minions


--CREATE TABLE Minions
--(
--Id INT NOT NULL,
--Name VARCHAR(50) NOT NULL,
--Age INT,
--PRIMARY KEY (Id)
--)

--CREATE TABLE Towns
--(
--Id INT NOT NULL,
--Name VARCHAR(50) NOT NULL
--PRIMARY KEY (Id)
--)


--ALTER TABLE Minions
--ADD TownId INT

--ALTER TABLE Minions     
--ADD CONSTRAINT FK_Towns_Minions FOREIGN KEY (TownId) 
--REFERENCES Towns (Id)


--INSERT Towns
--(Id, Name)
--VALUES
--(1, 'Sofia'),
--(2, 'Plovdiv'),
--(3, 'Varna')

--INSERT Minions
--(Id, Name, Age, TownId) 
--VALUES
--(1, 'Kevin', 22, 1),
--(2, 'Bob', 15, 3),
--(3, 'Steward', NULL, 2)


--TRUNCATE TABLE Minions


--DROP TABLE Minions
--DROP TABLE Towns


--CREATE TABLE People
--(
--Id INT NOT NULL IDENTITY PRIMARY KEY,
--Name NVARCHAR(200) NOT NULL,
--Picture VARBINARY(MAX),
--Height FLOAT,
--Weight FLOAT,
--Gender CHAR(1) NOT NULL CHECK(gender in('f','m')),
--Birthday DATE NOT NULL,
--Biography NVARCHAR(MAX)
--)

--INSERT People
--(Name, Picture, Height, Weight, Gender, Birthday, Biography)
--VALUES
--('Gosho', NULL, 1.71, 72.5, 'm', '1989-11-24', 'Some blablasdd'),
--('Pesho', NULL, 1.72, 73.5, 'm', '1989-11-24', 'Some blabladdas'),
--('Gesho', NULL, 1.73, 74.5, 'm', '1989-11-24', 'Some blabladas'),
--('Penka', NULL, 1.60, 50, 'f', '1989-11-24', 'Some blabladasaaa'),
--('Stoyan', NULL, 1.75, 76.5, 'm', '1989-11-24', 'Some blablayerter')


--CREATE TABLE Users
--(
--Id BIGINT NOT NULL IDENTITY PRIMARY KEY,
--Username NVARCHAR(30) UNIQUE NOT NULL,
--Password NVARCHAR(26) NOT NULL,
--ProfilePicture VARBINARY(MAX),
--LastLoginTime DATETIME NOT NULL,
--IsDeleted BIT NOT NULL
--)

--INSERT Users
--(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
--VALUES
--('Goshko', '12345', NULL, '1989-11-24 16:30:10', 0),
--('Peshko', '12445', NULL, '1989-11-24 16:30:11', 0),
--('Geshko', '12545', NULL, '1989-11-24 16:30:12', 1),
--('Vladko', '12645', NULL, '1989-11-24 16:30:13', 0),
--('Nakovcho', '12745', NULL, '1989-11-24 16:30:14', -1)


--DECLARE @SQL VARCHAR(4000)
--SET @SQL = 'ALTER TABLE Users DROP CONSTRAINT |constraintName|'
--SET @SQL = REPLACE(@SQL, '|constraintName|', (SELECT name  
--												FROM sys.key_constraints  
--												WHERE type = 'PK' 
--												AND OBJECT_NAME(parent_object_id) = N'Users'))

--EXEC (@SQL)


--ALTER TABLE Users
--ADD PRIMARY KEY ( Id, Username)

--ALTER TABLE Users
--ADD CONSTRAINT chk_Password_Length CHECK(LEN(Password) >= 5)

--ALTER TABLE Users
--ADD CONSTRAINT DF_Users_LastLoginTime
--DEFAULT GETDATE() for LastLoginTime

--ALTER TABLE Users
--ADD CONSTRAINT chk_Users_Username CHECK(LEN(Username) >= 3)


