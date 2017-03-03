--CREATE DATABASE Bakery
--GO
--USE Bakery


----01. DDL

--CREATE TABLE Products
--(
--Id INT IDENTITY PRIMARY KEY,
--Name NVARCHAR(25) UNIQUE,
--Description NVARCHAR(250),
--Recipe NVARCHAR(MAX),
--Price MONEY CHECK (Price > 0)
--)

--CREATE TABLE Countries
--(
--Id INT IDENTITY PRIMARY KEY,
--Name NVARCHAR(50) UNIQUE
--)

--CREATE TABLE Customers
--(
--Id INT IDENTITY PRIMARY KEY,
--FirstName NVARCHAR(25),
--LastName NVARCHAR(25),
--Gender CHAR(1) CHECK (Gender IN ('M', 'F')),
--Age INT,
--PhoneNumber CHAR(10) CHECK (LEN(PhoneNumber) = 10),
--CountryId INT,
--CONSTRAINT FK_Customers_Countries FOREIGN KEY (CountryId) REFERENCES Countries (Id)
--)

--CREATE TABLE Feedbacks
--(
--Id INT IDENTITY PRIMARY KEY,
--Description NVARCHAR(255),
--Rate DECIMAL(10,2) CHECK (Rate BETWEEN 0.00 AND 10.00),
--ProductId INT,
--CONSTRAINT FK_Feedbacks_Products FOREIGN KEY (ProductId) REFERENCES Products (Id),
--CustomerId INT,
--CONSTRAINT FK_Feedbacks_Customers FOREIGN KEY (CustomerId) REFERENCES Customers (Id)
--)

--CREATE TABLE Distributors
--(
--Id INT IDENTITY PRIMARY KEY,
--Name NVARCHAR(25) UNIQUE,
--AddressText NVARCHAR(30),
--Summary NVARCHAR(200),
--CountryId INT,
--CONSTRAINT FK_Distributors_Countries FOREIGN KEY (CountryId) REFERENCES Countries (Id)
--)

--CREATE TABLE Ingredients
--(
--Id INT IDENTITY PRIMARY KEY,
--Name NVARCHAR(30),
--Description NVARCHAR(200),
--OriginCountryId INT,
--CONSTRAINT FK_Ingredients_Countries FOREIGN KEY (OriginCountryId) REFERENCES Countries (Id),
--DistributorId INT,
--CONSTRAINT FK_Ingredients_Distributors FOREIGN KEY (DistributorId) REFERENCES Distributors (Id)
--)

--CREATE TABLE ProductsIngredients
--(
--ProductId INT,
--IngredientId INT,
--CONSTRAINT PK_ProductsIngredients PRIMARY KEY (ProductId, IngredientId),
--CONSTRAINT FK_ProductsIngredients_Products FOREIGN KEY (ProductId) REFERENCES Products (Id),
--CONSTRAINT FK_ProductsIngredients_Ingredients FOREIGN KEY (IngredientId) REFERENCES Ingredients (Id)
--)


----02. Insert
--INSERT Distributors
--(Name, CountryId, AddressText, Summary)
--VALUES
--('Deloitte & Touche', 2, '6 Arch St #9757','Customizable neutral traveling'),
--('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
--('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
--('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
--('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

--INSERT Customers
--(FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
--VALUES
--('Francoise', 'Rautenstrauch', 15, 'M', '0195698399',	5),
--('Kendra', 'Loud', 22, 'F', '0063631526',	11),
--('Lourdes', 'Bauswell', 50,	'M', '0139037043', 8),
--('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
--('Tom', 'Loeza', 31, 'M', '0144876096', 23),
--('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
--('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
--('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

----03. Update

--UPDATE Ingredients
--SET DistributorId = 35
--WHERE Name IN ('Bay Leaf', 'Paprika', 'Poppy')

--UPDATE Ingredients
--SET OriginCountryId = 14
--WHERE OriginCountryId = 8


----04. Delete

--DELETE Feedbacks
--WHERE CustomerId = 14 OR ProductId = 5


----05. Products By Price


--SELECT p.Name, p.Price, p.Description
--FROM Products AS p
--ORDER BY p.Price DESC, p.Name


----06. Ingredients


--SELECT
--	i.Name, i.Description, i.OriginCountryId
--FROM Ingredients AS i
--WHERE i.OriginCountryId IN (1, 10, 20)
--ORDER BY i.Id


----07. Ingredients from Bulgaria and Greece


--SELECT TOP (15)
--	i.Name, i.Description, c.Name
--FROM Ingredients AS i
--INNER JOIN Countries AS c
--ON c.Id = i.OriginCountryId
--WHERE c.Name IN ('Bulgaria', 'Greece')
--ORDER BY i.Name, c.Name


----08. Best Rated Products

--SELECT TOP (10)
--	p.Name, p.Description, AVG(f.Rate) AS [AverageRate], COUNT(f.Id) AS [FeedbacksAmount]
--FROM Products AS p
--INNER JOIN Feedbacks AS f
--ON f.ProductId = p.Id
--GROUP BY p.Name, p.Description
--ORDER BY AverageRate DESC, FeedbacksAmount DESC

----09. Negative Feedback

--SELECT
--	f.ProductId, 
--	f.Rate, 
--	f.Description,
--	c.Id AS [CustomerId],
--	c.Age,
--	c.Gender
--FROM Feedbacks AS f
--INNER JOIN Customers AS c
--ON c.Id = f.CustomerId
--WHERE f.Rate < 5.00
--ORDER BY f.ProductId DESC, f.Rate

----10.	Customers without Feedback

--SELECT
--	CONCAT(c.FirstName, ' ', c.LastName) AS [CustomerName],
--	c.PhoneNumber,
--	c.Gender
--FROM Customers AS c
--WHERE c.Id NOT IN (
--					SELECT DISTINCT f.CustomerId FROM Feedbacks AS f
--					WHERE f.CustomerId IS NOT NULL
--				  )


----11. Honorable Mentions

--SELECT
--	f.ProductId,
--	CONCAT(c.FirstName, ' ', c.LastName) AS [CustomerName],
--	f.Description AS [FeedbackDescription]
--FROM Feedbacks AS f
--INNER JOIN Customers AS c
--ON c.Id = f.CustomerId
--WHERE c.Id IN 
--				(
--					SELECT
--						c.Id
--					FROM Customers AS c
--					INNER JOIN Feedbacks AS f
--					ON f.CustomerId = c.Id
--					GROUP BY c.Id
--					HAVING COUNT(f.Id) >= 3
--				)
--ORDER BY f.ProductId, CustomerName, f.Id


----12. Customers by Criteria

--DECLARE @GreeceCountryId INT = (SELECT c.Id FROM Countries AS c WHERE c.Name = 'Greece')

--SELECT
--	c.FirstName,
--	c.Age,
--	c.PhoneNumber
--FROM Customers AS c
--WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%')
--					OR
--		(c.PhoneNumber LIKE '%38' AND c.CountryId != @GreeceCountryId)
--ORDER BY c.FirstName, c.Age DESC


----13. Middle Range Distributors


--SELECT
--	d.Name AS [DistributorName],
--	i.Name AS [IngredientName],
--	p.Name AS [ProductName],
--	AVG(f.Rate) AS [AverageRate]
--FROM Distributors AS d
--INNER JOIN Ingredients AS i
--ON i.DistributorId = d.Id
--INNER JOIN ProductsIngredients AS pri
--ON pri.IngredientId = i.Id
--INNER JOIN Products AS p
--ON p.Id = pri.ProductId
--INNER JOIN Feedbacks AS f
--ON f.ProductId = p.Id
--GROUP BY d.Name, i.Name, p.Name
--HAVING AVG(f.Rate) BETWEEN 5 AND 8
--ORDER BY DistributorName, IngredientName, ProductName


----14. The Most Positive Country


--SELECT TOP (1) WITH TIES
--	co.Name AS [CountryName],
--	AVG(f.Rate) AS [FeedbackRate]
--FROM Countries AS co
--INNER JOIN Customers AS c
--ON c.CountryId = co.Id
--INNER JOIN Feedbacks AS f
--ON f.CustomerId = c.Id
--GROUP BY co.Name
--ORDER BY FeedbackRate DESC


----15. Country Representative   

----2/4
SELECT 
	c.Name AS [CountryName],
	d.Name AS [DisributorName]
FROM Countries AS c
INNER JOIN Distributors AS d
ON d.CountryId = c.Id
INNER JOIN Ingredients AS i
ON i.DistributorId = d.Id
GROUP BY c.Name, d.Name
ORDER BY c.Name, d.Name


--4/4
SELECT w.CountryName, w.DisributorName
FROM(
SELECT 
	c.Name AS [CountryName],
	d.Name AS [DisributorName],
	COUNT(i.id) AS [Count],
	DENSE_RANK() OVER (PARTITION BY c.Name ORDER BY COUNT(i.id) DESC) AS [Rank]
FROM Countries AS c
INNER JOIN Distributors AS d
ON d.CountryId = c.Id
INNER JOIN Ingredients AS i
ON i.DistributorId = d.Id
GROUP BY c.Name, d.Name
) w
WHERE w.Rank = 1
ORDER BY w.CountryName, w.DisributorName

----16. Customers With Countries

--CREATE VIEW v_UserWithCountries
--AS
--	SELECT
--		CONCAT(c.FirstName, ' ', c.LastName) AS [CustomerName],
--		c.Age,
--		c.Gender,
--		cou.Name AS [CountryName]
--	FROM Customers AS c
--	INNER JOIN Countries AS cou
--	ON cou.Id = c.CountryId

--SELECT TOP 5 *
--FROM v_UserWithCountries
--ORDER BY Age


----17. Feedback by Product Name

--CREATE FUNCTION udf_GetRating(@ProductName NVARCHAR(MAX))
--RETURNS NVARCHAR(100)
--AS
--BEGIN
--	DECLARE @Rating NVARCHAR(100);

--	SET @Rating = 
--					(
--						SELECT
--							[Rating] = CASE
--								WHEN AVG(f.Rate) < 5 THEN 'Bad'
--								WHEN AVG(f.Rate) BETWEEN 5 AND 8 THEN 'Average'
--								WHEN AVG(f.Rate) > 8 THEN 'Good'
--								WHEN COUNT(f.Id) <= 0 THEN 'No rating'
--							END
--						FROM Products AS p
--						LEFT JOIN Feedbacks AS f
--						ON f.ProductId = p.Id
--						WHERE p.Name = @ProductName
--					)

--	IF(@Rating IS NULL)
--	BEGIN
--		SET @Rating = 'No rating'
--	END

--	RETURN @Rating
--END

--DROP FUNCTION udf_GetRating

--SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
--  FROM Products
-- ORDER BY Id


----18. Send Feedback

--CREATE PROCEDURE usp_SendFeedback(@CustomerId INT, @ProductId INT, @Rate DECIMAL(10,2), @Description NVARCHAR(255))
--AS
--BEGIN
--	BEGIN TRAN
--		DECLARE @CustomerFeedBackCount INT = 
--											(
--												SELECT
--													COUNT(f.Id)
--												FROM Feedbacks AS f
--												WHERE f.CustomerId = @CustomerId AND f.ProductId = @ProductId
--											)

--		IF (@CustomerFeedBackCount >= 3)
--		BEGIN
--			RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)
--			ROLLBACK
--		END
--		ELSE
--		BEGIN
--			INSERT Feedbacks
--			(Description, Rate, ProductId, CustomerId)
--			VALUES
--			(@Description, @Rate, @ProductId, @CustomerId)
--			COMMIT
--		END
--END

--DROP PROCEDURE usp_SendFeedback


----19. Delete Products

--CREATE TRIGGER tr_DeleteProducts
--ON Products
--INSTEAD OF DELETE
--AS
--BEGIN
--	DELETE Feedbacks
--	WHERE ProductId IN (SELECT d.Id FROM deleted AS d)

--	DELETE ProductsIngredients
--	WHERE ProductId IN (SELECT d.Id FROM deleted AS d)

--	DELETE Products
--	WHERE Id IN (SELECT d.Id FROM deleted AS d)
--END

----20. Products by One Distributor

--WITH Res_CTE (ProductName, DistributorName)
--AS
--(
--	SELECT
--					p.Name AS [ProductName],
--					d.Name AS [DistributorName]
--				FROM Products AS p
--				INNER JOIN Feedbacks AS f
--				ON f.ProductId = p.Id
--				INNER JOIN ProductsIngredients AS pin
--				ON pin.ProductId = p.Id
--				INNER JOIN Ingredients AS i
--				ON i.Id = pin.IngredientId
--				INNER JOIN Distributors AS d
--				ON d.Id = i.DistributorId
--				INNER JOIN Countries AS c
--				ON c.Id = d.CountryId
--				GROUP BY p.Id, p.Name, d.Name, c.Name
--)

--SELECT
--	p.Name AS [ProductName],
--	AVG(f.Rate) AS [ProductAverageRate],
--	d.Name AS [DistributorName],
--	c.Name AS [DistributorCountry]
--FROM Products AS p
--INNER JOIN Feedbacks AS f
--ON f.ProductId = p.Id
--INNER JOIN ProductsIngredients AS pin
--ON pin.ProductId = p.Id
--INNER JOIN Ingredients AS i
--ON i.Id = pin.IngredientId
--INNER JOIN Distributors AS d
--ON d.Id = i.DistributorId
--INNER JOIN Countries AS c
--ON c.Id = d.CountryId
--GROUP BY p.Id, p.Name, d.Name, c.Name
--HAVING p.Name IN
--				(
--					SELECT r.ProductName 
--					FROM Res_CTE AS r
--					GROUP BY r.ProductName
--					HAVING COUNT(r.DistributorName) = 1
--				)
--ORDER BY p.Id


