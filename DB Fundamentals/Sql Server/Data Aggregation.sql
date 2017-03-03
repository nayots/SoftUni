----01. Records’ Count

--SELECT COUNT(w.Id) AS 'Count' 
--FROM WizzardDeposits AS w

----02. Longest Magic Wand

--SELECT MAX(MagicWandSize) AS LongestMagicWand
--FROM WizzardDeposits

----03. Longest Magic Wand per Deposit Groups

--SELECT w.DepositGroup, MAX(w.MagicWandSize) AS LongestMagicWand
--FROM WizzardDeposits AS w
--GROUP BY w.DepositGroup


--04. Smallest Deposit Group per Magic Wand Size

--SELECT w.DepositGroup
--FROM WizzardDeposits AS w
--GROUP BY w.DepositGroup
--HAVING AVG(w.MagicWandSize) <= 
--								(
--								SELECT TOP (1) AVG(MagicWandSize) AS 'AverageWandSize'
--								FROM WizzardDeposits
--								GROUP BY DepositGroup
--								ORDER BY AverageWandSize
--								)
--ORDER BY AVG(w.MagicWandSize)

------
--SELECT TOP (1) WITH TIES d.DepositGroup FROM WizzardDeposits AS d
--GROUP BY d.DepositGroup
--ORDER BY AVG(d.MagicWandSize)
------
----SELECT TOP (1) WITH TIES d.DepositGroup, AVG(d.MagicWandSize) FROM WizzardDeposits AS d
----GROUP BY d.DepositGroup
----ORDER BY AVG(d.MagicWandSize)


----05. Deposits Sum

--SELECT w.DepositGroup, SUM(w.DepositAmount) AS 'TotalSum'
--FROM WizzardDeposits AS w
--GROUP BY w.DepositGroup


----06. Deposits Sum for Ollivander Family

--SELECT w.DepositGroup, SUM(w.DepositAmount) AS 'TotalSum'
--FROM WizzardDeposits AS w
--WHERE w.MagicWandCreator = 'Ollivander family'
--GROUP BY w.DepositGroup


----07. Deposits Filter

--SELECT w.DepositGroup, SUM(w.DepositAmount) AS 'TotalSum'
--FROM WizzardDeposits AS w
--WHERE w.MagicWandCreator = 'Ollivander family'
--GROUP BY w.DepositGroup
--HAVING SUM(w.DepositAmount) < 150000
--ORDER BY TotalSum DESC

----08. Deposit Charge

--SELECT w.DepositGroup, w.MagicWandCreator, MIN(w.DepositCharge) AS 'MinDepositCharge'
--FROM WizzardDeposits AS w
--GROUP BY w.DepositGroup, w.MagicWandCreator
--ORDER BY w.MagicWandCreator, w.DepositGroup

----09. Age Groups

--SELECT w.AgeGroup, COUNT(*) AS 'WizardCount' 
--FROM
--(
--	SELECT 'AgeGroup'=
--	CASE
--	WHEN z.Age BETWEEN 0 AND 10 THEN '[0-10]'
--	WHEN z.Age BETWEEN 11 AND 20 THEN '[11-20]'
--	WHEN z.Age BETWEEN 21 AND 30 THEN '[21-30]'
--	WHEN z.Age BETWEEN 31 AND 40 THEN '[31-40]'
--	WHEN z.Age BETWEEN 41 AND 50 THEN '[41-50]'
--	WHEN z.Age BETWEEN 51 AND 60 THEN '[51-60]'
--	WHEN z.Age >= 61 THEN '[61+]'
--	END
--	FROM WizzardDeposits AS z
--) AS w
--GROUP BY w.AgeGroup


----10. First Letter

--SELECT LEFT(w.FirstName,1) AS 'FirstLetter'
--FROM WizzardDeposits AS w
--WHERE w.DepositGroup = 'Troll Chest'
--GROUP BY LEFT(w.FirstName,1)
--ORDER BY FirstLetter

----11. Average Interest

--SELECT w.DepositGroup, w.IsDepositExpired, AVG(w.DepositInterest) AS 'AverageInterest'
--FROM WizzardDeposits AS w
--WHERE w.DepositStartDate > '1985/01/01'
--GROUP BY w.IsDepositExpired, w.DepositGroup
--ORDER BY w.DepositGroup DESC, w.IsDepositExpired

----12. Rich Wizard, Poor Wizard

--DECLARE @SumDifference DECIMAL(8,2)
--DECLARE @WizardId INT
--DECLARE @WizardDeposit DECIMAL(8,2)
--DECLARE @FirstEntry BIT
--DECLARE @HostWizard INT
--DECLARE @GuestWizard INT
--DECLARE @GuestWizardDeposit DECIMAL(8,2)
--DECLARE @HostWizardDeposit DECIMAL(8,2)

--SET @FirstEntry = 1
--SET @SumDifference = 0.00

--DECLARE wizardCursor CURSOR FOR
--SELECT  w.Id, w.DepositAmount
--FROM WizzardDeposits AS w

--OPEN wizardCursor
--FETCH NEXT FROM wizardCursor INTO @WizardId, @WizardDeposit

--WHILE @@FETCH_STATUS = 0
--BEGIN
		
		
--		IF @FirstEntry = 1
--		BEGIN
--		SET @HostWizard = @WizardId;
--		SET @GuestWizard = @WizardId
--		SET @GuestWizardDeposit = @WizardDeposit
--		SET @FirstEntry = 0
--		END
--		ELSE
--		BEGIN
--		SET @HostWizard = @GuestWizard
--		SET @GuestWizard = @WizardId

--		SET @HostWizardDeposit = @GuestWizardDeposit
--		SET @GuestWizardDeposit = @WizardDeposit


--		SET @SumDifference += 
--		(
--			@HostWizardDeposit
--			-
--			@GuestWizardDeposit
--			)
--		END

--		FETCH NEXT FROM wizardCursor INTO @WizardId, @WizardDeposit

--END

--CLOSE wizardCursor
--DEALLOCATE wizardCursor

--SELECT @SumDifference AS 'Sum';


----SELECT SUM(XX.DIFF) 
----FROM (SELECT DepositAmount - (SELECT DepositAmount FROM WizzardDeposits WHERE Id = g.Id + 1) 
----AS DIFF FROM WizzardDeposits g) AS XX


----13. Departments Total Salaries

--SELECT e.DepartmentID, SUM(e.Salary) AS 'TotalSalary'
--FROM Employees AS e
--GROUP BY e.DepartmentID

----14. Employees Minimum Salaries

--SELECT e.DepartmentID, MIN(Salary) AS 'MinimumSalary'
--FROM Employees AS e
--WHERE e.DepartmentID IN (2, 5, 7)
--GROUP BY e.DepartmentID


----15. Employees Average Salaries

--SELECT * 
--INTO NewEmployees
--FROM Employees
--WHERE Employees.Salary > 30000

--DELETE FROM NewEmployees
--WHERE NewEmployees.ManagerID = 42

--UPDATE NewEmployees
--SET Salary += 5000
--WHERE NewEmployees.DepartmentID = 1

--SELECT ne.DepartmentID, AVG(Salary) AS 'AverageSalary'
--FROM NewEmployees AS ne
--GROUP BY ne.DepartmentID

----DROP TABLE NewEmployees

----16. Employees Maximum Salaries

--SELECT e.DepartmentID, MAX(Salary) AS 'MaxSalary'
--FROM Employees AS e
--GROUP BY e.DepartmentID
--HAVING NOT MAX(e.Salary) BETWEEN 30000 AND 70000


----17. Employees Count Salaries

--SELECT COUNT(Salary) AS 'Count'
--FROM Employees
--WHERE Employees.ManagerID IS NULL

----18. 3rd Highest Salary


--SELECT t.DepartmentID, t.ThirdHighestSalary
--FROM
--(
--    SELECT DISTINCT w.DepartmentID,
--    (SELECT DISTINCT Salary FROM Employees WHERE DepartmentID = w.DepartmentID ORDER BY Salary DESC OFFSET 2 ROWS FETCH NEXT 1 ROW ONLY) AS ThirdHighestSalary
--        FROM Employees AS w
--) AS t
-- WHERE ThirdHighestSalary IS NOT NULL

----19. Salary Challenge

--SELECT e.FirstName, e.LastName, e.DepartmentID
--FROM Employees as e
--WHERE e.Salary > (SELECT AVG(em.Salary)
--					FROM Employees AS em
--					WHERE em.DepartmentID = e.DepartmentID
--					)
--ORDER BY e.DepartmentID
--OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY