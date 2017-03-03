----1. Initial Setup

CREATE TABLE Countries
(
Id INT IDENTITY PRIMARY KEY,
CountryName VARCHAR(200) NOT NULL
)

CREATE TABLE Towns
(
Id INT IDENTITY PRIMARY KEY,
TownName VARCHAR(200) NOT NULL,
CountryId INT,
CONSTRAINT FK_Towns_Countries FOREIGN KEY (CountryId) REFERENCES Countries (Id)
)

CREATE TABLE Minions
(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(200) NOT NULL,
Age INT,
TownId INT,
CONSTRAINT FK_Minions_Towns FOREIGN KEY (TownId) REFERENCES Towns (Id)
)

CREATE TABLE Villains
(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(200),
EvilnessFactor VARCHAR(10) CHECK (EvilnessFactor IN('good', 'bad', 'evil', 'super evil'))
)

CREATE TABLE MinionsVillains
(
MinionId INT,
VillainId INT,
CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId),
CONSTRAINT FK_MinionsVillains_Minions FOREIGN KEY (MinionId) REFERENCES Minions (Id),
CONSTRAINT FK_MinionsVillains_Villains FOREIGN KEY (VillainId) REFERENCES Villains (Id)
)

INSERT Villains
(Name, EvilnessFactor)
VALUES
('Dath Vader', 'evil'),
('Hannibal Lecter', 'super evil'),
('Voldemort', 'bad'),
('The Joker', 'evil'),
('Emperor Palpatine', 'super evil'),
('Sauron', 'good')


INSERT Countries
(CountryName)
VALUES
('Bulgaria'),
('Greece'),
('USA'),
('United Kingdom'),
('Romania')

INSERT Towns
(TownName, CountryId)
VALUES
('Sofia', 1),
('Athens', 2),
('New York', 3),
('London', 4),
('Mangalia', 5)

INSERT Minions
(Name, Age, TownId)
VALUES
('Penka', 25, 1),
('Sirtakis', 45, 2),
('Muricos', 19, 3),
('Fat Garry', 30, 4),
('Tarikatos', 14, 5),
('Smaug', 180, 1)

INSERT MinionsVillains
(MinionId, VillainId)
VALUES
(1, 1),
(2, 4),
(3, 5),
(3, 3),
(1, 3),
(2, 2),
(4, 2),
(1, 6),
(4, 4),
(5, 5),
(1, 5),
(5, 1),
(6, 6),
(6, 1),
(1, 2),
(1, 4),
(3, 1),
(4, 1)

----Get Villains Names

SELECT v.Name, COUNT(m.Id) AS MinionsCount FROM Villains AS v
INNER JOIN MinionsVillains AS mv
ON mv.VillainId = v.Id
INNER JOIN Minions AS m
ON m.Id = mv.MinionId
GROUP BY v.Name
HAVING COUNT(m.Id) > 3