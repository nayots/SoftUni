----01. Employee Address

--SELECT TOP (5)e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
--FROM Employees AS e
--INNER JOIN Addresses AS a
--ON e.AddressID=a.AddressID
--ORDER BY e.AddressID


----02. Addresses with Towns

--SELECT TOP (50) e.FirstName, e.LastName, t.Name, a.AddressText
--FROM Employees AS e
--INNER JOIN Addresses AS a
--ON e.AddressID=a.AddressID
--INNER JOIN Towns AS t
--ON a.TownID=t.TownID
--ORDER BY e.FirstName, e.LastName

----03. Sales Employees

--SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS 'DepartmentName'
--FROM Employees AS e
--INNER JOIN Departments AS d
--ON e.DepartmentID=d.DepartmentID
--WHERE d.Name = 'Sales'
--ORDER BY e.EmployeeID

----04. Employee Departments

--SELECT TOP (5) e.EmployeeID, e.FirstName, e.Salary, d.Name
--FROM Employees AS e
--INNER JOIN Departments AS d
--ON e.DepartmentID=d.DepartmentID
--WHERE e.Salary > 15000
--ORDER BY e.DepartmentID

----05. Employees Without Projects

--SELECT TOP (3) e.EmployeeID, e.FirstName
--FROM Employees AS e
--WHERE NOT e.EmployeeID IN (Select DISTINCT em.EmployeeID FROM EmployeesProjects AS em)


----06. Employees Hired After

--SELECT e.FirstName, e.LastName, e.HireDate, d.Name
--FROM Employees AS e
--INNER JOIN Departments AS d
--ON e.DepartmentID=d.DepartmentID
--WHERE e.HireDate > '1999/01/01' AND d.Name IN ('Sales', 'Finance')


----07. Employees With Project

--SELECT TOP (5) e.EmployeeID, e.FirstName, p.Name
--FROM EmployeesProjects AS ep
--INNER JOIN Projects AS p
--ON ep.ProjectID = p.ProjectID
--INNER JOIN Employees AS e
--ON ep.EmployeeID = e.EmployeeID
--WHERE p.StartDate > '2002/08/13' AND p.EndDate IS NULL
--ORDER BY e.EmployeeID


----08. Employee 24

--SELECT e.EmployeeID, e.FirstName, [ProjectName] = 
--CASE
--WHEN YEAR(p.StartDate) >= 2005 THEN NULL
--ELSE p.Name
--END
--FROM EmployeesProjects AS ep
--INNER JOIN Projects AS p
--ON ep.ProjectID = p.ProjectID
--INNER JOIN Employees AS e
--ON ep.EmployeeID = e.EmployeeID
--WHERE e.EmployeeID = 24


----09. Employee Manager

--SELECT e.EmployeeID, e.FirstName, e.ManagerID, ee.FirstName AS 'ManagerName'
--FROM Employees AS e
--INNER JOIN Employees AS ee
--ON e.ManagerID = ee.EmployeeID
--WHERE e.ManagerID IN (3, 7)
--ORDER BY e.EmployeeID

----10. Employees Summary

--SELECT TOP (50) e.EmployeeID, 
--CONCAT(e.FirstName, ' ', e.LastName) AS 'EmployeeName', 
--CONCAT(em.FirstName,' ', em.LastName) AS 'ManagerName',
--d.Name AS 'DepartmentName'
--FROM Employees AS e
--INNER JOIN Employees AS em
--ON e.ManagerID = em.EmployeeID
--INNER JOIN Departments AS d
--ON e.DepartmentID = d.DepartmentID
--ORDER BY e.EmployeeID

----11. Min Average Salary

--SELECT TOP (1) AVG(e.Salary) AS 'MinAverageSalary'
--FROM Employees AS e
--GROUP BY e.DepartmentID
--ORDER BY AVG(e.Salary)

----12. Highest Peaks in Bulgaria

--SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
--FROM MountainsCountries AS mc
--INNER JOIN Mountains AS m
--ON mc.MountainId = m.Id
--INNER JOIN Peaks AS p
--ON p.MountainId = m.Id
--WHERE mc.CountryCode IN 
--(
--	SELECT TOP (1) c.CountryCode FROM Countries AS c
--	WHERE c.CountryName = 'Bulgaria'
--) 
--AND p.Elevation > 2835
--ORDER BY p.Elevation DESC

----13. Count Mountain Ranges

--SELECT mc.CountryCode, COUNT(mc.MountainId) AS 'MountainRanges'
--FROM MountainsCountries AS mc
--GROUP BY mc.CountryCode
--HAVING mc.CountryCode IN 
--(
--	SELECT DISTINCT c.CountryCode FROM Countries AS c
--	WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
--)

----14. Countries With or Without Rivers

--SELECT TOP (5) c.CountryName, ri.RiverName
--FROM Countries AS c
--LEFT JOIN CountriesRivers AS cr
--ON c.CountryCode = cr.CountryCode
--LEFT JOIN Rivers AS ri
--ON cr.RiverId = ri.Id
--WHERE c.ContinentCode IN 
--		(
--		SELECT DISTINCT co.ContinentCode 
--		FROM Continents AS co
--		WHERE co.ContinentName = 'Africa'
--		)
--ORDER BY c.CountryName


----15. Continents and Currencies


--SELECT TableOne.ContinentCode, TableOne.CurrencyCode, TableOne.CurrencyUsage 
--FROM 
--(
--	SELECT c.ContinentCode ,c.CurrencyCode, COUNT(*) AS 'CurrencyUsage'
--	FROM Countries AS c
--	WHERE c.CurrencyCode IS NOT NULL
--	GROUP BY c.ContinentCode ,c.CurrencyCode
--	HAVING COUNT(c.CurrencyCode) > 1
--) AS TableOne
--INNER JOIN 
--(SELECT currencies.ContinentCode, MAX(currencies.CurrencyUsage) AS MaxUsage 
--FROM 
--		(
--		SELECT c.ContinentCode ,c.CurrencyCode, COUNT(*) AS 'CurrencyUsage'
--		FROM Countries AS c
--		WHERE c.CurrencyCode IS NOT NULL
--		GROUP BY c.ContinentCode ,c.CurrencyCode
--		HAVING COUNT(c.CurrencyCode) > 1
--		) AS currencies
--GROUP BY currencies.ContinentCode
--) AS TableTwo
--ON TableOne.ContinentCode = TableTwo.ContinentCode AND TableOne.CurrencyUsage = TableTwo.MaxUsage
--ORDER BY TableOne.ContinentCode

----16. Countries Without any Mountains


--SELECT COUNT(*) AS CountryCount FROM Countries AS c
--WHERE NOT c.CountryCode IN ( SELECT mc.CountryCode FROM MountainsCountries AS mc)

----17. Highest Peak and Longest River by Country

--SELECT TOP (5) c.CountryName, MAX(p.Elevation) AS 'HighestPeakElevation', MAX(ri.Length) AS 'LongestRiverLength'
--FROM Countries AS c
----
--LEFT JOIN MountainsCountries AS mc
--ON c.CountryCode = mc.CountryCode
--LEFT JOIN Mountains AS m
--ON mc.MountainId= m.Id
--LEFT JOIN Peaks AS p
--ON m.Id = p.MountainId
----
--LEFT JOIN CountriesRivers AS cr
--ON c.CountryCode = cr.CountryCode
--LEFT JOIN Rivers AS ri
--ON cr.RiverId = ri.Id
----
--GROUP BY c.CountryName
--ORDER BY MAX(p.Elevation) DESC, MAX(ri.Length) DESC, c.CountryName


----18. Highest Peak Name and Elevation by Country

--SELECT TOP (5) WITH TIES c.CountryName, ISNULL(p.PeakName,'(no highest peak)' ) AS 'HighestPeakName', ISNULL(MAX(p.Elevation), 0) AS 'HighestPeakElevation', ISNULL(m.MountainRange, '(no mountain)')
--FROM Countries AS c
--LEFT JOIN MountainsCountries AS mc
--ON c.CountryCode = mc.CountryCode
--LEFT JOIN Mountains AS m
--ON mc.MountainId = m.Id
--LEFT JOIN Peaks AS p
--ON m.Id = p.MountainId
--GROUP BY c.CountryName, p.PeakName, m.MountainRange
--ORDER BY c.CountryName, p.PeakName