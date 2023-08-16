select * from orders;

select count(orderdate),monthname(orderdate) from orders order by orderdate;