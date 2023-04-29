-- drop database E_Krushi;
CREATE DATABASE E_Krushi;
USE E_Krushi;

CREATE TABLE users(user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,email varchar(255) unique,password varchar(255),contact_number varchar(255));

CREATE TABLE roles(role_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, role varchar(250));
              
CREATE TABLE customers(cust_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,first_name VARCHAR(255),last_name VARCHAR(25),user_id INT NOT NULL,CONSTRAINT fk_user_id_11 FOREIGN KEY (user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE categories(category_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,category_title varchar(255),description varchar(255),image varchar(255));
                        
CREATE TABLE products(product_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,product_title varchar(255),unit_price double,stock_available INT,image varchar(255),category_id INT NOT NULL, CONSTRAINT fk_category_id FOREIGN KEY (category_id) REFERENCES categories(category_id) ON UPDATE CASCADE ON DELETE CASCADE);
 
CREATE TABLE orders(order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_date DATETIME NOT NULL ,shipped_date DATETIME NOT NULL,cust_id INT NOT NULL,CONSTRAINT fk FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE, total DOUBLE ,status ENUM('approved','initiated','cancelled','delivered','inprogress') NOT NULL);

CREATE TABLE order_details(order_details_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_id INT NOT NULL,CONSTRAINT fk_04 FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE ,product_id INT NOT NULL ,CONSTRAINT fk_05 FOREIGN KEY (product_id) REFERENCES products(product_id)ON UPDATE CASCADE ON DELETE CASCADE,quantity INT NOT NULL,discount DOUBLE DEFAULT 0);  

CREATE TABLE carts(cart_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cust_id INT NOT NULL,CONSTRAINT fk_1 FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE, total DOUBLE ,status ENUM('approved','initiated','cancelled','delivered','inprogress') NOT NULL);

CREATE TABLE addresses(address_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cust_id INT NOT NULL,CONSTRAINT fk_cust_id FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,address_mode ENUM('permanent','billing') NOT NULL,house_number varchar(255),landmark VARCHAR(255),city VARCHAR(255) NOT NULL,state VARCHAR(255) NOT NULL,country VARCHAR(255) NOT NULL,pincode VARCHAR(255) NOT NULL);

CREATE TABLE cart_items(cart_items_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cart_id INT NOT NULL,CONSTRAINT fk_02 FOREIGN KEY (cart_id) REFERENCES carts(cart_id)ON UPDATE CASCADE ON DELETE CASCADE,product_id INT NOT NULL,CONSTRAINT fk_03 FOREIGN KEY (product_id) REFERENCES products(product_id) ,quantity INT NOT NULL); 

CREATE TABLE payments(payment_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,payment_date DATETIME NOT NULL , payment_mode ENUM('cash on delivery','online payment'),user_id INT NOT NULL,CONSTRAINT fk_user_id_5 FOREIGN KEY (user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE,order_id INT NOT NULL,CONSTRAINT fk_order_id FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE employees(employee_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,first_name VARCHAR(255),last_name VARCHAR(250),birth_date DATE ,hire_date DATE,photo VARCHAR(250),reports_to INT NOT NULL,user_id INT NOT NULL,CONSTRAINT fk_user_id_14 FOREIGN KEY (user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE shippers(shipper_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,company_name VARCHAR(255),user_id INT NOT NULL,CONSTRAINT fk_user_id_13 FOREIGN KEY (user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE suppliers(supplier_id INT NOT NULL AUTO_iNCREMENT PRIMARY KEY, company_name varchar(50),supplier_name varchar(50),address varchar(50),city VARCHAR(50),state VARCHAR(40),user_id INT NOT NULL,CONSTRAINT fk_user_id_09 FOREIGN KEY (user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE accounts(account_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, account_number varchar(250) UNIQUE,ifsc_code varchar(250),register_date DATETIME, user_id INT NOT NULL, CONSTRAINT fk_user_id_1 FOREIGN KEY (user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE transactions(transaction_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, from_account_number VARCHAR(60)NOT NULL,CONSTRAINT fk_acc_no FOREIGN KEY(from_account_number) REFERENCES accounts(account_number)ON UPDATE CASCADE ON DELETE CASCADE, to_account_number VARCHAR(60) NOT NULL,CONSTRAINT fk_acc_no1 FOREIGN KEY(to_account_number) REFERENCES accounts(account_number)ON UPDATE CASCADE ON DELETE CASCADE,transaction_date DATETIME NOT NULL, amount DOUBLE);

CREATE TABLE user_roles(user_id INT NOT NULL,CONSTRAINT fk_user_id_2 FOREIGN KEY(user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE ,role_id INT NOT NULL,CONSTRAINT fk_role_id FOREIGN KEY(role_id) REFERENCES roles(role_id) ON UPDATE CASCADE ON DELETE CASCADE);
  
CREATE TABLE feedbacks(feedback_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,description VARCHAR(255),cust_id INT NOT NULL ,CONSTRAINT fk_022 FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE question_categories(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,category varchar(255));

CREATE TABLE questions(question_id  INT NOT NULL AUTO_INCREMENT PRIMARY KEY, question_date DATETIME NOT NULL, description VARCHAR(255),cust_id INT NOT NULL ,CONSTRAINT fk_023 FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,category_id INT NOT NULL,CONSTRAINT fk_category1 FOREIGN KEY (category_id) REFERENCES question_categories(id) ON DELETE CASCADE ON UPDATE CASCADE);

CREATE TABLE solutions(solution_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,description VARCHAR(255));

CREATE TABLE agri_doctors(agri_doctor_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,name VARCHAR(40),specialist_for VARCHAR(40),user_id INT NOT NULL,CONSTRAINT fk_user11 FOREIGN KEY (user_id) REFERENCES users(user_id));

CREATE TABLE question_solutions(question_id INT NOT NULL ,CONSTRAINT fk_question2_id FOREIGN KEY(question_id) REFERENCES questions(question_id) ON UPDATE CASCADE ON DELETE CASCADE,solution_id INT NOT NULL ,CONSTRAINT fk_solution1_id FOREIGN KEY(solution_id) REFERENCES solutions(solution_id) ON UPDATE CASCADE ON DELETE CASCADE, solution_date DATETIME NOT NULL,agri_doctor_id INT NOT NULL,CONSTRAINT fk_agri FOREIGN KEY (agri_doctor_id) REFERENCES agri_doctors(agri_doctor_id));

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
INSERT INTO users(email,password,contact_number) VALUES ('tara@gmail.com','tara@12',9181578790);
INSERT INTO users(email,password,contact_number) VALUES ('anaya@gmail.com','anaya@12',9281404760);
INSERT INTO users(email,password,contact_number) VALUES ('riddhi@gmail.com','riddhi@12',7498571275);
INSERT INTO users(email,password,contact_number) VALUES ('soumya@gmail.com','soumya@12',7356771275);
INSERT INTO users(email,password,contact_number) VALUES ('ruhi@gmail.com','ruhi@12',9581573465);
INSERT INTO users(email,password,contact_number) VALUES ('akshita@gmail.com','akshita@12',7498012275);
INSERT INTO users(email,password,contact_number) VALUES ('aarohi@gmail.com','aarohi@12',7356771350);
INSERT INTO users(email,password,contact_number) VALUES ('aaradhya@gmail.com','aaradhya@12',9581573054);
INSERT INTO users(email,password,contact_number) VALUES ('pratimapatil@gmail.com','pratima@12',7709736561);
INSERT INTO users(email,password,contact_number) VALUES ('kiranrakshe@gmail.com','kiran@12',7709736562);
INSERT INTO users(email,password,contact_number) VALUES ('mayurgorade@gmail.com','mayur@12',7703726563);



-- ROLE TABLE DATA
INSERT INTO roles(role) VALUES ('Admin');
INSERT INTO roles(role) VALUES ('Customer');
INSERT INTO roles(role) VALUES ('Employee');
INSERT INTO roles(role) VALUES ('Supplier');
INSERT INTO roles(role) VALUES ('Shipper');
INSERT INTO roles(role) VALUES ('agri_doctors');

select * from roles;

-- CUSTOMERS DATA
INSERT INTO customers(first_name,last_name,user_id) VALUES('akash','ajab',1);                       
INSERT INTO customers(first_name,last_name,user_id) VALUES('pragati','bangar',2);
INSERT INTO customers(first_name,last_name,user_id) VALUES('akshay','tanpure',3);             
INSERT INTO customers(first_name,last_name,user_id) VALUES('abhay','navale',4);     
INSERT INTO customers(first_name,last_name,user_id) VALUES('rohit','gore',5);     
INSERT INTO customers(first_name,last_name,user_id) VALUES('rushikesh','chikne',6);                       
INSERT INTO customers(first_name,last_name,user_id) VALUES('shubham','teli',7);


-- CATEGORIES DATA
INSERT INTO categories(category_title,description,image) VALUES('seeds','crops growth fastly','/image/seeds.jpg');
INSERT INTO categories(category_title,description,image) VALUES('Agriculture equipments','crops growth fastly','/image/equipments.jpg');
INSERT INTO categories(category_title,description,image) VALUES('fertilizers','crops growth fastly','/image/fertilizers.jpg');
INSERT INTO categories(category_title,description,image) VALUES('pesticides','for spraying','/image/pesticide.jpg');
INSERT INTO categories(category_title,description,image) VALUES('Agricultural sprayers','for spraying','/image/sprayers.jpg');
INSERT INTO categories(category_title,description,image) VALUES('plants micronutrients','for spraying','/image/micronutrient.jpg');

-- PRODUCTS DATA
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('oats',100,500,'/image/oats.jpg',1);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('wheat',100,50,'/image/sunflower.jpg',1);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('corn',100,50,'/image/sunflower.jpg',1);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('barley',100,50,'/image/sunflower.jpg',1);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('sorghum',100,50,'/image/sunflower.jpg',1);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('sunflower',100,50,'/image/sunflower.jpg',1);


INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('tractor',100,50,'/image/sunflower.jpg',2);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('harvesters',100,50,'/image/sunflower.jpg',2);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('balers',100,50,'/image/sunflower.jpg',2);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('fertilizer spreaders',100,50,'/image/sunflower.jpg',2);

-- FERTILIZERS
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('wood ash',100,500,'/image/woodash.jpg',3);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('bone meal',100,500,'/image/bonemeal.jpg',3);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('blood meal',100,500,'/image/bloodmeal.jpg',3);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('manure',100,500,'/image/manure.jpg',3);

-- PESTISIDES
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('karate',100,500,'/image/woodash.jpg',4);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('soloman',100,500,'/image/manure.jpg',4);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('wood ash',100,500,'/image/woodash.jpg',4);

-- Agricultural sprayers
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('Knapsack sprayer',100,500,'/image/woodash.jpg',5);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('portable power sprayer',100,500,'/image/manure.jpg',5);
INSERT INTO products(product_title,unit_price,stock_available,image,category_id) VALUES('mist dust sprayer',100,500,'/image/woodash.jpg',5);

-- ORDERS DATA
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-12-01 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-11-01 12:12:12','2020-11-02 10:02:12',2,800,'delivered');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-10-01 12:12:12','2020-10-02 10:22:12',3,700,'cancelled');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2021-12-01 12:10:12','2021-12-02 10:12:12',4,500,'initiated');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2022-11-01 12:11:00','2022-11-02 10:02:12',5,1800,'delivered');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2023-10-01 12:13:11','2023-10-02 10:22:12',6,7100,'cancelled');
INSERT INTO orders(order_date,shipped_date,cust_id,total,status) VALUES ('2020-05-01 12:14:13','2020-05-02 10:12:12',7,5020,'initiated');



SELECT * FROM customers;

-- ORDER_DETAILS DATA
INSERT INTO order_details(order_id,product_id,quantity) VALUES (1,2,20);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (2,2,25);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (3,1,40);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (4,3,15);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (4,3,48);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (5,5,41);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (7,6,63);
INSERT INTO order_details(order_id,product_id,quantity) VALUES (6,7,63);


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

-- EMPLOYESS DATA
INSERT INTO employees(first_name,last_name,birth_date,hire_date,photo,reports_to,user_id) VALUES('chetan','ajab','1999-09-15','2022-05-12','/image/akash.jpg',3,8);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,photo,reports_to,user_id) VALUES('abhishek','Bangar','2005-09-15','2022-05-12','/image/vedant.jpg',2,9);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,photo,reports_to,user_id) VALUES('anil','hinge','2023-09-15','2022-06-14','/image/sahil.jpg',2,10);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,photo,reports_to,user_id) VALUES('rohan','amate','2015-09-15','2022-07-13','/image/prakash.jpg',4,11);
INSERT INTO employees(first_name,last_name,birth_date,hire_date,photo,reports_to,user_id) VALUES('ajay','lanke','1988-09-15','2022-08-11','/image/nilesh.jpg',1,12);


select * from users;
select * from users;

-- SHIPPERS DATA
INSERT INTO shippers(company_name,user_id) VALUES('agrotech pvt.ltd',13);
INSERT INTO shippers(company_name,user_id) VALUES('agrilens pvt.ltd',14);
INSERT INTO shippers(company_name,user_id) VALUES('croproot pvt.ltd',15);
INSERT INTO shippers(company_name,user_id) VALUES('greenery pvt.ltd',16);


-- SUPPLIERS DATA
INSERT INTO suppliers(company_name,supplier_name,address,city,state,user_id) VALUES('kaveri','abhishek bhor','pimpalgaon','pune','maharashtra',17);
INSERT INTO suppliers(company_name,supplier_name,address,city,state,user_id) VALUES('kalash seeds','pratik wagh','khadaki','pune','maharashtra',18);
INSERT INTO suppliers(company_name,supplier_name,address,city,state,user_id) VALUES('greenary','datta dhoble','manchar','pune','maharashtra',19);
INSERT INTO suppliers(company_name,supplier_name,address,city,state,user_id) VALUES('kavya','kavya bangar','chandoli','pune','maharashtra',20);

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
INSERT INTO feedbacks(description,cust_id) VALUES ('very good facilitities',1);
INSERT INTO feedbacks(description,cust_id) VALUES ('good quality of products',2);
INSERT INTO feedbacks(description,cust_id) VALUES ('very good for farmers ',3);
INSERT INTO feedbacks(description,cust_id) VALUES ('farmers are protected from frauds',4);

INSERT INTO question_categories(category) VALUES('crop related questions');
INSERT INTO question_categories(category) VALUES('soil related questions');
INSERT INTO question_categories(category) VALUES('weather releted questions');


INSERT INTO questions(question_date,description,cust_id,category_id) VALUES('2022-02-12 08:02:11','How can I increase crop yield?',5,1);
INSERT INTO questions(question_date,description,cust_id,category_id) VALUES('2021-01-13 04:02:11','How can I prevent crop damage from pests and diseases?',4,1);
INSERT INTO questions(question_date,description,cust_id,category_id) VALUES('2023-03-11 06:02:11','How can I optimize the timing of planting and harvesting?',3,1);
INSERT INTO questions(question_date,description,cust_id,category_id) VALUES('2020-04-01 04:02:11','How can I improve soil fertility? ',3,2);
INSERT INTO questions(question_date,description,cust_id,category_id) VALUES('2020-04-01 04:02:11','How can I improve soil structure? ',5,2);
INSERT INTO questions(question_date,description,cust_id,category_id) VALUES('2020-04-01 04:02:11','How can I prevent soil erosion? ',2,2);
INSERT INTO questions(question_date,description,cust_id,category_id) VALUES('2020-04-01 04:02:11','What should I do if there is a drought?',2,3);
INSERT INTO questions(question_date,description,cust_id,category_id) VALUES('2020-04-01 04:02:11','What should I do if there is heavy rainfall? ',5,3);
INSERT INTO questions(question_date,description,cust_id,category_id) VALUES('2020-04-01 04:02:11','What should I do if there is extreme heat?',3,3);


INSERT INTO solutions(description) VALUES('Soil health: Ensure the soil is healthy by adding organic matter and nutrients, improving drainage and water retention, and avoiding soil erosion.');
INSERT INTO solutions(description) VALUES('Monitor crops regularly for signs of pests and diseases and take appropriate measures to prevent and control them.
                                          Use resistant crop varieties.');
INSERT INTO solutions(description) VALUES('Consider local weather patterns and the plants growth requirements.');
INSERT INTO solutions(description) VALUES('Soil testing: Perform soil tests to determine nutrient deficiencies and pH levels.
                                           Fertilizer: Apply appropriate amounts of fertilizers to address nutrient deficiencies.');
INSERT INTO solutions(description) VALUES('Reduce soil compaction: Avoid excessive tillage, limit heavy machinery use, and avoid working on wet soil.');
INSERT INTO solutions(description) VALUES('Cover crops: Plant cover crops to help prevent soil erosion by reducing runoff and increasing soil structure.');
INSERT INTO solutions(description) VALUES('Irrigation: Use irrigation techniques to provide plants with the necessary water.
                                          Crop selection: Choose crops that are drought-tolerant.');
INSERT INTO solutions(description) VALUES('Soil erosion prevention: Implement soil erosion prevention practices, such as planting cover crops, to help protect soil from being washed away.
										  Crop selection: Choose crops that are better suited to wet conditions.');
INSERT INTO solutions(description) VALUES('Irrigation: Use appropriate irrigation techniques to help cool plants.
                                          Shade: Provide shade for crops to help protect them from extreme heat.');


INSERT INTO agri_doctors(name,specialist_for,user_id) VALUES('pratima patil','crop related information',22);
INSERT INTO agri_doctors(name,specialist_for,user_id) VALUES('kiran rakshe','soil related information',23);
INSERT INTO agri_doctors(name,specialist_for,user_id) VALUES('mayur gorade','Weather related information',24);



INSERT INTO question_solutions(question_id,solution_id,solution_date,agri_doctor_id) VALUES (1,1,'2023-04-05 12:08:06',1);
INSERT INTO question_solutions(question_id,solution_id,solution_date,agri_doctor_id) VALUES (2,2,'2023-06-05 12:20:19',1);
INSERT INTO question_solutions(question_id,solution_id,solution_date,agri_doctor_id) VALUES (4,4,'2023-07-10 12:23:08',2);
INSERT INTO question_solutions(question_id,solution_id,solution_date,agri_doctor_id) VALUES (5,5,'2023-08-25 12:34:20',2);
INSERT INTO question_solutions(question_id,solution_id,solution_date,agri_doctor_id) VALUES (7,7,'2023-09-15 12:40:30',3);


SELECT * FROM employees;
SELECT * FROM feedbacks;
select * from agri_doctors;
SELECT * FROM questions;
SELECT * FROM solutions;
SELECT * FROM question_solutions;
SELECT * FROM users;

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

-- when we give the email of user then we give role of this user
select role from roles where role_id in (select role_id from user_roles where user_id in (select user_id from users where email = 'akashajab12@gmail.com'));


-- This query gives payment details where payment_id=1;
select * from payments where payment_id=1; 


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

SELECT * FROM products;
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
select * from orders;


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

-- This query gives multiple account number of users by left join where user_id=1;
SELECT accounts.user_id,
	   accounts.account_number
FROM accounts 
LEFT JOIN users ON accounts.account_id = users.user_id  WHERE accounts.user_id =1;

-- This query gives multiple account number of users where user_id=1;
SELECT user_id,
	   account_number
FROM accounts WHERE user_id=1;


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

CALL stock_available_update_inventory(1,3,500);

--   this query return user_id of employees;
select user_id from user_roles where role_id in (SELECT role_id from roles where role="Employee");

select * from payments;
select * from users;
select * from user_roles;
select * from roles;
select * from user_roles;
SELECT * FROM feedbacks;
select * from agri_doctors;


