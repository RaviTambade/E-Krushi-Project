CREATE DATABASE E_Krushi;

USE E_Krushi;

CREATE TABLE users(user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                   email varchar(255),
                   password varchar(255),
                   contact_number varchar(255));
                   
CREATE TABLE customer(cust_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
					  first_name VARCHAR(255),
                      last_name VARCHAR(25),
                      contact_number VARCHAR(255),
                      email VARCHAR(50),
                      password varchar(250));
                      
CREATE TABLE categories(category_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                        category_name varchar(255),
                        description varchar(255),
                        image varchar(255));
                        
CREATE TABLE products(product_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
					  product_name varchar(255),
                      unit_price double,
                      stock_available INT,
                      image varchar(255),
                      category_id INT NOT NULL, 
                      CONSTRAINT fk_category_id FOREIGN KEY (category_id) REFERENCES categories(category_id) ON UPDATE CASCADE ON DELETE CASCADE);
					


                      
                        
                      
                      