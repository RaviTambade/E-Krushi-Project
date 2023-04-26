--  drop database E_Krushi;
CREATE DATABASE E_Krushi;
 USE E_Krushi;

CREATE TABLE users(user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,email varchar(255) unique,password varchar(255),contact_number varchar(255));

CREATE TABLE roles(role_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, role varchar(250));
              
CREATE TABLE customers(cust_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,first_name VARCHAR(255),last_name VARCHAR(25));
                      
CREATE TABLE categories(category_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,category_title varchar(255),description varchar(255),image varchar(255));
                        
CREATE TABLE products(product_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,product_title varchar(255),unit_price double,stock_available INT,image varchar(255),category_id INT NOT NULL, CONSTRAINT fk_category_id FOREIGN KEY (category_id) REFERENCES categories(category_id) ON UPDATE CASCADE ON DELETE CASCADE);
 
CREATE TABLE orders(order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_date DATETIME NOT NULL ,shipped_date DATETIME NOT NULL,cust_id INT NOT NULL,CONSTRAINT fk FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE, total DOUBLE ,status ENUM('approved','initiated','cancelled','delivered','inprogress') NOT NULL);

CREATE TABLE order_details(order_details_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_id INT NOT NULL,CONSTRAINT fk_04 FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE ,product_id INT NOT NULL ,CONSTRAINT fk_05 FOREIGN KEY (product_id) REFERENCES products(product_id)ON UPDATE CASCADE ON DELETE CASCADE,quantity INT NOT NULL,discount DOUBLE DEFAULT 0);  

CREATE TABLE carts(cart_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cust_id INT NOT NULL,CONSTRAINT fk_1 FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE, total DOUBLE ,status ENUM('approved','initiated','cancelled','delivered','inprogress') NOT NULL);

CREATE TABLE addresses(address_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cust_id INT NOT NULL,CONSTRAINT fk_cust_id FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,address_mode ENUM('permanent','billing') NOT NULL,house_number varchar(255),landmark VARCHAR(255),city VARCHAR(255) NOT NULL,state VARCHAR(255) NOT NULL,country VARCHAR(255) NOT NULL,pincode VARCHAR(255) NOT NULL);

CREATE TABLE cart_items(cart_items_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cart_id INT NOT NULL,CONSTRAINT fk_02 FOREIGN KEY (cart_id) REFERENCES carts(cart_id)ON UPDATE CASCADE ON DELETE CASCADE,product_id INT NOT NULL,CONSTRAINT fk_03 FOREIGN KEY (product_id) REFERENCES products(product_id) ,quantity INT NOT NULL); 

CREATE TABLE payments(payment_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,payment_date DATETIME NOT NULL , payment_mode ENUM('cash on delivery','online payment'),user_id INT NOT NULL,CONSTRAINT fk_user_id_5 FOREIGN KEY (user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE,order_id INT NOT NULL,CONSTRAINT fk_order_id FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE departments(dept_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, dept_name VARCHAR(50),location VARCHAR(45));

CREATE TABLE employees(employee_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,first_name VARCHAR(255),last_name VARCHAR(250),birth_date DATE ,hire_date DATE,photo VARCHAR(250),reports_to INT NOT NULL,dept_id INT NOT NULL,CONSTRAINT fk_001 FOREIGN KEY (dept_id) REFERENCES departments(dept_id) ON UPDATE CASCADE ON  DELETE CASCADE);

CREATE TABLE shippers(shipper_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,company_name VARCHAR(255));

CREATE TABLE suppliers(supplier_id INT NOT NULL AUTO_iNCREMENT PRIMARY KEY, company_name varchar(50),supplier_name varchar(50),address varchar(50),city VARCHAR(50),state VARCHAR(40));

CREATE TABLE accounts(account_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, account_number varchar(250) UNIQUE,ifsc_code varchar(250),register_date DATETIME, user_id INT NOT NULL, CONSTRAINT fk_user_id_1 FOREIGN KEY (user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE transactions(transaction_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, from_account_number VARCHAR(60)NOT NULL,CONSTRAINT fk_acc_no FOREIGN KEY(from_account_number) REFERENCES accounts(account_number)ON UPDATE CASCADE ON DELETE CASCADE, to_account_number VARCHAR(60) NOT NULL,CONSTRAINT fk_acc_no1 FOREIGN KEY(to_account_number) REFERENCES accounts(account_number)ON UPDATE CASCADE ON DELETE CASCADE,transaction_date DATETIME NOT NULL, amount DOUBLE);

CREATE TABLE user_roles(user_id INT NOT NULL,CONSTRAINT fk_user_id_2 FOREIGN KEY(user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE ,role_id INT NOT NULL,CONSTRAINT fk_role_id FOREIGN KEY(role_id) REFERENCES roles(role_id) ON UPDATE CASCADE ON DELETE CASCADE);
  
CREATE TABLE feedbacks(feedback_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,description VARCHAR(255),user_id INT NOT NULL ,CONSTRAINT fk_022 FOREIGN KEY (user_id) REFERENCES users(user_id));

INSERT INTO users(email,password,contact_number) VALUES ('akashajab12@gmail.com','akash@12',9881571268);
INSERT INTO users(email,password,contact_number) VALUES ('pragatibangar@gmail.com','pragati@12',7498035692);
INSERT INTO users(email,password,contact_number) VALUES ('akshaytanpure@gmail.com','akshay@12',9881571271);
INSERT INTO users(email,password,contact_number) VALUES ('abhaynavale@gmail.com','abhay@12',9881571272);
INSERT INTO users(email,password,contact_number) VALUES ('rohitgore@gmail.com','rohit@12',9881571273);
INSERT INTO users(email,password,contact_number) VALUES ('rushikeshchikne@gmail.com','rushikesh12',9881571274);
INSERT INTO users(email,password,contact_number) VALUES ('shubham@gmail.com','shubham@12',9881571275);
INSERT INTO users(email,password,contact_number) VALUES ('chetan@gmail.com','chetan@12',9081571275);
INSERT INTO users(email,password,contact_number) VALUES ('abhishek@gmail.com','abhishek@12',9181571275);
INSERT INTO users(email,password,contact_number) VALUES ('anil@gmail.com','anil@12',9281571275);
INSERT INTO users(email,password,contact_number) VALUES ('rohan@gmail.com','rohan@12',9381571275);
INSERT INTO users(email,password,contact_number) VALUES ('ajay@gmail.com','ajay@12',9481571275);
INSERT INTO users(email,password,contact_number) VALUES ('vijay@gmail.com','vijay@12',9581571275);



-- ROLE TABLE DATA
INSERT INTO roles(role) VALUES ('Admin');
INSERT INTO roles(role) VALUES ('Customer');
INSERT INTO roles(role) VALUES ('Employee');
INSERT INTO roles(role) VALUES ('Supplier');
INSERT INTO roles(role) VALUES ('Shipper');

select * from roles;

-- CUSTOMERS DATA
INSERT INTO customers(first_name,last_name,user_id) VALUES(akash,ajab,1);                       
INSERT INTO customers(first_name,last_name,user_id) VALUES(pragati,bangar,2);
INSERT INTO customers(first_name,last_name,user_id) VALUES(akshay,tanpure,3);             
INSERT INTO customers(first_name,last_name,user_id) VALUES(abhay,navale,4);     
INSERT INTO customers(first_name,last_name,user_id) VALUES(rohit,gore,5);     
INSERT INTO customers(first_name,last_name,user_id) VALUES(rushikesh,chikne,6);                       
INSERT INTO customers(first_name,last_name,user_id) VALUES(shubham,teli,7);


-- CATEGORIES DATA
INSERT INTO categories(category_title,description,image) VALUES('seeds','crops growth fastly','/image/fertilizer.jpg');
INSERT INTO categories(category_title,description,image) VALUES('chemical fertilizer','crops growth fastly','/image/fertilizer.jpg');
INSERT INTO categories(category_title,description,image) VALUES('organic fertilizer','crops growth fastly','/image/fertilizer.jpg');
INSERT INTO categories(category_title,description,image) VALUES('pesticide','for spraying','/image/pesticide.jpg');

-- PRODUCTS DATA
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('oats',100,500,'/image/oats.jpg',1);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('wheat',100,50,'/image/sunflower.jpg',1);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('corn',100,50,'/image/sunflower.jpg',1);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('barley',100,50,'/image/sunflower.jpg',1);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('sorghum',100,50,'/image/sunflower.jpg',1);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('sunflower',100,50,'/image/sunflower.jpg',1);

-- CHEMICAL FERTILIZERS
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('Urea (CO(NH2)2',350,1000,'/image/urea.jpg',2);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('Ammonium nitrate (NH4NO3)',600,2000,'/image/ammonium.jpg',2);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('Diammonium phosphate (NH4)2HPO4',100,50,'/image/diammoniumphosphate.jpg',2);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('Triple superphosphate (Ca(H2PO4)2',100,50,'/image/triplesuperphosphate.jpg',2);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('Potassium chloride (KCl)',100,50,'/image/potassiumchloride.jpg',2);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('Potassium sulfate (K2SO4)',100,50,'/image/potassiumsulfate.jpg',2);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('Calcium ammonium nitrate (Ca(NO3)2•NH4NO3•10H2O)',100,50,'/image/calciumnitrate.jpg',2);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('Monoammonium phosphate (NH4H2PO4)',100,50,'/image/monoammoniumphosphate.jpg',2);

-- ORGANIC FERTILIZERS
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('wood ash',100,500,'/image/woodash.jpg',3);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('bone meal',100,500,'/image/bonemeal.jpg',3);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('blood meal',100,500,'/image/bloodmeal.jpg',3);
-- INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('manure',100,500,'/image/manure.jpg',3);

-- PESTISIDES
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('karate',100,500,'/image/woodash.jpg',4);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('soloman',100,500,'/image/manure.jpg',4);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('wood ash',100,500,'/image/woodash.jpg',4);



-- ORDERS DATA
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-12-01 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-11-01 12:12:12','2020-11-02 10:02:12',1,800,'delivered');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-10-01 12:12:12','2020-10-02 10:22:12',1,700,'cancelled');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2021-12-01 12:10:12','2021-12-02 10:12:12',2,500,'initiated');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2022-11-01 12:11:00','2022-11-02 10:02:12',8,1800,'delivered');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2023-10-01 12:13:11','2023-10-02 10:22:12',7,7100,'cancelled');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-05-01 12:14:13','2020-05-02 10:12:12',3,5020,'initiated');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2022-01-01 12:40:22','2022-01-02 10:02:12',6,8007,'delivered');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2023-10-01 12:55:45','2023-10-02 10:22:12',5,7006,'cancelled');


-- ORDER_DETAILS DATA
INSERT INTO order_details(order_id,product_id,quantity) VALUES (1,2,20);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (2,2,25);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (2,1,40);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (9,3,15);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (8,3,48);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (5,2,41);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (4,4,63);



-- CARTS DATA
INSERT INTO carts(cust_id) VALUES (1);
INSERT INTO carts(cust_id) VALUES (1);
INSERT INTO carts(cust_id) VALUES (2);
INSERT INTO carts(cust_id) VALUES (2);
INSERT INTO carts(cust_id) VALUES (2);
INSERT INTO carts(cust_id) VALUES (3);
INSERT INTO carts(cust_id) VALUES (3);
INSERT INTO carts(cust_id) VALUES (4);
INSERT INTO carts(cust_id) VALUES (3);
INSERT INTO carts(cust_id) VALUES (3);
INSERT INTO carts(cust_id) VALUES (4);


-- CARTS ITEMS DATA
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(1,1,20);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(2,2,40);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(2,2,40);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(3,4,10);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(3,4,50);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(3,2,260);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(4,3,200);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(4,3,201);


-- PAYMENTS DATA
INSERT INTO payments(payment_date,payment_mode,user_id,order_id) VALUES('2022-03-08 12:08:19','cash on delivery',1,1);
INSERT INTO payments(payment_date,payment_mode,user_id,order_id) VALUES('2022-03-08 12:08:19','online payment',2,1);
INSERT INTO payments(payment_date,payment_mode,user_id,order_id) VALUES('2022-03-08 12:08:19','cash on delivery',3,2);
INSERT INTO payments(payment_date,payment_mode,user_id,order_id) VALUES('2022-03-08 12:08:19','online payment',4,3);
INSERT INTO payments(payment_date,payment_mode,user_id,order_id) VALUES('2022-03-08 12:08:19','cash on delivery',9,4);
INSERT INTO payments(payment_date,payment_mode,user_id,order_id) VALUES('2022-06-10 12:45:30','cash on delivery',7,2);


-- ADDRESS DATA
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode) VALUES(1,'permanent','houseNo.32','akshara garden','pune','maharashtra','india','410503');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode) VALUES(1,'billing','houseNo.32','akshara dairy','pune','maharashtra','india','410502');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode) VALUES(2,'permanent','houseNo.32','season mall','pune','maharashtra','india','410504');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode) VALUES(3,'billing','houseNo.32','Peth-Kurwandi Road','Manchar','Maharashtra','India','410506');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode) VALUES(4,'permanent','houseNo.234','Pune-Nashik Highway','Rajgurunagar','Maharashtra','India','1213');


-- DEPARTMENT DATA
INSERT INTO departments(dept_name,location) VALUES('account', 'pune');
INSERT INTO departments(dept_name,location) VALUES('hr', 'manchar');
INSERT INTO departments(dept_name,location) VALUES('sales', 'nashik');
INSERT INTO departments(dept_name,location) VALUES('finance', 'nerul');



-- EMPLOYESS DATA
INSERT INTO employees(first_name,last_name,birth_date,hire_date,photo,reports_to,dept_id,user_id) VALUES('chetan','ajab','1999-09-15','2022-05-12','/image/akash.jpg',3,1,8);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,photo,reports_to,dept_id,user_id) VALUES('abhishek','Bangar','2005-09-15','2022-05-12','/image/vedant.jpg',2,1,8,9);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,photo,reports_to,dept_id,user_id) VALUES('anil','hinge','2023-09-15','2022-06-14','/image/sahil.jpg',2,2,10);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,photo,reports_to,dept_id,user_id) VALUES('rohan','amate','2015-09-15','2022-07-13','/image/prakash.jpg',4,4,11);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,photo,reports_to,dept_id,user_id) VALUES('ajay','lanke','1988-09-15','2022-08-11','/image/nilesh.jpg',1,3,12);


-- SHIPPERS DATA
INSERT INTO shippers(company_name) VALUES('agrotech pvt.ltd');
INSERT INTO shippers(company_name) VALUES('agrilens pvt.ltd');
INSERT INTO shippers(company_name) VALUES('croproot pvt.ltd');
INSERT INTO shippers(company_name) VALUES('greenery pvt.ltd');


-- SUPPLIERS DATA
INSERT INTO suppliers(company_name,supplier_name,address,city,state) VALUES('kaveri','abhishek bhor','pimpalgaon','pune','maharashtra');
INSERT INTO suppliers(company_name,supplier_name,address,city,state) VALUES('kalash seeds','pratik wagh','khadaki','pune','maharashtra');
INSERT INTO suppliers(company_name,supplier_name,address,city,state) VALUES('greenary','datta dhoble','manchar','pune','maharashtra');
INSERT INTO suppliers(company_name,supplier_name,address,city,state) VALUES('kavya','kavya bangar','chandoli','8903816782','pune','maharashtra');

-- USER ROLES DATA
INSERT INTO user_roles(user_id,role_id) VALUES (1,1);
INSERT INTO user_roles(user_id,role_id) VALUES(2,1);
INSERT INTO user_roles(user_id,role_id) VALUES(3,1);
INSERT INTO user_roles(user_id,role_id) VALUES(6,2);
INSERT INTO user_roles(user_id,role_id) VALUES(8,2);
INSERT INTO user_roles(user_id,role_id) VALUES(6,3);


-- ACCOUNTS DATA
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031201','KOTAK000286','2022-04-05  01:02:03',1);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031202','ICICI000286','2022-11-25  01:12:03',1);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031203','MAHB0000286','2022-12-30  11:02:03',3);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031204','PDCC0000286','2022-05-10  12:02:03',2);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031205','SBIB0000286','2022-09-07  06:02:03',2);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031206','AXIS0000286','2022-11-03  07:02:03',4);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031207','BARB0000286','2022-10-20  08:02:03',7);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031208','BARB0000286','2022-10-10  08:02:03',7);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031209','BARB0000286','2022-10-10  08:02:03',7);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031210','AXIS0000286','2022-09-08  08:50:03',5);



-- TRANSACTIONS DATA
INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES('4105031201','4105031202','2022-03-09  08:45:23',45000);
INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES('4105031203','4105031205','2022-12-09  01:40:10',12000);
INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES('4105031204','4105031206','2022-08-09  10:30:20',25000);
INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES('4105031207','4105031205','2022-10-09  06:35:23',30000);
INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES('4105031208','4105031205','2022-11-09  06:35:23',120000);
INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES('4105031209','4105031205','2022-11-09  06:35:40',6000);



-- FEEDBACKS DATA
INSERT INTO feedbacks(description,user_id) VALUES ('very good facilitities',1);
INSERT INTO feedbacks(description,user_id) VALUES ('good quality of products',2);
INSERT INTO feedbacks(description,user_id) VALUES ('very good for farmers ',3);
INSERT INTO feedbacks(description,user_id) VALUES ('farmers are protected from frauds',4);

select * from DEPARTMENTS;
SELECT * FROM EMPLOYEES;
select * from feedbacks;


-- CRUD OPERATIONS CUSTOMERS TABLE
-- GET ALL DETAILS OF CUSTOMERS
SELECT * FROM customers;

-- GET CUSTOMER BY ID
SELECT * FROM customers WHERE cust_id=1;  

-- UPDATE CUSTOMER BY ID;
-- UPDATE customers SET contact_number='9881751213',password ='aj123' WHERE cust_id=1;

-- DELETE CUSTOMER BY ID
-- DELETE FROM customers WHERE cust_id=4;

select * from roles;
select * from users;
select * from customers;
desc user_roles;


-- when we give the name of customer then we give role of this customer
select role from roles where role_id IN (select role_id from user_roles where user_id IN (select user_id from users where password IN (select password from customers where first_name='pooja' and last_name='divekar')));



-- PRINT THE ALL CUSTOMERS
select * from customers where password IN (select password from users where user_id in (select user_id from user_roles where role_id In (select role_id from roles where role='customer')));

-- This query gives payment details where payment_id=1;
select * from payments where payment_id=1; 

select * from payments;
select * from customers;

-- This query gives payment details of provided customer first_name, last_name
SELECT * FROM payments WHERE user_id IN (SELECT user_id FROM users WHERE email IN (SELECT email FROM customers WHERE first_name='pooja' AND  last_name='divekar'));

select customers.first_name,customers.last_name ,customers.email,payments.payment_id from customers,payments,users where customers.email=users.email and payments.user_id=users.user_id ;

/*1)Retrive List of Customers that made purcheses after the date 2021-10-02 */
SELECT customers.cust_id,customers.first_name,customers.last_name ,orders.order_date from customers 
INNER JOIN orders ON customers.cust_id=orders.cust_id WHERE order_date>'2021-10-02';

-- view sells by category 

CREATE VIEW order_history AS 
SELECT categories.category_title,SUM(order_details.quantity) FROM categories,products,order_details 
WHERE categories.category_id=products.category_id AND order_details.product_id =products.product_id 
GROUP BY categories.category_title;

-- Creating  View products price above than average price*/
create or replace view vw_products_above_avgprice
as select product_title , unit_price from products
where  unit_price  > (select avg(unit_price) from products)
order by unit_price; 

select * from vw_products_above_avgprice;

-- order by cust_id
select * from orders where cust_id=1;

-- //this query shows tables and its type in database.
show  full tables;

-- this query gives sum of unit price from products table.
select sum(unit_price) from products;

-- this query gives avg of unit price from products table.
select avg(unit_price) from products;

-- this query gives count  of products table.
select count(*) from products;
select * from products;


-- this query gives category_id , category_title ,product_title
select categories.category_id,categories.category_title,products.product_title from products 
inner join categories on products.category_id = categories.category_id;

/*this query gives list of  products which are available in provideded category with the help of nested query*/
select product_title from products where category_id in (select category_id from categories where category_title="organic fertilizer");

/*this query gives list of  products which are available in provideded category with the help of inner join*/
SELECT products.product_title FROM products INNER JOIN categories ON products.category_id = categories.category_id WHERE category_title="organic fertilizer";

-- This query gives customer first_name, last_name whose cust_id= 4 AND status= cancelled
SELECT customers.cust_id,customers.first_name,customers.last_name,orders.status from customers INNER JOIN orders ON customers.cust_id = orders.cust_id WHERE orders.status= "cancelled" AND customers.cust_id=4 ;

-- This query gives orderdetails where cust_id =1 AND status=delivered
SELECT * FROM orders WHERE cust_id=1 AND status="delivered"; 

--  shows all list of orders on the basis of status =cancelled 
SELECT * FROM orders WHERE status = "cancelled";

select * from products;
select * from payments;

select * from order_details;
select * from carts;
select * from customers;

SELECT * FROM order_details;
select * from categories;
select * from feedbacks;
select * from transactions;
select * from accounts;


-- this query gives orderhistory
SELECT products.product_id, products.product_title,products.unit_price,order_details.quantity,
orders.order_id,orders.order_date,customers.cust_id FROM (((orders
INNER JOIN   order_details ON order_details.order_id=orders.order_id)
INNER JOIN products ON products.product_id = order_details.product_id) 
INNER JOIN  customers ON customers.cust_id = orders.cust_id) order by cust_id;

-- this query for oder_id, product_title,quantity,total_amount as(products.unit_price*order_details.quantity) 
SELECT order_details.order_id,products.product_title, order_details.quantity ,(products.unit_price*order_details.quantity) AS total_amount 
FROM order_details, products 
WHERE  products.product_id =order_details.product_id 
AND order_id= 1;

select * from transactions;


SELECT
  accounts.account_number,
  transactions.transaction_id,
  customers.first_name, 
  customers.last_name, 
  transactions.amount,
  transactions.transaction_date,
  CASE 
    WHEN transactions.from_account_number=accounts.account_number then 'debit'
    WHEN transactions.to_account_number=accounts.account_number then 'credit'
  END AS MODETYPE 
FROM 
  transactions,customers,accounts,users
WHERE 
  (transactions.from_account_number= (select account_number from accounts where user_id=5)
  or 
  (transactions.to_account_number=(select account_number from accounts where user_id=5)));


-- this query gives user_id,customers first_name,customers last_name 
select users.user_id ,
       customers.first_name,
       customers.last_name
from customers 
INNER JOIN users ON users.email=customers.email;

-- This query gives multiple account number of users by left join where user_id=1;
SELECT accounts.user_id,
	   accounts.account_number
FROM accounts 
LEFT JOIN users ON accounts.account_id = users.user_id  WHERE accounts.user_id =1;

-- This query gives multiple account number of users where user_id=1;
SELECT user_id,
	   account_number
FROM accounts WHERE user_id=1;

-- This query gives first_name,last_name where user_id =5;
select first_name,last_name from customers where email in (select email from users where user_id= 5);

-- this procedure is used for updation of stock available when the order is aaded in orderdetails

DELIMITER $$
CREATE PROCEDURE stock_available_update_inventory (IN order_id INT,IN product_id INT ,IN quantity INT )
BEGIN
START TRANSACTION;
INSERT INTO order_details(order_id,product_id,quantity) VALUES (order_id,product_id,quantity);
UPDATE products SET stock_available=stock_available-quantity WHERE products.product_id=product_id;
COMMIT;
END $$
DELIMITER ;

CALL stock_available_update_inventory(1,2,500);

select * from roles;
select * from user_roles;

--  how to find employees from users table 
select * from employees where email in (select email from users where user_id in (select user_id from user_roles where role_id in (SELECT role_id from roles where role="Employee"))) ;
  
--   this query return user_id of all employees;
select user_id from user_roles where role_id in (SELECT role_id from roles where role="Employee");


select employees.first_name ,employees.last_name ,users.user_id from employees
inner join  users on employees.email=users.email;
