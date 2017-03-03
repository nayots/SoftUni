INSERT SoftUni.dbo.Towns
(Name)
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT SoftUni.dbo.Departments
(Name)
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT SoftUni.dbo.Addresses
(AddressText, TownId)
VALUES
('SomeAddress1', 1),
('SomeAddress2', 1),
('SomeAddress3', 1)

INSERT SoftUni.dbo.Employees
(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00, 1),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, 1),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 1),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, 1),
('Petar', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 1)