CREATE DATABASE PeopleDB
GO
USE PeopleDB
GO
CREATE TABLE People
(
Id INT NOT NULL IDENTITY PRIMARY KEY,
Name NVARCHAR(100) NOT NULL,
Birthdate DATETIME NOT NULL
)
GO
INSERT People
(Name,Birthdate)
VALUES
('Victor', '2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '2010-01-06')

GO
SELECT
Name,
DATEDIFF(YEAR,Birthdate,GETDATE()) AS 'Age in Years',
DATEDIFF(MONTH,Birthdate,GETDATE()) AS 'Age in Months',
DATEDIFF(DAY,Birthdate,GETDATE()) AS 'Age in Days',
DATEDIFF(MINUTE,Birthdate,GETDATE()) AS 'Age in Minutes'
FROM People