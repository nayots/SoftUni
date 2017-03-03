--CREATE DATABASE Movies


--CREATE TABLE Directors
--(
--Id INT NOT NULL IDENTITY PRIMARY KEY,
--DirectorName NVARCHAR(50) NOT NULL,
--Notes NVARCHAR(MAX)
--)

--CREATE TABLE Genres
--(
--Id INT NOT NULL IDENTITY PRIMARY KEY,
--GenreName NVARCHAR(50) NOT NULL,
--Notes NVARCHAR(MAX)
--)

--CREATE TABLE Categories
--(
--Id INT NOT NULL IDENTITY PRIMARY KEY,
--CategoryName NVARCHAR(100) NOT NULL,
--Notes NVARCHAR(MAX)
--)

--CREATE TABLE Movies
--(
--Id INT NOT NULL IDENTITY PRIMARY KEY,
--Title NVARCHAR(200) NOT NULL,
--DirectorId INT NOT NULL,
--CONSTRAINT FK_Movies_Directors FOREIGN KEY (DirectorId) REFERENCES Directors (Id),
--CopyrightYear DATE DEFAULT GETDATE(),
--Length FLOAT NOT NULL,
--GenreId INT NOT NULL,
--CONSTRAINT FK_Movies_Genres FOREIGN KEY (GenreId) REFERENCES Genres (Id),
--CategoryId INT NOT NULL,
--CONSTRAINT FK_Movies_Categories FOREIGN KEY (CategoryId) REFERENCES Categories (Id),
--Rating FLOAT DEFAULT 0.00,
--Notes NVARCHAR(MAX)
--)


--INSERT Directors
--(DirectorName, Notes)
--VALUES
--('Goshko', 'BlablaGoshkoisHere'),
--('Peshko', 'This is Peshko'),
--('Stoyan', 'I smell noobs :D'),
--('St', 'I smell noobs :D'),
--('Sto', 'I smell noobs :D')

--INSERT Genres
--(GenreName)
--VALUES
--('Adventure'),
--('Sci-fi'),
--('Fantasy'),
--('Horror'),
--('Romance')

--INSERT Categories
--(CategoryName)
--VALUES
--('NewMovies'),
--('OldMovies'),
--('StupidMovies'),
--('NotFunMovies'),
--('ChinaMovies')

--INSERT Movies
--(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
--VALUES
--('Movie1', 1, '2000-12-24', 65.5, 1, 1 , DEFAULT , NULL),
--('Movie2', 2, '2000-12-25', 40.5, 2, 1 , DEFAULT , NULL),
--('Movie3', 3, '2000-12-26', 50.5, 3, 2 , DEFAULT , NULL),
--('Movie4', 2, '2000-12-27', 120.5, 1, 1 , DEFAULT , NULL),
--('Movie5', 1, DEFAULT, 80, 3, 2 , DEFAULT , 'Hello its a note')