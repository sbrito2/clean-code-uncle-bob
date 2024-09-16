--1- Even or Odd
select 
    (CASE WHEN  number % 2 = 0 then 'Even' else 'Odd' end) as is_even
from 
    numbers

--2- SQL Basics: Simple JOIN with COUNT
--https://www.codewars.com/kata/580918e24a85b05ad000010c
select 
  p.id,
  p.name,
  count(t.id) as toy_count
from people as p
join toys as t on p.id = t.people_id
group by p.id, p.name

--3- On the Canadian Border (SQL for Beginners #2)
--https://www.codewars.com/kata/on-the-canadian-border-sql-for-beginners-number-2/train/sql
select
    name,
    country
from travelers
where country NOT IN ('Canada','Mexico','USA') 

--4- BASICS: Length based SELECT with LIKE
--https://www.codewars.com/kata/5a8d94d3ba1bb569e5000198
select 
  first_name,
  last_name
from names
where first_name like '______%' --pelo menos 6 caracteres usando o like e não o length

--5- SQL: Concatenating Columns
--https://www.codewars.com/kata/sql-concatenating-columns/train/sql
select 
  CONCAT(prefix,' ',first,' ',last,' ', suffix) as title
from names

--6- SQL Basics: Up and Down
--https://www.codewars.com/kata/sql-basics-up-and-down/train/sql
select 
(CASE WHEN sum(number1) % 2 = 0 then max(number1) else min(number1) end)  as number1,
(CASE WHEN sum(number2) % 2 = 0 then max(number2) else min(number2) end)  as number2
from numbers


--7- Easy SQL: Moving Values
--https://www.codewars.com/kata/easy-sql-moving-values/train/sql
select 
  length(name) as id,
  length(CAST(legs AS varchar(10))) as name,
  length(CAST(arms AS varchar(10))) as legs,
  length(characteristics) as arms,
  length(cast (id as character)) as characteristics
from monsters

 --or
 select length(name) as id, 
       length(legs::varchar) as name, 
       length(arms::varchar) as legs, 
       length(characteristics) as arms, 
       length(id::varchar) as characteristics 
  from monsters;


--8- SQL Basics - Monsters using CASE
--https://www.codewars.com/kata/sql-basics-monsters-using-case/train/sql
select
  t.id,
  t.heads,
  b.legs,
  t.arms,
  b.tails,
  (CASE WHEN  ((t.heads > t.arms) or (b.tails > b.legs)) then 'BEAST' else 'WEIRDO' end) as species
from top_half as t
join bottom_half as b on t.id = b.id
order by species

--9- SQL with LOTR: Elven Wildcards
--https://www.codewars.com/kata/sql-with-lotr-elven-wildcards/train/sql
select
  CONCAT(
       CONCAT(UPPER(LEFT(firstname,1)),LOWER(SUBSTRING(firstname,2,length(firstname))))
      ,' ', 
       CONCAT(UPPER(LEFT(lastname,1)),LOWER(SUBSTRING(lastname,2,length(lastname))))
      ) as shortlist 
from Elves
where (firstname like '%tegil%') or (lastname like '%astar%')


--10- SQL with Street Fighter: Total Wins
--https://www.codewars.com/kata/5ac698cdd325ad18a3000170/solutions/sql
select 
 *
from
      (select
          f.name as name,
          sum(won) as won,
          sum(lost) as lost
      from fighters  as f
      join winning_moves as w on f.move_id = w.id
      where w.move not in ('Hadoken','Shouoken','Kikoken')
      group by f.name
      order by won desc) as total
LIMIT 6;


--11- SQL with Sailor Moon: Thinking about JOINs...
--https://www.codewars.com/kata/sql-with-sailor-moon-thinking-about-joins-dot-dot-dot/train/sql
select  --should contain LEFT JOIN or LEFT OUTER JOIN (not use just full join)
  s.senshi_name as sailor_senshi,
  s.real_name_jpn as real_name,
  c.name as cat,
  h.school as school
from sailorsenshi as s 
left JOIN cats as c on s.cat_id = c.id      
left JOIN schools as h on s.school_id = h.id


--12- SQL with Pokemon: Damage Multipliers
--https://www.codewars.com/kata/sql-with-pokemon-damage-multipliers/train/sql

select * 
from
    (select
      p.pokemon_name,
      (p.str * m.multiplier) as modifiedStrength,
      m.element
    from pokemon as p
    join multipliers as m on p.element_id = m.id
   ) as tabled
where modifiedStrength >= 40
order by modifiedStrength desc


--13- SQL with Harry Potter: Sorting Hat Comparators
select
    id,
    name,
    quality1,
    quality2
from
students
where quality1 in ('studious','hufflepuff')       --Ravenclaw 
    or quality2 in ('intelligent','hufflepuff')   --Hufflepuff  just having hufflepuff
    or quality1 = 'even' and quality2 = 'cunning' --Slytherin 
    or quality1 = 'brave' and quality2 != 'brave' --Gryffindor 


--14- GROCERY STORE: Real Price! ************** REVER
--https://www.codewars.com/kata/grocery-store-real-price/train/sql
select 
  p.name,
  p.weight,
  p.price,
  cast(ROUND(cast ((1000/weight)*p.price as numeric), 2)as float) as price_per_kg
from
products as p
order by price_per_kg, p.name

--15- GROCERY STORE: Inventory (AFFs)
--https://www.codewars.com/kata/5a8eb3fb57c562110f0000a1
select
  id,
  name, 
  stock
from products 
where stock <= 2 and producent = 'CompanyA'
order by id

--16- GROCERY STORE: Support Local Products
--https://www.codewars.com/kata/grocery-store-support-local-products/train/sql
select 
  count(country) as products,
  country
from products
where country in ('United States of America','Canada')
group by country
order by products desc

--17- GROCERY STORE: Logistic Optimisation
--https://www.codewars.com/kata/grocery-store-logistic-optimisation/train/sql
select count(name) as  unique_products,
producer
from products
group by producer
order by unique_products desc, producer  asc


--18- Calculating Batting Average
--https://www.codewars.com/kata/calculating-batting-average/train/sql
select *
    from 
    (select
      player_name,
      games,
      cast( ROUND( cast((hits) as numeric)/(at_bats) ,3) as varchar(50)) as batting_average
    from  yankees
    where at_bats >= 100)  as tabela
order by batting_average desc


--19- SQL Basics: Simple PIVOTING data WITHOUT CROSSTAB
--https://www.codewars.com/kata/sql-basics-simple-pivoting-data-without-crosstab/train/sql
select 
  p.name as name,
  count(case when d.detail = 'good' then 1 end) as good,
  count(case when d.detail = 'ok' then 1 end) as ok,
  count(case when d.detail = 'bad' then 1 end) as bad
from products as p
join details as d on p.id = d.product_id
group by p.name
order by p.name

--20- SQL Basics: Simple VIEW
--https://www.codewars.com/kata/sql-basics-simple-view/train/sql
CREATE VIEW members_approved_for_voucher  AS
select 
  m.id,
  m.name,
  m.email,
  sum(p.price) as total_spending
  from members as m
        join sales as s on m.id = s.member_id
        join products as p on s.product_id = p.id
        join (--departments that selled more that 100000
                select 
                d.id,
                sum(p.price) as departMoney
                from members as m
                join sales as s on m.id = s.member_id
                join products as p on s.product_id = p.id
                join departments as d on s.department_id = d.id
                where s.department_id = d.id and s.product_id = p.id
                group by d.id
                having sum(p.price) >= 10000) as d on d.id = s.department_id  
  group by m.id, m.name, m.email
  having  sum(p.price) >= 1000;
  
  select * from members_approved_for_voucher
  order by id
    
  
--21- Relational division: Find all movies two actors cast in together
--https://www.codewars.com/kata/relational-division-find-all-movies-two-actors-cast-in-together/train/sql
select
  f.title
from film as f
join (select
      film_id 
      from film_actor 
      where actor_id = 105) as sc on sc.film_id = f.film_id
join (select
      film_id 
      from film_actor 
      where actor_id = 122) as sn on sn.film_id = f.film_id
      
--desafio:  SQL Tuning: Function Calls
--https://www.codewars.com/kata/sql-tuning-function-calls/train/sql

 
 
CREATE VIEW view_valor AS
 select 
    department_id, 
    1 + pctIncrease(department_id) as muiltiplicador
 from
   departments;
 
SELECT e.employee_id,
       e.first_name,
       e.last_name,
       d.department_name,
       e.salary AS old_salary,
       e.salary *  v.muiltiplicador AS new_salary
  FROM employees   e
  join departments d on e.department_id = d.department_id
  join view_valor  v on e.department_id = v.department_id
