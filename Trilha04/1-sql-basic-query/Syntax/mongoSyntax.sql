use magazineAB

--Studio 3T for MongoDB

db.magazine.insert(
{
  "Name" : "Forbes",
  "Date" : "2010-04-04",
  "PageTotal" : 41,
  "Number": 1
},
{
  "Name" : "Vogue",
  "Date" : "2005-08-09",
  "PageTotal" : 27,
  "Number": 3
},
{
  "Name" : "National Geographic",
  "Date" : "2016-07-07",
  "PageTotal" : 49,
  "Number": 3
},
{
  "Name" : "Forbes",
  "Date" : "2015-06-08",
  "PageTotal" : 53,
  "Number": 2
}
)

db.magazine.find({
  "Name": "Forbes"
})

db.magazine.runSQLQuery('

  SELECT * FROM magazine

');

db.magazine.runSQLQuery('

  SELECT Name, SUM(Number) AS total FROM magazine GROUP BY Name

');

--Like
db.magazine.find({Name: /o/}) 


