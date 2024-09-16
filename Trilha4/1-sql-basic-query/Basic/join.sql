SELECT column_name(s)
FROM table1
INNER JOIN table2
ON table1.column_name = table2.column_name;


SELECT column_name(s)
FROM table1
LEFT JOIN table2
ON table1.column_name = table2.column_name;

SELECT column_name(s)
FROM table1
RIGHT JOIN table2
ON table1.column_name = table2.column_name;

SELECT column_name(s)
FROM table1
FULL OUTER JOIN table2
ON table1.column_name = table2.column_name
WHERE condition;

SELECT column_name(s)
FROM table1 T1, table1 T2
WHERE condition;