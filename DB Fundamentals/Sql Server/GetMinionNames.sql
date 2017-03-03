----GetMinionNames

USE MinionsDB

SELECT
	v.Name, m.Name, m.Age
FROM Villains AS v
LEFT JOIN MinionsVillains AS mv
ON mv.VillainId = v.Id
LEFT JOIN Minions AS m
ON m.Id = mv.MinionId
WHERE v.Id = @VillainId
