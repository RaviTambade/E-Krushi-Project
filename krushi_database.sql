
CREATE DATABASE E_Krushi;
USE E_Krushi;

CREATE TABLE users(user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,email varchar(255) unique,password varchar(255),contact_number varchar(255));

CREATE TABLE roles(role_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, role varchar(250));
              

CREATE TABLE customers(cust_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,first_name VARCHAR(255),last_name VARCHAR(25),contact_number VARCHAR(255),email VARCHAR(50),password varchar(250));
                      
CREATE TABLE categories(category_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,category_title varchar(255),description varchar(255),image varchar(255));
                        
CREATE TABLE products(product_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,product_title varchar(255),unit_price double,stock_available INT,image varchar(255),category_id INT NOT NULL, CONSTRAINT fk_category_id FOREIGN KEY (category_id) REFERENCES categories(category_id) ON UPDATE CASCADE ON DELETE CASCADE);
 
CREATE TABLE orders(order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_date DATETIME NOT NULL ,shipped_date DATETIME NOT NULL,cust_id INT NOT NULL,CONSTRAINT fk FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE, total DOUBLE ,status ENUM('approved','initiated','cancelled','delivered','inprogress') NOT NULL);

CREATE TABLE order_details(order_details_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_id INT NOT NULL,CONSTRAINT fk_04 FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE ,product_id INT NOT NULL ,CONSTRAINT fk_05 FOREIGN KEY (product_id) REFERENCES products(product_id)ON UPDATE CASCADE ON DELETE CASCADE,discount DOUBLE DEFAULT 0);  

CREATE TABLE carts(cart_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cust_id INT NOT NULL,CONSTRAINT fk_1 FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE, total DOUBLE ,status ENUM('approved','initiated','cancelled','delivered','inprogress') NOT NULL);

CREATE TABLE addresses(address_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cust_id INT NOT NULL,CONSTRAINT fk_cust_id FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,address_mode ENUM('permanent','billing') NOT NULL,house_number varchar(255),landmark VARCHAR(255),city VARCHAR(255) NOT NULL,state VARCHAR(255) NOT NULL,country VARCHAR(255) NOT NULL,pincode VARCHAR(255) NOT NULL);

CREATE TABLE cart_items(cart_items_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cart_id INT NOT NULL,CONSTRAINT fk_02 FOREIGN KEY (cart_id) REFERENCES carts(cart_id)ON UPDATE CASCADE ON DELETE CASCADE,product_id INT NOT NULL,CONSTRAINT fk_03 FOREIGN KEY (product_id) REFERENCES products(product_id) ,quantity INT NOT NULL); 


CREATE TABLE payments(payment_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,payment_date DATETIME NOT NULL , payment_mode ENUM('cash on delivery','online payment'),user_id INT NOT NULL,CONSTRAINT fk_user_id_5 FOREIGN KEY (user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE,order_id INT NOT NULL,CONSTRAINT fk_order_id FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE departments(dept_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, dept_name VARCHAR(50),location VARCHAR(45));

CREATE TABLE employees(employee_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,first_name VARCHAR(255),last_name VARCHAR(250),birth_date DATE ,hire_date DATE,contact_number VARCHAR(220),email VARCHAR(50),password VARCHAR(220),photo VARCHAR(250),reports_to INT NOT NULL,dept_id INT NOT NULL,CONSTRAINT fk_001 FOREIGN KEY (dept_id) REFERENCES departments(dept_id) ON UPDATE CASCADE ON  DELETE CASCADE);

CREATE TABLE shippers(shipper_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,company_name VARCHAR(255),contact_number VARCHAR(255),email VARCHAR(255),password VARCHAR(255));

CREATE TABLE suppliers(supplier_id INT NOT NULL AUTO_iNCREMENT PRIMARY KEY, company_name varchar(50),supplier_name varchar(50),address varchar(50),contact_number VARCHAR(50),email varchar(50),password VARCHAR(50),city VARCHAR(50),state VARCHAR(40));



CREATE TABLE accounts(account_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, account_number varchar(250) UNIQUE,ifsc_code varchar(250),register_date DATETIME, user_id INT NOT NULL, CONSTRAINT fk_user_id_1 FOREIGN KEY (user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE transactions(transaction_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, from_account_number VARCHAR(60)NOT NULL,CONSTRAINT fk_acc_no FOREIGN KEY(from_account_number) REFERENCES accounts(account_number)ON UPDATE CASCADE ON DELETE CASCADE, to_account_number VARCHAR(60) NOT NULL,CONSTRAINT fk_acc_no1 FOREIGN KEY(to_account_number) REFERENCES accounts(account_number)ON UPDATE CASCADE ON DELETE CASCADE,transaction_date DATETIME NOT NULL, amount DOUBLE);

CREATE TABLE user_roles(user_id INT NOT NULL,CONSTRAINT fk_user_id_2 FOREIGN KEY(user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE ,role_id INT NOT NULL,CONSTRAINT fk_role_id FOREIGN KEY(role_id) REFERENCES roles(role_id) ON UPDATE CASCADE ON DELETE CASCADE);
   
   
CREATE TABLE feedbacks(feedback_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,description VARCHAR(255),user_id INT NOT NULL ,CONSTRAINT fk_022 FOREIGN KEY (user_id) REFERENCES users(user_id));


-- TRIGGER FOR CUSTOMERS
DELIMITER //
CREATE TRIGGER insert_customer AFTER INSERT ON customers
FOR EACH ROW
BEGIN
    DECLARE userId INT;
    INSERT INTO users(email,password,contact_number) VALUES (NEW.email,NEW.password,NEW.contact_number);
    SELECT user_id INTO userId FROM users WHERE email=NEW.email;
    INSERT INTO user_roles(user_id,role_id) VALUES (userId,2); 
END //

DELIMITER ;

-- TRIGGER FOR EMPLOYEES
DELIMITER //
CREATE TRIGGER insert_employee AFTER INSERT ON employees
FOR EACH ROW
BEGIN
DECLARE userId INT ;
INSERT INTO users(email,password,contact_number) VALUES(NEW.email,NEW.password,NEW.contact_number);
SELECT user_id INTO userId FROM users WHERE email = NEW.email;
INSERT INTO user_roles(user_id,role_id) VALUES(userId,3);
END //
DELIMITER ;

-- TRIGGER FOR SUPPLIER
DELIMITER //
CREATE TRIGGER insert_supplier AFTER INSERT ON suppliers
FOR EACH ROW
BEGIN
DECLARE userId INT;
INSERT INTO users(email,password,contact_number) VALUES (NEW.email,NEW.password,NEW.contact_number);
SELECT user_id INTO userId FROM users WHERE email=NEW.email;
INSERT INTO user_roles(user_id,role_id) VALUES (userId,4);
END //
DELIMITER ;

 -- USER TABLE DATA
INSERT INTO users(email,password,contact_number) VALUES('shrisha12@gmail.com','shrisha@123','9850540298');
INSERT INTO users(email,password,contact_number) VALUES('shivam12@gmail.com','shivam@123','7450540298');
INSERT INTO users(email,password,contact_number) VALUES('kranti12@gmail.com','kranti@123','8850540298');
INSERT INTO users(email,password,contact_number) VALUES('rutujaaa12@gmail.com','pooja@123','9960540290');
INSERT INTO users(email,password,contact_number) VALUES('pratikbhor12@gmail.com','pratik@123','9960540291');


INSERT INTO roles(role) VALUES ('Admin');
INSERT INTO roles(role) VALUES ('Customer');
INSERT INTO roles(role) VALUES ('Employee');
INSERT INTO roles(role) VALUES ('Supplier');
INSERT INTO roles(role) VALUES ('Shipper');

select * from roles;


INSERT INTO customers(first_name,last_name,contact_number,email,password) VALUES('pratiksha','bangar','7834256798','pratikshabangar11@gmail.com','pratiksha@123');                       
INSERT INTO customers(first_name,last_name,contact_number,email,password) VALUES('priyanka','jadhav','7834256783','priyankajadhav09@gmail.com','priyanka@123');
INSERT INTO customers(first_name,last_name,contact_number,email,password) VALUES('pooja','divekar','9098556745','poojadivekar05@gmail.com','pooja@123');             
INSERT INTO customers(first_name,last_name,contact_number,email,password) VALUES('pratik','bhor','9804256744','pratikbhor06@gmail.com','pratik@123');     
INSERT INTO customers(first_name,last_name,contact_number,email,password) VALUES('pratik','VAVHAL','9804256796','pratik12@gmail.com','prati@123');     



INSERT INTO categories(category_title,description,image) VALUES('seeds','crops growth fastly','/image/fertilizer.jpg');
INSERT INTO categories(category_title,description,image) VALUES('chemical fertilizer','crops growth fastly','/image/fertilizer.jpg');
INSERT INTO categories(category_title,description,image) VALUES('organic fertilizer','crops growth fastly','/image/fertilizer.jpg');
INSERT INTO categories(category_title,description,image) VALUES('pesticide','for spraying','/image/pesticide.jpg');

-- SEEDS
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

INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-12-01 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-11-01 12:12:12','2020-11-02 10:02:12',1,800,'delivered');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-10-01 12:12:12','2020-10-02 10:22:12',1,700,'cancelled');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2021-12-01 12:10:12','2021-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2022-11-01 12:11:00','2022-11-02 10:02:12',2,1800,'delivered');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2023-10-01 12:13:11','2023-10-02 10:22:12',2,7100,'cancelled');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-05-01 12:14:13','2020-05-02 10:12:12',3,5020,'initiated');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2022-01-01 12:40:22','2022-01-02 10:02:12',3,8007,'delivered');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2023-10-01 12:55:45','2023-10-02 10:22:12',4,7006,'cancelled');

INSERT INTO order_details(order_id,product_id) VALUES (1,2);
INSERT INTO order_details(order_id,product_id) VALUES (2,2);
INSERT INTO order_details(order_id,product_id) VALUES (2,1);
INSERT INTO order_details(order_id,product_id) VALUES (1,3);
INSERT INTO order_details(order_id,product_id) VALUES (3,3);
INSERT INTO order_details(order_id,product_id) VALUES (4,2);
INSERT INTO order_details(order_id,product_id) VALUES (2,4);

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

INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(1,1,20);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(2,2,40);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(2,2,40);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(3,4,10);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(3,4,50);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(3,2,260);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(4,3,200);
INSERT INTO cart_items(cart_id,product_id ,quantity) VALUES(4,3,201);


INSERT INTO payments(payment_date,payment_mode,user_id,order_id) VALUES('2022-03-08 12:08:19','cash on delivery',1,1);
INSERT INTO payments(payment_date,payment_mode,user_id,order_id) VALUES('2022-03-08 12:08:19','online payment',2,1);
INSERT INTO payments(payment_date,payment_mode,user_id,order_id) VALUES('2022-03-08 12:08:19','cash on delivery',3,2);
INSERT INTO payments(payment_date,payment_mode,user_id,order_id) VALUES('2022-03-08 12:08:19','online payment',4,3);
INSERT INTO payments(payment_date,payment_mode,user_id,order_id) VALUES('2022-03-08 12:08:19','cash on delivery',2,4);

INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode) VALUES(1,'permanent','houseNo.32','akshara garden','pune','maharashtra','india','410503');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode) VALUES(1,'billing','houseNo.32','akshara dairy','pune','maharashtra','india','410502');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode) VALUES(2,'permanent','houseNo.32','season mall','pune','maharashtra','india','410504');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode) VALUES(3,'billing','houseNo.32','Peth-Kurwandi Road','Manchar','Maharashtra','India','410506');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode) VALUES(4,'permanent','houseNo.234','Pune-Nashik Highway','Rajgurunagar','Maharashtra','India','1213');



INSERT INTO departments(dept_name,location) VALUES('account', 'pune');
INSERT INTO departments(dept_name,location) VALUES('hr', 'manchar');
INSERT INTO departments(dept_name,location) VALUES('sales', 'nashik');
INSERT INTO departments(dept_name,location) VALUES('finance', 'nerul');


INSERT INTO employees(first_name,last_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,dept_id) VALUES('akash','ajab','1999-09-15','2022-05-12','9881571268','akashajab1234@gamil.com','akash@123','/image/akash.jpg',3,1);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,dept_id) VALUES('vedant','Bangar','2005-09-15','2022-05-12','9881571245','vedantbangar1234@gamil.com','vedant@123','/image/vedant.jpg',2,1);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,dept_id) VALUES('sahil','hinge','2023-09-15','2022-06-14','9881571246','sahil1234@gamil.com','sahil@123','/image/sahil.jpg',2,2);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,dept_id) VALUES('prakash','amate','2015-09-15','2022-07-13','9881571247','prakash1234@gamil.com','prakash@123','/image/prakash.jpg',4,4);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,dept_id) VALUES('nilesh','lanke','1988-09-15','2022-08-11','9881571248','nilesh1234@gamil.com','nilesh@123','/image/nilesh.jpg',1,3);

INSERT INTO shippers(company_name,contact_number,email,password) VALUES('agrotech pvt.ltd','9860366152','agrotech11@gmail.com','agrotech@123');
INSERT INTO shippers(company_name,contact_number,email,password) VALUES('agrilens pvt.ltd','9860366152','agrotech11@gmail.com','agrotech@123');
INSERT INTO shippers(company_name,contact_number,email,password) VALUES('croproot pvt.ltd','9860366152','agrotech11@gmail.com','agrotech@123');
INSERT INTO shippers(company_name,contact_number,email,password) VALUES('greenery pvt.ltd','9860366152','agrotech11@gmail.com','agrotech@123');

INSERT INTO suppliers(company_name,supplier_name,address,contact_number,email,password,city,state) VALUES('kaveri','abhishek bhor','pimpalgaon','8903456782','kaveri12@gmail.com','kaveri@123','pune','maharashtra');
INSERT INTO suppliers(company_name,supplier_name,address,contact_number,email,password,city,state) VALUES('kalash seeds','pratik wagh','khadaki','8940456782','kalashseeds12@gmail.com','kalash@123','pune','maharashtra');
INSERT INTO suppliers(company_name,supplier_name,address,contact_number,email,password,city,state) VALUES('greenary','datta dhoble','manchar','8903456750','greenary12@gmail.com','greenary@123','pune','maharashtra');
INSERT INTO suppliers(company_name,supplier_name,address,contact_number,email,password,city,state) VALUES('kavya','kavya bangar','chandoli','8903816782','kavya12@gmail.com','kavya@123','pune','maharashtra');


INSERT INTO user_roles(user_id,role_id) VALUES (1,1);
INSERT INTO user_roles(user_id,role_id) VALUES(2,1);
INSERT INTO user_roles(user_id,role_id) VALUES(3,1);
INSERT INTO user_roles(user_id,role_id) VALUES(6,2);
INSERT INTO user_roles(user_id,role_id) VALUES(8,2);
INSERT INTO user_roles(user_id,role_id) VALUES(6,3);

INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031201','KOTAK000286','2022-04-05  01:02:03',1);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031202','ICICI000286','2022-11-25  01:12:03',1);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031203','MAHB0000286','2022-12-30  11:02:03',3);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031204','PDCC0000286','2022-05-10  12:02:03',2);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031205','SBIB0000286','2022-09-07  06:02:03',2);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031206','AXIS0000286','2022-11-03  07:02:03',4);
INSERT INTO accounts(account_number,ifsc_code,register_date,user_id) VALUES('4105031207','BARB0000286','2022-10-23  08:02:03',3);

INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES('4105031201','4105031202','2022-03-09  08:45:23',45000);
INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES('4105031203','4105031205','2022-12-09  01:40:10',12000);
INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES('4105031204','4105031206','2022-08-09  10:30:20',25000);
INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES('4105031207','4105031205','2022-10-09  06:35:23',30000);

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

select * from customers where password IN (select password from users where user_id in (select user_id from user_roles where role_id In (select role_id from roles where role='customer')));

select * from users;