
----Get Villains Names

SELECT v.Name, COUNT(m.Id) AS MinionsCount FROM Villains AS v
INNER JOIN MinionsVillains AS mv
ON mv.VillainId = v.Id
INNER JOIN Minions AS m
ON m.Id = mv.MinionId
GROUP BY v.Name
HAVING COUNT(m.Id) > 3
ORDER BY MinionsCount DESC