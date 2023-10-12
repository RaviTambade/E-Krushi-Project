-- Active: 1678359546568@@127.0.0.1@3306@ekrushi

CREATE PROCEDURE insertpayment(
    IN mode VARCHAR(255),
    IN paymentstatus VARCHAR(255),
    IN transactionid INT,
    IN orderid INT
)
BEGIN
    IF mode = 'cash on delivery' THEN
        INSERT INTO payments ( mode, paymentstatus, orderid)
        VALUES ( mode, paymentstatus, orderid);
    ELSEIF mode = 'net banking' THEN
        INSERT INTO payments ( mode, paymentstatus, transactionid, orderid)
        VALUES ( mode,paymentstatus,transactionid,orderid);
    END IF;
END;



CREATE TRIGGER after_order_insert
AFTER INSERT ON orders
FOR EACH ROW
BEGIN
    INSERT INTO ordershistory (orderid,status)
    VALUES (NEW.id,NEW.status);
END;



CREATE TRIGGER after_order_update
AFTER UPDATE ON orders
FOR EACH ROW
BEGIN
    IF NEW.status <> OLD.status THEN
        INSERT INTO ordershistory (orderid,status)
        VALUES (OLD.id, NEW.status);
    END IF;
END;



CREATE PROCEDURE GetStoreOrderCountForMonth
(
    IN given_date DATE,
    IN givenStoreId INT,
    OUT todaysOrders INT,
    OUT yesterdaysOrders INT,
    OUT weekOrders INT,
    OUT monthOrders INT
)
BEGIN
  
    SELECT count(*) INTO todaysOrders
    FROM Orders
    WHERE DATE(orderdate) = given_date  AND storeid=givenStoreId;


    SELECT count(*) INTO yesterdaysOrders
    FROM Orders
    WHERE DATE(orderdate) = DATE_SUB(given_date, INTERVAL 1 DAY)AND storeid=givenStoreId;

 
    SELECT count(*) INTO weekOrders
    FROM Orders
    WHERE DATE(orderdate) BETWEEN DATE_SUB(given_date, INTERVAL (DAYOFWEEK(given_date) - 1) DAY) 
    AND DATE_ADD(given_date, INTERVAL (7 - DAYOFWEEK(given_date)) DAY) AND storeid=givenStoreId; 
  
     SELECT count(*) INTO monthOrders
    FROM Orders
    WHERE DATE(orderdate) BETWEEN DATE_SUB(given_date, INTERVAL DAY(given_date) - 1 DAY)
    AND LAST_DAY(given_date) AND storeid=givenStoreId;
END;


  
  
CREATE PROCEDURE GetTopFiveSellingProductQuantityByStore
(
    IN todays_date DATE,
    IN mode VARCHAR(255),
    IN store_id INT
)
BEGIN
 DECLARE totalquantity INT default 0;
  IF mode= 'today' THEN
   
    SELECT SUM(orderdetails.quantity) INTO totalquantity FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orders.orderdate) = todays_date  AND storeid=store_id;


    SELECT totalquantity, products.id as productid,SUM(orderdetails.quantity) as quantity,
    ((SUM(orderdetails.quantity)/totalquantity)*100) as percentage,
    products.title as title,products.image as imageurl FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orders.orderdate) = todays_date  AND storeid=store_id
    GROUP BY productid
    ORDER BY quantity DESC
    LIMIT 5; 

 ELSEIF mode='yesterday' THEN
    SELECT SUM(orderdetails.quantity) INTO totalquantity FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orderdate) = DATE_SUB(todays_date, INTERVAL 1 DAY) AND storeid=store_id;
 
    SELECT totalquantity, products.id AS productid, SUM(orderdetails.quantity) AS quantity,
    ((SUM(orderdetails.quantity)/totalquantity)*100) as percentage,
    products.title as title ,products.image as imageurl FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orderdate) = DATE_SUB(todays_date, INTERVAL 1 DAY)   AND storeid=store_id
    GROUP BY productid
    ORDER BY quantity DESC
    LIMIT 5;

 ELSEIF mode='week' THEN

    SELECT SUM(orderdetails.quantity) INTO totalquantity FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orders.orderdate) BETWEEN DATE_SUB(todays_date, INTERVAL (DAYOFWEEK(todays_date) - 1) DAY) 
    AND DATE_ADD(todays_date, INTERVAL (7 - DAYOFWEEK(todays_date)) DAY)  AND storeid=store_id;
    

    SELECT totalquantity, products.id AS productid, SUM(orderdetails.quantity) AS quantity,
    ((SUM(orderdetails.quantity)/totalquantity)*100) as percentage,
    products.title as title ,products.image as imageurl FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orders.orderdate) BETWEEN DATE_SUB(todays_date, INTERVAL (DAYOFWEEK(todays_date) - 1) DAY) 
    AND DATE_ADD(todays_date, INTERVAL (7 - DAYOFWEEK(todays_date)) DAY)  AND storeid=store_id
    GROUP BY productid
    ORDER BY quantity DESC
    LIMIT 5;
 ELSEIF mode='month' THEN

    SELECT SUM(orderdetails.quantity) INTO totalquantity FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orders.orderdate) BETWEEN DATE_SUB(todays_date, INTERVAL DAY(todays_date) - 1 DAY)
    AND LAST_DAY(todays_date)  AND storeid=store_id;
    
    SELECT totalquantity, products.id AS productid,SUM(orderdetails.quantity) AS quantity,
    ((SUM(orderdetails.quantity)/totalquantity)*100) as percentage,
    products.title as title ,products.image as imageurl FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orders.orderdate) BETWEEN DATE_SUB(todays_date, INTERVAL DAY(todays_date) - 1 DAY)
    AND LAST_DAY(todays_date)  AND storeid=store_id
    GROUP BY productid
    ORDER BY quantity DESC
    LIMIT 5;

 END IF;
END;






-- categoriwise product count

CREATE PROCEDURE GetCategorywiseProductCountByStore
(
    IN given_date DATE,
    IN mode VARCHAR(255),
    IN store_id INT
)
BEGIN
   IF mode= 'today' THEN
    SELECT categories.title, sum(orderdetails.quantity) as quantity
    FROM categories
    INNER JOIN products on categories.id=products.categoryid
    INNER JOIN productdetails on products.id=productdetails.productid
    INNER JOIN orderdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN orders on orderdetails.orderid=orders.id
    WHERE DATE(orders.orderdate) = given_date AND storeid=store_id
    GROUP BY categories.id  ; 

  ELSEIF mode='yesterday' THEN
    SELECT categories.title, sum(orderdetails.quantity) as quantity
    FROM categories
    INNER JOIN products on categories.id=products.categoryid
    INNER JOIN productdetails on products.id=productdetails.productid
    INNER JOIN orderdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN orders on orderdetails.orderid=orders.id
    WHERE DATE(orders.orderdate)=DATE_SUB(given_date, INTERVAL 1 DAY)AND storeid=store_id
    GROUP BY categories.id  ; 

 ELSEIF mode='week' THEN
    SELECT categories.title, sum(orderdetails.quantity) as quantity
    FROM categories
    INNER JOIN products on categories.id=products.categoryid
    INNER JOIN productdetails on products.id=productdetails.productid
    INNER JOIN orderdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN orders on orderdetails.orderid=orders.id
    WHERE  DATE(orders.orderdate) BETWEEN DATE_SUB(given_date, INTERVAL (DAYOFWEEK(given_date) - 1) DAY) 
    AND DATE_ADD(given_date, INTERVAL (7 - DAYOFWEEK(given_date)) DAY) AND storeid=store_id
    GROUP BY categories.id  ; 

  
 ELSEIF mode='month' THEN
    SELECT categories.title, sum(orderdetails.quantity) as quantity
    FROM categories
    INNER JOIN products on categories.id=products.categoryid
    INNER JOIN productdetails on products.id=productdetails.productid
    INNER JOIN orderdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN orders on orderdetails.orderid=orders.id
    WHERE  DATE(orders.orderdate) BETWEEN DATE_SUB(given_date, INTERVAL DAY(given_date) - 1 DAY)
    AND LAST_DAY(given_date) AND storeid=store_id
    GROUP BY categories.id  ; 
    END IF;
END;

CREATE PROCEDURE GetStoreOrderCountByMonth(
   IN given_year INT,
   IN given_storeid INT
)
BEGIN
WITH MonthNumbers AS (
    SELECT 1 AS month_number
    UNION ALL SELECT 2
    UNION ALL SELECT 3
    UNION ALL SELECT 4
    UNION ALL SELECT 5
    UNION ALL SELECT 6
    UNION ALL SELECT 7
    UNION ALL SELECT 8
    UNION ALL SELECT 9
    UNION ALL SELECT 10
    UNION ALL SELECT 11
    UNION ALL SELECT 12
)
SELECT
 MONTHNAME(CONCAT('2023-', MonthNumbers.month_number,'-01')) AS month,
     COUNT(orders.orderdate) AS order_count
FROM
    MonthNumbers
LEFT JOIN
    orders ON MonthNumbers.month_number = MONTH(orders.orderdate) AND YEAR(orders.orderdate) = given_year AND storeid = given_storeid
GROUP BY
    MonthNumbers.month_number
ORDER BY
    MonthNumbers.month_number;
END;
