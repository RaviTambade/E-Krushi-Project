 -- drop database ekrushi;
 CREATE DATABASE ekrushi;
USE ekrushi;

CREATE TABLE users(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,email varchar(255) unique,password varchar(255),contactnumber varchar(255));

CREATE TABLE roles(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, role varchar(250));
              
CREATE TABLE customers(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,firstname VARCHAR(255),lastname VARCHAR(25),userid INT NOT NULL,CONSTRAINT fk FOREIGN KEY (userid) REFERENCES users(id) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE categories(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,title varchar(255),description varchar(255),image varchar(255));
                        
CREATE TABLE products(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,title varchar(255),unitprice double,stockavailable INT,image varchar(255),
categoryid INT NOT NULL, CONSTRAINT fkcategoryid FOREIGN KEY (categoryid) REFERENCES categories(id) ON UPDATE CASCADE ON DELETE CASCADE);
 
CREATE TABLE orders(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,orderdate DATETIME NOT NULL ,shippeddate DATETIME NOT NULL,custid INT NOT NULL,
CONSTRAINT fk_cust_id_11 FOREIGN KEY (custid) REFERENCES customers(id) ON UPDATE CASCADE ON DELETE CASCADE, 
total DOUBLE ,status ENUM('approved','initiated','cancelled','delivered','inprogress') NOT NULL);

CREATE TABLE orderdetails(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,orderid INT NOT NULL,
CONSTRAINT fkorder FOREIGN KEY (orderid) REFERENCES orders(id) ON UPDATE CASCADE ON DELETE CASCADE ,
productid INT NOT NULL ,CONSTRAINT fkproduct FOREIGN KEY (productid) REFERENCES products(id)ON UPDATE CASCADE ON DELETE CASCADE,
quantity INT NOT NULL,discount DOUBLE DEFAULT 0);  

CREATE TABLE carts(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,custid INT NOT NULL,
CONSTRAINT fk_1 FOREIGN KEY (custid) REFERENCES customers(id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE addresses(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,custid INT NOT NULL,
CONSTRAINT fkcustid FOREIGN KEY (custid) REFERENCES customers(id) ON UPDATE CASCADE ON DELETE CASCADE,
addressmode ENUM('permanent','billing') NOT NULL,
housenumber varchar(255),landmark VARCHAR(255),city VARCHAR(255) NOT NULL,state VARCHAR(255) NOT NULL,country VARCHAR(255) NOT NULL,pincode VARCHAR(255) NOT NULL);

CREATE TABLE cartitems(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cartid INT NOT NULL,
CONSTRAINT fk02 FOREIGN KEY (cartid) REFERENCES carts(id)ON UPDATE CASCADE ON DELETE CASCADE,
productid INT NOT NULL,CONSTRAINT fk03 FOREIGN KEY (productid) REFERENCES products(id) ON UPDATE CASCADE ON DELETE CASCADE,quantity INT NOT NULL ); 

CREATE TABLE payments(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,date DATETIME NOT NULL , 
mode ENUM('cash on delivery','online payment'),transactionid INT NOT NULL,userid INT NOT NULL,CONSTRAINT fkuserid5 FOREIGN KEY (userid) REFERENCES users(id) ON UPDATE CASCADE ON DELETE CASCADE,
orderid INT NOT NULL,CONSTRAINT fkorderid FOREIGN KEY (orderid) REFERENCES orders(id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE employees(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,firstname VARCHAR(255),lastname VARCHAR(250),birthdate DATE ,
hiredate DATE,photo VARCHAR(250),reportsto INT NOT NULL,userid INT NOT NULL,
CONSTRAINT fkuserid14 FOREIGN KEY (userid) REFERENCES users(id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE shippers(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,companyname VARCHAR(255),
userid INT NOT NULL,CONSTRAINT fkuserid13 FOREIGN KEY (userid) REFERENCES users(id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE suppliers(id INT NOT NULL AUTO_iNCREMENT PRIMARY KEY, companyname varchar(50),suppliername varchar(50),
address varchar(50),city VARCHAR(50),state VARCHAR(40),
userid INT NOT NULL,CONSTRAINT fkuserid09 FOREIGN KEY (userid) REFERENCES users(id) ON UPDATE CASCADE ON DELETE CASCADE);



CREATE TABLE userroles(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,userid INT NOT NULL,CONSTRAINT fkuserid2 FOREIGN KEY(userid) REFERENCES users(id) ON UPDATE CASCADE ON DELETE CASCADE ,
roleid INT NOT NULL,CONSTRAINT fkroleid FOREIGN KEY(roleid) REFERENCES roles(id) ON UPDATE CASCADE ON DELETE CASCADE);
  
CREATE TABLE feedbacks(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,description VARCHAR(255),custid INT NOT NULL ,
CONSTRAINT fk_022 FOREIGN KEY (custid) REFERENCES customers(id) ON UPDATE CASCADE ON DELETE CASCADE);

CREATE TABLE questioncategories(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,category varchar(255));

CREATE TABLE questions(id  INT NOT NULL AUTO_INCREMENT PRIMARY KEY, description VARCHAR(255),
categoryid INT NOT NULL,CONSTRAINT fkcategory1 FOREIGN KEY (categoryid) REFERENCES questioncategories(id) ON DELETE CASCADE ON UPDATE CASCADE);
-- customer questions table required   auto  id pri , cust id fr key ,fr ques id ,date 

CREATE TABLE answers(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,description VARCHAR(255), 
questionid INT NOT NULL,CONSTRAINT fkcategory12 FOREIGN KEY (questionid) REFERENCES questions(id) ON DELETE CASCADE ON UPDATE CASCADE);

CREATE TABLE subjectmatterexperts(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,name VARCHAR(40),expertise VARCHAR(40),userid INT NOT NULL,
CONSTRAINT fkuser11 FOREIGN KEY (userid) REFERENCES users(id));

CREATE TABLE smeanswers(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,answerid INT NOT NULL,CONSTRAINT fkuser21 FOREIGN KEY (answerid) REFERENCES answers(id)ON UPDATE CASCADE ON DELETE CASCADE,
questionid INT NOT NULL,CONSTRAINT fkusen21 FOREIGN KEY (questionid) REFERENCES questions(id) ON UPDATE CASCADE ON DELETE CASCADE,answerdate datetime not null,smeid INT NOT NULL,
CONSTRAINT fkuser22 FOREIGN KEY (smeid) REFERENCES subjectmatterexperts(id));

CREATE TABLE customerquestions(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,questionid INT NOT NULL ,CONSTRAINT fkques FOREIGN KEY(questionid) REFERENCES questions(id) ON UPDATE CASCADE ON DELETE CASCADE,
custid INT NOT NULL,CONSTRAINT fk_cust_11 FOREIGN KEY (custid) REFERENCES customers(id) ON UPDATE CASCADE ON DELETE CASCADE, questiondate datetime not null);

INSERT INTO users(email,password,contactnumber) VALUES ('akashajab@gmail.com','akash@12',9089777678);
INSERT INTO users(email,password,contactnumber) VALUES ('sahil@gmail.com','sahil@12',9067894590);
INSERT INTO users(email,password,contactnumber) VALUES ('akshaytanpure@gmail.com','akshay@12',9881571271);
INSERT INTO users(email,password,contactnumber) VALUES ('vedantyadav@gmail.com','vedant@12',9089898078);
INSERT INTO users(email,password,contactnumber) VALUES ('rohitgore@gmail.com','rohit@12',9881571273);
INSERT INTO users(email,password,contactnumber) VALUES ('rushikeshchikne@gmail.com','rushikesh12',9881571274);
INSERT INTO users(email,password,contactnumber) VALUES ('shubham@gmail.com','shubham@12',9881571275);
INSERT INTO users(email,password,contactnumber) VALUES ('chetan@gmail.com','chetan@12',9081571275);
INSERT INTO users(email,password,contactnumber) VALUES ('abhishek@gmail.com','abhishek@12',9181571275);
INSERT INTO users(email,password,contactnumber) VALUES ('anil@gmail.com','anil@12',9281571275);
INSERT INTO users(email,password,contactnumber) VALUES ('rohan@gmail.com','rohan@12',9381571275);
INSERT INTO users(email,password,contactnumber) VALUES ('ajay@gmail.com','ajay@12',9481571275);
INSERT INTO users(email,password,contactnumber) VALUES ('vijay@gmail.com','vijay@12',9581571275);
INSERT INTO users(email,password,contactnumber) VALUES ('tara@gmail.com','tara@12',9181578790);
INSERT INTO users(email,password,contactnumber) VALUES ('anaya@gmail.com','anaya@12',9281404760);
INSERT INTO users(email,password,contactnumber) VALUES ('riddhi@gmail.com','riddhi@12',7498571275);
INSERT INTO users(email,password,contactnumber) VALUES ('soumya@gmail.com','soumya@12',7356771275);
INSERT INTO users(email,password,contactnumber) VALUES ('ruhi@gmail.com','ruhi@12',9581573465);
INSERT INTO users(email,password,contactnumber) VALUES ('akshita@gmail.com','akshita@12',7498012275);
INSERT INTO users(email,password,contactnumber) VALUES ('aarohi@gmail.com','aarohi@12',7356771350);
INSERT INTO users(email,password,contactnumber) VALUES ('aaradhya@gmail.com','aaradhya@12',9581573054);
INSERT INTO users(email,password,contactnumber) VALUES ('pratimapatil@gmail.com','pratima@12',7709736561);
INSERT INTO users(email,password,contactnumber) VALUES ('kiranrakshe@gmail.com','kiran@12',7709736562);
INSERT INTO users(email,password,contactnumber) VALUES ('mayurgorade@gmail.com','mayur@12',7703726563);



-- ROLE TABLE DATA
INSERT INTO roles(role) VALUES ('Admin');
INSERT INTO roles(role) VALUES ('Customer');
INSERT INTO roles(role) VALUES ('Employee');
INSERT INTO roles(role) VALUES ('Supplier');
INSERT INTO roles(role) VALUES ('Shipper');
INSERT INTO roles(role) VALUES ('SubjectMatterExpert');

select * from products;

-- CUSTOMERS DATA
INSERT INTO customers(firstname,lastname,userid) VALUES('akash','ajab',1);                       
INSERT INTO customers(firstname,lastname,userid) VALUES('sahil','mankar',2);
INSERT INTO customers(firstname,lastname,userid) VALUES('akshay','tanpure',3);             
INSERT INTO customers(firstname,lastname,userid) VALUES('vedant','yadav',4);     
INSERT INTO customers(firstname,lastname,userid) VALUES('rohit','gore',5);     
INSERT INTO customers(firstname,lastname,userid) VALUES('rushikesh','chikne',6);                       
INSERT INTO customers(firstname,lastname,userid) VALUES('shubham','teli',7);


-- CATEGORIES DATA
INSERT INTO categories(title,description,image) VALUES('seeds','crops growth fastly','/image/seeds.jpg');
INSERT INTO categories(title,description,image) VALUES('Agriculture equipments','crops growth fastly','/image/equipments.jpg');
INSERT INTO categories(title,description,image) VALUES('fertilizers','crops growth fastly','/image/fertilizers.jpg');
INSERT INTO categories(title,description,image) VALUES('pesticides','for spraying','/image/pesticide.jpg');
INSERT INTO categories(title,description,image) VALUES('Agricultural sprayers','for spraying','/image/sprayers.jpg');
INSERT INTO categories(title,description,image) VALUES('plants micronutrients','for spraying','/image/micronutrient.jpg');

-- PRODUCTS DATA
INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('oats',10,500,'/assets/image/oat.jfif',1);
INSERT INTO products(title,unitprice,stockavailable,image,categoryid)VALUES('wheat',14,50,'/assets/image/wheat.jpg',1);
INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('corn',1000,50,'/assets/image/corn.jfif',1);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('barley',200,50,'/image/sunflower.jpg',1);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('sorghum',2200,50,'/image/sunflower.jpg',1);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('sunflower',1200,50,'/image/sunflower.jpg',1);


INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('tractor',1400,50,'/assets/image/tractor.jfif',2);
INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('harvesters',2200,50,'/assets/image/harvestor.jfif',2);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid)values('balers',1000,50,'/image/sunflower.jpg',2);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('fertilizer spreaders',109,50,'/image/sunflower.jpg',2);

-- FERTILIZERS
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('wood ash',1200,500,'/image/woodash.jpg',3);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('bone meal',1500,500,'/image/bonemeal.jpg',3);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('blood meal',1400,500,'/image/bloodmeal.jpg',3);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('manure',2100,500,'/image/manure.jpg',3);

-- PESTISIDES
INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('karate',1100,500,'/assets/image/karate.jfif',4);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('soloman',3100,500,'/image/manure.jpg',4);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid)VALUES('wood ash',1900,500,'/image/woodash.jpg',4);

-- -- Agricultural sprayers
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('Knapsack sprayer',200,500,'/image/woodash.jpg',5);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid)VALUES('portable power sprayer',500,500,'/image/manure.jpg',5);
-- INSERT INTO products(title,unitprice,stockavailable,image,categoryid) VALUES('mist dust sprayer',800,500,'/image/woodash.jpg',5);

-- ORDERS DATA
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-12-01 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-11-01 12:12:12','2020-11-02 10:02:12',2,800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-10-01 12:12:12','2020-10-02 10:22:12',3,700,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2021-12-01 12:10:12','2021-12-02 10:12:12',4,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2022-11-01 12:11:00','2022-11-02 10:02:12',5,1800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2023-10-01 12:13:11','2023-10-02 10:22:12',6,7100,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-05-01 12:14:13','2020-05-02 10:12:12',7,5020,'initiated');

INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-12-05 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-11-05 12:12:12','2020-11-02 10:02:12',2,800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-10-10 12:12:12','2020-10-02 10:22:12',3,700,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-09-01 12:10:12','2021-12-02 10:12:12',4,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-08-01 12:11:00','2022-11-02 10:02:12',5,1800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-07-01 12:13:11','2023-10-02 10:22:12',6,7100,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-06-01 12:14:13','2020-05-02 10:12:12',7,5020,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-05-01 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-04-01 12:12:12','2020-11-02 10:02:12',2,800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-03-01 12:12:12','2020-10-02 10:22:12',3,700,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-02-01 12:10:12','2020-02-02 10:12:12',4,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:11:00','2020-11-02 10:02:12',5,1800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:13:11','2023-01-02 10:22:12',6,7100,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-05-02 12:14:13','2020-05-02 10:12:12',7,5020,'initiated');

INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-02-05 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-02-05 12:12:12','2020-11-02 10:02:12',2,800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-02-10 12:12:12','2020-10-02 10:22:12',3,700,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:10:12','2021-12-02 10:12:12',4,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:11:00','2022-11-02 10:02:12',5,1800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:13:11','2023-10-02 10:22:12',6,7100,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:14:13','2020-05-02 10:12:12',7,5020,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-03-01 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-03-01 12:12:12','2020-11-02 10:02:12',2,800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-03-01 12:12:12','2020-10-02 10:22:12',3,700,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-04-01 12:10:12','2020-12-02 10:12:12',4,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-04-01 12:11:00','2020-11-02 10:02:12',5,1800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-04-01 12:13:11','2023-10-02 10:22:12',6,7100,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-06-02 12:14:13','2020-06-02 10:12:12',7,5020,'initiated');

-- ORDER_DETAILS DATA
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (1,2,20);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (2,2,25);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (3,1,40);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (4,3,15);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (4,3,48);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (5,5,41);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (7,6,63);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (6,2,63);


-- CARTS DATA
INSERT INTO carts(custid) VALUES (1);
INSERT INTO carts(custid) VALUES (2);
INSERT INTO carts(custid) VALUES (3);
INSERT INTO carts(custid) VALUES (4);
INSERT INTO carts(custid) VALUES (5);




-- CARTS ITEMS DATA
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(1,1,20);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(2,2,40);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(2,2,40);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(3,4,10);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(3,4,50);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(3,2,260);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(4,3,200);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(4,3,201);


-- PAYMENTS DATA
INSERT INTO payments(date,mode,transactionid,userid,orderid) VALUES('2022-03-08 12:08:19','cash on delivery',1,1,1);
INSERT INTO payments(date,mode,transactionid,userid,orderid)  VALUES('2022-03-08 12:08:19','online payment',2,4,1);
INSERT INTO payments(date,mode,transactionid,userid,orderid)  VALUES('2022-03-08 12:08:19','cash on delivery',2,4,2);
INSERT INTO payments(date,mode,transactionid,userid,orderid)  VALUES('2022-03-08 12:08:19','online payment',2,4,3);
INSERT INTO payments(date,mode,transactionid,userid,orderid)  VALUES('2022-03-08 12:08:19','cash on delivery',3,2,4);
INSERT INTO payments(date,mode,transactionid,userid,orderid)  VALUES('2022-06-10 12:45:30','cash on delivery',3,2,2);


-- ADDRESS DATA
INSERT INTO addresses(custid,addressmode,housenumber,landmark,city,state,country,pincode) VALUES(1,'permanent','houseNo.32','akshara garden','pune','maharashtra','india','410503');
INSERT INTO addresses(custid,addressmode,housenumber,landmark,city,state,country,pincode) VALUES(1,'billing','houseNo.32','akshara dairy','pune','maharashtra','india','410502');
INSERT INTO addresses(custid,addressmode,housenumber,landmark,city,state,country,pincode) VALUES(2,'permanent','houseNo.32','season mall','pune','maharashtra','india','410504');
INSERT INTO addresses(custid,addressmode,housenumber,landmark,city,state,country,pincode) VALUES(3,'billing','houseNo.32','Peth-Kurwandi Road','Manchar','Maharashtra','India','410506');
INSERT INTO addresses(custid,addressmode,housenumber,landmark,city,state,country,pincode) VALUES(4,'permanent','houseNo.234','Pune-Nashik Highway','Rajgurunagar','Maharashtra','India','1213');

-- EMPLOYESS DATA
INSERT INTO employees(firstname,lastname,birthdate,hiredate,photo,reportsto,userid) VALUES('chetan','ajab','1999-09-15','2022-05-12','/image/akash.jpg',3,8);
INSERT INTO employees(firstname,lastname,birthdate,hiredate,photo,reportsto,userid) VALUES('abhishek','Bangar','2005-09-15','2022-05-12','/image/vedant.jpg',2,9);
INSERT INTO employees(firstname,lastname,birthdate,hiredate,photo,reportsto,userid) VALUES('anil','hinge','2023-09-15','2022-06-14','/image/sahil.jpg',2,10);
INSERT INTO employees(firstname,lastname,birthdate,hiredate,photo,reportsto,userid) VALUES('rohan','amate','2015-09-15','2022-07-13','/image/prakash.jpg',4,11);
INSERT INTO employees(firstname,lastname,birthdate,hiredate,photo,reportsto,userid) VALUES('ajay','lanke','1988-09-15','2022-08-11','/image/nilesh.jpg',1,12);


select * from users;
select * from users;

-- SHIPPERS DATA
INSERT INTO shippers(companyname,userid) VALUES('agrotech pvt.ltd',13);
INSERT INTO shippers(companyname,userid) VALUES('agrilens pvt.ltd',14);
INSERT INTO shippers(companyname,userid) VALUES('croproot pvt.ltd',15);
INSERT INTO shippers(companyname,userid) VALUES('greenery pvt.ltd',16);


-- SUPPLIERS DATA
INSERT INTO suppliers(companyname,suppliername,address,city,state,userid) VALUES('kaveri','abhishek bhor','pimpalgaon','pune','maharashtra',17);
INSERT INTO suppliers(companyname,suppliername,address,city,state,userid) VALUES('kalash seeds','pratik wagh','khadaki','pune','maharashtra',18);
INSERT INTO suppliers(companyname,suppliername,address,city,state,userid) VALUES('greenary','datta dhoble','manchar','pune','maharashtra',19);
INSERT INTO suppliers(companyname,suppliername,address,city,state,userid) VALUES('kavya','kavya bangar','chandoli','pune','maharashtra',20);

-- USER ROLES DATA
INSERT INTO userroles(userid,roleid) VALUES (1,1);
INSERT INTO userroles(userid,roleid) VALUES (1,1);
INSERT INTO userroles(userid,roleid) VALUES (1,1);
INSERT INTO userroles(userid,roleid) VALUES (1,1);
INSERT INTO userroles(userid,roleid) VALUES (1,1);
INSERT INTO userroles(userid,roleid) VALUES (1,1);
INSERT INTO userroles(userid,roleid) VALUES (1,1);



-- FEEDBACKS DATA
INSERT INTO feedbacks(description,custid) VALUES ('very good facilitities',1);
INSERT INTO feedbacks(description,custid) VALUES ('good quality of products',2);
INSERT INTO feedbacks(description,custid) VALUES ('very good for farmers ',3);
INSERT INTO feedbacks(description,custid) VALUES ('farmers are protected from frauds',4);

INSERT INTO questioncategories(category) VALUES('crop related questions');
INSERT INTO questioncategories(category) VALUES('soil related questions');
INSERT INTO questioncategories(category) VALUES('weather releted questions');


INSERT INTO questions(description,categoryid) VALUES('How can I increase crop yield?',1);
INSERT INTO questions(description,categoryid) VALUES('How can I prevent crop damage from pests and diseases?',1);
INSERT INTO questions(description,categoryid) VALUES('How can I improve soil fertility? ',2);
INSERT INTO questions(description,categoryid) VALUES('How can I improve soil structure? ',2);
INSERT INTO questions(description,categoryid)VALUES('How can I prevent soil erosion? ',2);
INSERT INTO questions(description,categoryid) VALUES('What should I do if there is a drought?',3);
INSERT INTO questions(description,categoryid) VALUES('What should I do if there is heavy rainfall? ',3);
INSERT INTO questions(description,categoryid) VALUES('What should I do if there is extreme heat?',3);


INSERT INTO answers(description,questionid) VALUES('Soil health: Ensure the soil is healthy by adding organic matter and nutrients, improving drainage and water retention, and avoiding soil erosion.',1);
INSERT INTO answers(description,questionid) VALUES('Monitor crops regularly for signs of pests and diseases and take appropriate measures to prevent and control them.
                                          Use resistant crop varieties.',1);
INSERT INTO answers(description,questionid)VALUES('Consider local weather patterns and the plants growth requirements.',2);
INSERT INTO answers(description,questionid) VALUES('Soil testing: Perform soil tests to determine nutrient deficiencies and pH levels.
                                           Fertilizer: Apply appropriate amounts of fertilizers to address nutrient deficiencies.',2);
INSERT INTO answers(description,questionid) VALUES('Reduce soil compaction: Avoid excessive tillage, limit heavy machinery use, and avoid working on wet soil.',2);
INSERT INTO answers(description,questionid) VALUES('Cover crops: Plant cover crops to help prevent soil erosion by reducing runoff and increasing soil structure.',3);
INSERT INTO answers(description,questionid) VALUES('Irrigation: Use irrigation techniques to provide plants with the necessary water.
                                          Crop selection: Choose crops that are drought-tolerant.',3);
INSERT INTO answers(description,questionid) VALUES('Soil erosion prevention: Implement soil erosion prevention practices, such as planting cover crops, to help protect soil from being washed away.
										  Crop selection: Choose crops that are better suited to wet conditions.',3);

INSERT INTO subjectmatterexperts(name,expertise,userid) VALUES('pratima patil','crop related information',22);
INSERT INTO subjectmatterexperts(name,expertise,userid) VALUES('kiran rakshe','soil related information',23);
INSERT INTO subjectmatterexperts(name,expertise,userid) VALUES('mayur gorade','Weather related information',24);



INSERT INTO smeanswers(answerid,questionid,answerdate,smeid) VALUES (1,1,'2023-04-05 12:08:06',1);
INSERT INTO smeanswers(answerid,questionid,answerdate,smeid) VALUES (1,1,'2023-06-05 12:20:19',1);
INSERT INTO smeanswers(answerid,questionid,answerdate,smeid) VALUES (2,1,'2023-07-10 12:23:08',2);
INSERT INTO smeanswers(answerid,questionid,answerdate,smeid) VALUES (2,1,'2023-08-25 12:34:20',2);
INSERT INTO smeanswers(answerid,questionid,answerdate,smeid) VALUES (3,1,'2023-09-15 12:40:30',3);



INSERT INTO customerquestions(custid,questionid,questiondate) VALUES (1,1,'2022-01-15');
INSERT INTO customerquestions(custid,questionid,questiondate) VALUES (2,2,'2023-02-15');
INSERT INTO customerquestions(custid,questionid,questiondate) VALUES (2,4,'2023-01-15');
INSERT INTO customerquestions(custid,questionid,questiondate) VALUES (3,3,'2022-05-15');
INSERT INTO customerquestions(custid,questionid,questiondate) VALUES (4,2,'2022-08-15');

SELECT * FROM employees;
SELECT * FROM feedbacks;
select * from agridoctors;
SELECT * FROM questions;
SELECT * FROM solutions;
SELECT * FROM questionsolutions;
SELECT * FROM users;

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

select * from transactions;


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


-- this procedure is used for updation of stock available when the order is aaded in orderdetails

DELIMITER $$
CREATE PROCEDURE stockavailableupdateinventory (IN orderid INT,IN productid INT ,IN quantity INT )
BEGIN
START TRANSACTION;
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (orderid,productid,quantity);
UPDATE products SET stockavailable=stockavailable-quantity WHERE products.id=productid;
COMMIT;
END $$
DELIMITER ;

CALL stockavailableupdateinventory(1,2,500);

--   this query return user_id of employees;
select userid from userroles where roleid in (SELECT id from roles where role="Employee");

select * from answers;
select * from users;
select * from userroles;
select * from roles;
select * from userroles;
SELECT * FROM feedbacks;
select * from subjectmatterexperts;
select * from orders;
select * from orderdetails;

SELECT count(*) from orders ;

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

select * from questioncategories;
select * from questionsolutions;
select * from solutions;

-- This query gives all questions where category_id =1
select * from questions where categoryid=1;

select * from subjectmatterexperts;
select * from questions;
select * from answers;
select * from categories;
select * from smeanswers;
select * from customerquestions;

-- this query gives all questions of particular smeid
select questions.description from questions Inner join smeanswers on questions.id = smeanswers.questionid where smeanswers.smeid=1;

-- this query gives all questions ,answers of particular smeid
select questions.description from subjectmatterexperts,smeanswers ,questions inner join answers on questions.id = answers.questionid where
answers.id =smeanswers.answerid and subjectmatterexperts.id=smeanswers.smeid and smeanswers.smeid=1;

-- This method gives answers  of particular provided question id.
select description from answers where questionid =1;

SELECT products.id,products.title,products.image,products.unitprice,cartitems.quantity FROM products inner join cartitems on products.id=cartitems.productid where cartitems.cartid=2;
select * from cartitems;
select * from carts;

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

select * from orderdetails;
select * from orders;
select * from cartitems;
select * from products;

-- this query gives orderhistory of particular customer
select products.title,products.image,products.unitprice,orders.orderdate,orders.shippeddate,(products.unitprice*cartitems.quantity)as total,orders.status ,cartitems.quantity from products,orders,cartitems inner join carts on carts.id = cartitems.cartid where products.id =cartitems.productid and orders.custid =carts.custid and orders.custid=2;

-- this query gives orderdetails of particular orderid
select orders.id, products.title,products.image,products.unitprice,orders.orderdate,orders.shippeddate,(products.unitprice*cartitems.quantity)as total,orders.status ,cartitems.quantity from orderdetails,orders,cartitems inner join products on products.id = cartitems.productid where orders.id = orderdetails.orderid and orderdetails.productid =cartitems.productid and orders.id=1;

-- this query gives the question and questiondate
select questions.description,customerquestions.questiondate from questions 
inner join customerquestions on customerquestions.questionid=questions.id where customerquestions.custid=2;

select * from orders;
select * from customers;

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

select name from subjectmatterexperts inner join smeanswers on subjectmatterexperts.id = smeanswers.smeid where smeanswers.questionid=1