-- Active: 1694968636816@@127.0.0.1@3306@ekrushi
SELECT orders.total,payments.date,payments.paymentstatus,payments.mode from payments  INNER JOIN orders ON
orders.id=payments.orderid where orderid=1;
SELECT shippeddate,total from orders where id=1;
select (questions.description)as question,(questioncategories.category)as category,(answers.description)as answer from questions 
INNER join answers  on questions.id = answers.questionid
INNER join questioncategories on questions.categoryid=questioncategories.id where questions.id=1;

SELECT customerquestions.customerid,customerquestions.questionid,customerquestions.questiondate,questions.description from questions INNER JOIN customerquestions on questions.id =customerquestions.questionid ;
SELECT * from customerquestions;
select * from questioncategories;
select * from orders;
select customerquestions.id, questions.description,customerquestions.questiondate,(select count(*) from answers where questionid=customerquestions.questionid)as answers  from questions inner join customerquestions on customerquestions.questionid=questions.id where customerquestions.customerid=1;
SELECT (payments.id)as paymentid,  (orders.total) as total,(payments.date)as date,(payments.paymentstatus) as paymentstatus,(payments.mode)as mode from payments  INNER JOIN orders ON orders.id=payments.orderid where payments.orderid=1;
-- customer payments

select (date)as paymentdate,paymentstatus,orderid FROM payments where orderid in (SELECT id from orders where customerid =2);
SELECT * from orders;

-- customer orderdetails query
select productdetails.size,productdetails.unitprice,products.image,products.title,orderdetails.quantity,(productdetails.unitprice * orderdetails.quantity) as total from products 
Inner JOIN productdetails on products.id=productdetails.productid
INNER join  orderdetails on productdetails.id=orderdetails.productdetailsid
INNER join orders on  orders.id=orderdetails.orderid where orders.id=4;
show TABLES;

-- query for find questionid releted questions
SELECT id,description FROM questions where id!=6 AND categoryid  IN (select categoryid from questions WHERE id=6);
SELECT * FROM questions;
select orders.orderdate from orders LEFT join payments on orders.id=payments.orderid ;

select * from roles;

select count(orderdate),monthname(orderdate) from orders order by orderdate;

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

--this query is used for showing product sale
select title,productid,sum(quantity) as quantity from products inner join orderdetails on products.id=orderdetails.productid  
inner join orders on orders.id=orderdetails.orderid
where year(shippeddate)=2020 group by productid;

--this query gives the count of cash and online payment
select mode,count(*) as count from payments where year(date)=2022 group by mode;

--this query is used for showing product sales for particular customer
select title,productid,sum(quantity) as total from products inner join orderdetails on products.id=orderdetails.productid inner join orders on orders.id = orderdetails.orderid where custid =2 group by productid ;

--this query is used for showing order chart
select status,sum(status) as total from orders where year(orderdate)=2020 group by status;

--this query is used for showing order chart of particular customer
select status,sum(status) as total from orders where year(orderdate)=2020 and custid=2 group by status;

--this query is used for showing total revenue in year
SELECT MONTHNAME(orderdate) AS monthname,sum(total) as total from orders where year(orderdate)=2020 group by MONTHNAME(orderdate), MONTH(orderdate) ORDER BY MONTH(orderdate) ASC;


--weekly sme performance
SELECT CONCAT('week', ROW_NUMBER() OVER (ORDER BY WEEK(answerdate))) AS week_number, COUNT(*) AS count  FROM SMEANSWERS WHERE answerdate >= '2023-06-05' AND answerdate <= ' 2023-08-15'  GROUP BY YEAR(answerdate), WEEK(answerdate);

--weekly orders
SELECT CONCAT('week', ROW_NUMBER() OVER (ORDER BY WEEK(orderdate))) AS week_number, COUNT(*) AS count  FROM orders WHERE orderdate >= '2023-02-05' AND orderdate <= '2023-12-15'  GROUP BY YEAR(orderdate), WEEK(orderdate);


--this query gives data where userid=1
SELECT * FROM customers where userid=2;

--this query gives data where userid=1
select * from userroles where userid=1;

-- this query gives the roles of particular user
select id from users where contactnumber ='9881571268';
select roles.role from roles inner join userroles on roles.id = userroles.roleid where userroles.userid=2;
                 
SELECT * FROM orders;

SELECT products.id as productid, SUM(orderdetails.quantity) AS TotalQuantity,products.title
            FROM orderdetails 
            INNER join productdetails ON productdetails.id=orderdetails.productdetailsid
            INNER JOIN products ON productdetails.productid=products.id
            GROUP BY productid
            ORDER BY TotalQuantity DESC
            LIMIT 5;



SELECT
    products.id AS productid,
    SUM(orderdetails.quantity) AS TotalQuantity,
    products.title,
    orders.orderdate
FROM
    orderdetails
INNER JOIN
    productdetails ON productdetails.id = orderdetails.productdetailsid
INNER JOIN
    orders ON orders.id = orderdetails.orderid
INNER JOIN
    products ON productdetails.productid = products.id
WHERE
    DATE(orders.orderdate) BETWEEN DATE_SUB('2023-08-10', INTERVAL DAY('2023-08-10') - 1 DAY)
    AND LAST_DAY('2023-08-10')
GROUP BY
    productid
ORDER BY
    TotalQuantity DESC
LIMIT
    5;


 SELECT
    products.id AS productid,
    SUM(orderdetails.quantity) AS TotalQuantity,
    products.title,
    orders.orderdate
FROM
    orderdetails
INNER JOIN
    productdetails ON productdetails.id = orderdetails.productdetailsid
INNER JOIN
    orders ON orders.id = orderdetails.orderid
INNER JOIN
    products ON productdetails.productid = products.id
WHERE
 DATE(orders.orderdate) BETWEEN DATE_SUB('2023-08-10', INTERVAL (DAYOFWEEK('2023-08-10') - 1) DAY) 
    AND DATE_ADD('2023-08-10', INTERVAL (7 - DAYOFWEEK('2023-08-10')) DAY)
GROUP BY
    productid
ORDER BY
    TotalQuantity DESC
LIMIT
    5;  



 SELECT
    products.id AS productid,
    SUM(orderdetails.quantity) AS TotalQuantity,
    products.title,
    orders.orderdate
FROM
    orderdetails
INNER JOIN
    productdetails ON productdetails.id = orderdetails.productdetailsid
INNER JOIN
    orders ON orders.id = orderdetails.orderid
INNER JOIN
    products ON productdetails.productid = products.id
WHERE
  DATE(orderdate) = DATE_SUB('2023-08-10', INTERVAL 1 DAY)
GROUP BY
    productid
ORDER BY
    TotalQuantity DESC
LIMIT
    5;  

SELECT
    products.id AS productid,
    SUM(orderdetails.quantity) AS TotalQuantity,
    products.title,
    orders.orderdate
FROM
    orderdetails
INNER JOIN
    productdetails ON productdetails.id = orderdetails.productdetailsid
INNER JOIN
    orders ON orders.id = orderdetails.orderid
INNER JOIN
    products ON productdetails.productid = products.id
WHERE
 DATE(orders.orderdate) = '2023-08-10'
GROUP BY
    productid
ORDER BY
    TotalQuantity DESC
LIMIT
    5;  




select * from smeanswers ;


select * from productdetails;
 
 
select * from categories;

show TABLES;

--  categoriwise product orders sell
 select COUNT(*) from orders
    INNER JOIN orderdetails on orders.id=orderdetails.orderid
    INNER JOIN productdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN products on productdetails.productid=products.id
    INNER JOIN categories ON products.categoryid=categories.id
    WHERE categories.title="seeds" AND DATE(orders.orderdate) BETWEEN DATE_SUB('2023-07-01', INTERVAL (DAYOFWEEK('2023-07-11') - 1) DAY) 
    AND DATE_ADD('2023-07-11', INTERVAL (7 - DAYOFWEEK('2023-07-11')) DAY) AND storeid=4; 
  


        select questions.description from questions
         Inner join answers on questions.id = answers.questionid 
         inner join smeanswers on answers.id=smeanswers.answerid
         where smeanswers.smeid=5;
                        





