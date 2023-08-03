
-- CRUD OPERATIONS CUSTOMERS TABLE
-- GET ALL DETAILS OF CUSTOMERS
SELECT * FROM products;

-- GET CUSTOMER BY ID
SELECT * FROM customers WHERE id=1;  

-- UPDATE CUSTOMER BY ID;
-- UPDATE customers SET contact_number='9881751213',password ='aj123' WHERE cust_id=1;

-- DELETE CUSTOMER BY ID
-- DELETE FROM customers WHERE cust_id=4;

select * from roles;
select * from users;
select * from customers;
desc userroles;

-- when we give the email of user then we give role of this user
select role from roles where id in (select roleid from userroles where userid in (select id from users where email = 'akashajab12@gmail.com'));


-- This query gives payment details where payment_id=1;
select * from payments where id=1; 


/*1)Retrive List of Customers that made purcheses after the date 2021-10-02 */
SELECT customers.id,customers.firstname,customers.lastname ,orders.date from customers 
INNER JOIN orders ON customers.id=orders.custid WHERE date>'2021-10-02';

-- view sells by category 

CREATE VIEW orderhistory AS 
SELECT categories.title,SUM(orderdetails.quantity) FROM categories,products,orderdetails 
WHERE categories.id=products.categoryid AND orderdetails.productid =products.id 
GROUP BY categories.title;

-- Creating  View products price above than average price*/
create or replace view vwproductsaboveavgprice
as select title , unitprice from products
where  unitprice  > (select avg(unitprice) from products)
order by unitprice; 

SELECT * FROM products;
select * from vwproductsaboveavgprice;

-- order by cust_id
select * from orders where custid=1;

select * from accounts;
-- //this query shows tables and its type in database.
show  full tables;

-- this query gives sum of unit price from products table.
select sum(unitprice) from products;

-- this query gives avg of unit price from products table.
select avg(unitprice) from products;

-- this query gives count  of products table.
select count(*) from products;
select * from orders;


-- this query gives category_id , category_title ,product_title
select categories.id,categories.title,products.title from products 
inner join categories on products.categoryid = categories.id;

/*this query gives list of  products which are available in provideded category with the help of nested query*/
select title from products where categoryid in (select id from categories where title="fertilizers");

/*this query gives list of  products which are available in provideded category with the help of inner join*/
SELECT products.title FROM products INNER JOIN categories ON products.categoryid = categories.id WHERE categories.title="fertilizers";

-- This query gives customer first_name, last_name whose cust_id= 4 AND status= cancelled
SELECT customers.id,customers.firstname,customers.lastname,orders.status from customers INNER JOIN orders ON customers.id = orders.custid WHERE orders.status= "delivered" AND customers.id=1 ;

-- This query gives orderdetails where cust_id =1 AND status=delivered
SELECT * FROM orders WHERE id=1 AND status="delivered"; 

--  shows all list of orders on the basis of status =cancelled 
SELECT * FROM orders WHERE status = "cancelled";

-- this query gives orderhistory
SELECT products.id, products.title,products.unitprice,orderdetails.quantity,
orders.id,orders.date,customers.id FROM (((orders
INNER JOIN   orderdetails ON orderdetails.orderid=orders.id)
INNER JOIN products ON products.id = orderdetails.productid) 
INNER JOIN  customers ON customers.id = orders.custid) order by custid;

-- this query for oder_id, product_title,quantity,total_amount as(products.unit_price*order_details.quantity) 
SELECT orderdetails.orderid,products.title, orderdetails.quantity ,(products.unitprice*orderdetails.quantity) AS totalamount 
FROM orderdetails, products 
WHERE  products.id =orderdetails.productid 
AND orderid= 1;

SELECT
  accounts.number,
  transactions.id,
  customers.firstname, 
  customers.lastname, 
  transactions.amount,
  transactions.date,
  CASE 
    WHEN transactions.fromaccountnumber=accounts.number then 'debit'
    WHEN transactions.toaccountnumber=accounts.number then 'credit'
  END AS MODETYPE 
FROM 
  transactions,customers,accounts,users
WHERE 
  (transactions.fromaccountnumber= (select number from accounts where userid=5)
  or 
  (transactions.toaccountnumber=(select number from accounts where userid=5)));

-- This query gives multiple account number of users by left join where user_id=1;
SELECT accounts.userid,
	   accounts.number
FROM accounts 
LEFT JOIN users ON accounts.id = users.id  WHERE accounts.userid =1;

-- This query gives multiple account number of users where user_id=1;
SELECT userid,
	   number
FROM accounts WHERE userid=1;

--   this query return user_id of employees;
select userid from userroles where roleid in (SELECT id from roles where role="Employee");

-- this method gives the total count of orders
SELECT count(*) from orders ;

-- this method gives the count of orders where orderdate is greater than 2020-02-07T12:14:13
SELECT count(*) from orders where date <'2020-02-07T12:14:13';

-- this query return count of orders of 1st month of 2020; 
SELECT count(*) FROM orders WHERE  date BETWEEN '2020-01-01 12:12:12' AND '2020-01-31 12:12:12';

SELECT count(*) FROM orders WHERE  date BETWEEN '2020-02-01' AND '2020-02-31';

SELECT count(*) FROM orders WHERE  date BETWEEN '2020-03-01' AND '2020-03-31';

SELECT count(*) FROM orders WHERE  date BETWEEN '2020-04-01' AND '2020-04-31';

SELECT count(*) FROM orders WHERE  date BETWEEN '2020-05-01' AND '2020-05-31';

SELECT count(*) FROM orders WHERE  date BETWEEN '2020-06-01' AND '2020-06-31';

SELECT COUNT(*) from orders where date < '2020-04-30' ;

-- //this query returns the list of products given category;
SELECT products.id, products.title,products.unitprice,products.stockavailable,products.image,categories.title from categories inner join products where categories.id=products.categoryid and categories.title='seeds';

-- get roles of user using inner join
select roles.role from userroles inner join roles on userroles.roleid =roles.id where userroles.userid=6;

-- get roles of user using nested query
SELECT role from roles where id in  (select roleid from userroles where userid=1);

-- This query gives all questions where category_id =1
select * from questions where categoryid=1;

-- this query gives all questions of particular smeid
select questions.description from questions Inner join smeanswers on questions.id = smeanswers.questionid where smeanswers.smeid=1;

-- this query gives all questions ,answers of particular smeid
select questions.description from subjectmatterexperts,smeanswers ,questions inner join answers on questions.id = answers.questionid where
answers.id =smeanswers.answerid and subjectmatterexperts.id=smeanswers.smeid and smeanswers.smeid=1;

-- This method gives answers  of particular provided question id.
select description from answers where questionid =1;

SELECT products.id,products.title,products.image,products.unitprice,cartitems.quantity FROM products inner join cartitems on products.id=cartitems.productid where cartitems.cartid=2;

-- this query gives the category of given questionid
select category from questioncategories where id in(select id from questions where id=1);

-- this query gives the details of particular category
SELECT products.id, products.title,products.unitprice,products.stockavailable,products.image,categories.title,categories.id from categories inner join products on categories.id=products.categoryid and categories.title="seeds";

-- this query gives roles of user
select role from roles where id in (select roleid from userroles where userid=1);

-- this query gives the orderhistory of particular products
SELECT products.title,products.image,products.unitprice,cartitems.quantity,cartitems.productid,carts.custid FROM products inner join 
cartitems on products.id=cartitems.productid inner join carts on carts.id=cartitems.cartid where carts.custid=2;

-- this query gives the cartid of particular customer
select id from carts where custid =2 ;

-- this query gives orderhistory of particular customer
select products.title,products.image,products.unitprice,orders.orderdate,orders.shippeddate,(products.unitprice*cartitems.quantity)as total,orders.status ,cartitems.quantity from products,orders,cartitems inner join carts on carts.id = cartitems.cartid where products.id =cartitems.productid and orders.custid =carts.custid and orders.custid=2;

-- this query gives orderdetails of particular orderid
select orders.id, products.title,products.image,products.unitprice,orders.orderdate,orders.shippeddate,(products.unitprice*cartitems.quantity)as total,orders.status ,cartitems.quantity from orderdetails,orders,cartitems inner join products on products.id = cartitems.productid where orders.id = orderdetails.orderid and orderdetails.productid =cartitems.productid and orders.id=1;

-- this query gives the question and questiondate
select questions.description,customerquestions.questiondate from questions 
inner join customerquestions on customerquestions.questionid=questions.id where customerquestions.custid=2;

-- this query gives orderhistory of particular orderid
select orders.id,customers.firstname,customers.lastname, products.title,products.unitprice,orders.custid,(products.unitprice*cartitems.quantity)as total,orders.status ,cartitems.quantity from customers,orderdetails,orders,cartitems inner join products on products.id = cartitems.productid where orders.id = orderdetails.orderid 
and orderdetails.productid =cartitems.productid and customers.id=orders.custid and orders.id=3;
   
SELECT orders.id,customers.firstname,customers.lastname,date(orders.orderdate),time(orders.orderdate) from orders inner join customers
on customers.id=orders.custid;
        
-- Cast(orders.orderdate as date) AS date;
select DATE(orderdate)  from orders ;
select TIME(orderdate)  from orders;

-- this query gives details in between date
SELECT * FROM customerquestions WHERE  questiondate BETWEEN '2022-05-15' AND '2023-06-28';

-- this query gives details of particular customer
select * from customerquestions where custid=2;

-- this query gives details of particular question
select * from customerquestions where questionid=2;

-- get name where questionid=1
select name from subjectmatterexperts inner join smeanswers on subjectmatterexperts.id = smeanswers.smeid where smeanswers.questionid=1;

-- Get answer count of particular question
select count(*) from answers where questionid=2;

-- get answer of particular question
select distinct(questions.description)as question ,(answers.description) as answers from questions 
inner join answers on questions.id =answers.questionid 
inner join  customerquestions on customerquestions.questionid =questions.id 
where customerquestions.questionid=2;

select customerquestions.id, questions.description,customerquestions.questiondate,(select count(*) from answers where questionid=customerquestions.questionid)as answers  from questions inner join customerquestions on customerquestions.questionid=questions.id where customerquestions.custid=2;

--stored procedure for updation of stock available
CALL stockavailableupdateinventory(1,2,500);

-- stored procedure create order
-- CALL CreateOrder(2);

-- this query gives the list of shippers where userid=1;
select * from shippers where userid =1;

-- this query gives the list of orders where status=delivered;
select * from orders where status="delivered";

--this query gives the productlist where categoryid=1;
select * from products where categoryid=1;

select * from subjectmatterexperts;


SELECT * FROM ORDERS;

-- yearly performance of subjectmatterexperts
SELECT name,smeid,count(*)as count FROM SMEANSWERS 
inner join subjectmatterexperts on SMEANSWERS.smeid=subjectmatterexperts.id WHERE YEAR(answerdate) = 2023 
group by smeid;

--this query is used for showing orders data in chart
SELECT MONTHNAME(orderdate) AS monthname, COUNT(*) AS count FROM orders WHERE YEAR(orderdate) = 2020 GROUP BY MONTHNAME(orderdate), MONTH(orderdate) ORDER BY MONTH(orderdate) ASC;

