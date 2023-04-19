CREATE DATABASE E_Krushi;
USE E_Krushi;

CREATE TABLE users(user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,email varchar(255) unique,password varchar(255),contact_number varchar(255));
                   
CREATE TABLE customers(cust_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,first_name VARCHAR(255),last_name VARCHAR(25),contact_number VARCHAR(255),email VARCHAR(50),password varchar(250));
                      
CREATE TABLE categories(category_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,category_title varchar(255),description varchar(255),image varchar(255));
                        
CREATE TABLE products(product_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,product_title varchar(255),unit_price double,stock_available INT,image varchar(255),category_id INT NOT NULL, CONSTRAINT fk_category_id FOREIGN KEY (category_id) REFERENCES categories(category_id) ON UPDATE CASCADE ON DELETE CASCADE);
 
CREATE TABLE orders(order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_date DATETIME NOT NULL ,shipped_date DATETIME NOT NULL,cust_id INT NOT NULL,CONSTRAINT fk FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE, total DOUBLE ,status ENUM('approved','initiated','cancelled','delivered','inprogress') NOT NULL);

CREATE TABLE carts(cart_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cust_id INT NOT NULL,CONSTRAINT fk_1 FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE, total DOUBLE ,status ENUM('approved','initiated','cancelled','delivered','inprogress') NOT NULL);

CREATE TABLE cart_items(cart_items_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cart_id INT NOT NULL,CONSTRAINT fk_02 FOREIGN KEY (cart_id) REFERENCES carts(cart_id)ON UPDATE CASCADE ON DELETE CASCADE,product_id INT NOT NULL,CONSTRAINT fk_03 FOREIGN KEY (product_id) REFERENCES products(product_id) ,quantity INT NOT NULL); 

INSERT INTO users(email,password,contact_number) VALUES('shrisha12@gmail.com','shrisha@123','9850540298');
INSERT INTO users(email,password,contact_number) VALUES('shivam12@gmail.com','shivam@123','7450540298');
INSERT INTO users(email,password,contact_number) VALUES('kranti12@gmail.com','kranti@123','8850540298');
INSERT INTO users(email,password,contact_number) VALUES('rutuja12@gmail.com','rutuja@123','9960540298');

INSERT INTO customers(first_name,last_name,contact_number,email,password) VALUES('pratiksha','bangar','7834256798','pratikshabangar11@gmail.com','pratiksha@123');                       
INSERT INTO customers(first_name,last_name,contact_number,email,password) VALUES('priyanka','jadhav','7834256783','priyankajadhav09@gmail.com','priyanka@123');
INSERT INTO customers(first_name,last_name,contact_number,email,password) VALUES('pooja','divekar','9098556798','poojadivekar05@gmail.com','pooja@123');             
INSERT INTO customers(first_name,last_name,contact_number,email,password) VALUES('pratik','bhor','9804256798','pratikbhor06@gmail.com','pratik@123');     



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

     