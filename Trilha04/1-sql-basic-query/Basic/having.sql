SELECT column_name(s)
FROM table_name
WHERE condition
GROUP BY column_name(s)
HAVING condition
ORDER BY column_name(s);

SELECT COUNT(Id), Country 
  FROM Customer
 GROUP BY Country
HAVING COUNT(Id) > 10