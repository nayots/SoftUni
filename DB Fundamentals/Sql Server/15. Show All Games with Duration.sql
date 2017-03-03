SELECT
Name,
'Part of the Day'=CASE
WHEN DATEPART(HOUR,Start) BETWEEN 0 AND 11 THEN 'Morning' --Because between takes 12 inclusive
WHEN DATEPART(HOUR,Start) BETWEEN 12 AND 17 THEN 'Afternoon'
WHEN DATEPART(HOUR,Start) BETWEEN 18 AND 23 THEN 'Evening'
END
,
'Duration'=CASE
WHEN Duration <= 3 THEN 'Extra Short'
WHEN Duration BETWEEN 4 AND 6.00 THEN 'Short'
WHEN Duration > 6 THEN 'Long'
WHEN Duration IS NULL THEN 'Extra Long'
END
FROM Games
ORDER BY Name, Duration