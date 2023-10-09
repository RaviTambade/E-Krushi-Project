-- Active: 1694968636816@@127.0.0.1@3306@ekrushi


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


-- orders by date

CREATE PROCEDURE GetOrdersByDate
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


CALL GetOrdersByDate('2023-07-26',1,@todaysOrders,@yesterdaysOrders,@weekOrders,@monthOrders);

SELECT @todaysOrders,@yesterdaysOrders,@weekOrders,@monthOrders ;



SELECT * FROM products
WHERE id IN (
    SELECT productid
    FROM productdetails
    WHERE id IN (
        SELECT productdetailsid
        FROM (
            SELECT productdetailsid, SUM(quantity) AS TotalQuantity
            FROM orderdetails
            GROUP BY productdetailsid
            ORDER BY TotalQuantity DESC
            LIMIT 5
        ) AS TopProducts
    )
);




-- top 5 products orders
CREATE PROCEDURE GetTopProducts
(
    IN given_date DATE,
    IN MODE VARCHAR(255),
    IN givenStoreId INT
)
BEGIN
  IF MODE= 'daily' THEN
   SELECT
    products.id as productId,
    SUM(orderdetails.quantity) as TotalQuantity,
    products.title as title
    FROM
    orderdetails
INNER JOIN
    productdetails ON productdetails.id = orderdetails.productdetailsid
INNER JOIN
    orders ON orders.id = orderdetails.orderid
INNER JOIN
    products ON productdetails.productid = products.id
WHERE
 DATE(orders.orderdate) = given_date  AND storeid=givenStoreId
GROUP BY
    productid
ORDER BY
    TotalQuantity DESC
LIMIT
    5; 
ELSEIF MODE='yesterday' THEN
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
  DATE(orderdate) = DATE_SUB(given_date, INTERVAL 1 DAY)   AND storeid=givenStoreId
GROUP BY
    productid
ORDER BY
    TotalQuantity DESC
LIMIT
    5;
ELSEIF MODE='weekly' THEN
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
 DATE(orders.orderdate) BETWEEN DATE_SUB(given_date, INTERVAL (DAYOFWEEK(given_date) - 1) DAY) 
    AND DATE_ADD(given_date, INTERVAL (7 - DAYOFWEEK(given_date)) DAY)  AND storeid=givenStoreId
GROUP BY
    productid
ORDER BY
    TotalQuantity DESC
LIMIT
    5;
ELSEIF MODE='monthly' THEN
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
    DATE(orders.orderdate) BETWEEN DATE_SUB(given_date, INTERVAL DAY(given_date) - 1 DAY)
    AND LAST_DAY(given_date)  AND storeid=givenStoreId
GROUP BY
    productid
ORDER BY
    TotalQuantity DESC
LIMIT
    5;
END IF;

END;




CALL Products('2023-08-10','yesterday');




-- categoriwise orders

CREATE PROCEDURE GetCategoriwiseOrders
(
    IN given_date DATE,
    IN givenStoreId INT,
    IN category varchar(250),
    OUT todaysOrders INT,
    OUT yesterdaysOrders INT,
    OUT weekOrders INT,
    OUT monthOrders INT
)
BEGIN
  
    select COUNT(*) INTO todaysOrders from orders
    INNER JOIN orderdetails on orders.id=orderdetails.orderid
    INNER JOIN productdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN products on productdetails.productid=products.id
    INNER JOIN categories ON products.categoryid=categories.id
    WHERE categories.title=category AND DATE(orders.orderdate) = given_date AND storeid=4; 
  
  
  select COUNT(*) INTO yesterdaysOrders from orders
    INNER JOIN orderdetails on orders.id=orderdetails.orderid
    INNER JOIN productdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN products on productdetails.productid=products.id
    INNER JOIN categories ON products.categoryid=categories.id
    WHERE categories.title=category AND DATE(orders.orderdate)=DATE_SUB(given_date, INTERVAL 1 DAY)AND storeid=givenStoreId;
  
    select COUNT(*) INTO weekOrders from orders
    INNER JOIN orderdetails on orders.id=orderdetails.orderid
    INNER JOIN productdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN products on productdetails.productid=products.id
    INNER JOIN categories ON products.categoryid=categories.id
    WHERE categories.title=category AND DATE(orders.orderdate) BETWEEN DATE_SUB(given_date, INTERVAL (DAYOFWEEK(given_date) - 1) DAY) 
    AND DATE_ADD(given_date, INTERVAL (7 - DAYOFWEEK(given_date)) DAY) AND storeid=4; 
  
                            
     select COUNT(*) INTO monthOrders from orders
    INNER JOIN orderdetails on orders.id=orderdetails.orderid
    INNER JOIN productdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN products on productdetails.productid=products.id
    INNER JOIN categories ON products.categoryid=categories.id
    WHERE categories.title=category AND DATE(orders.orderdate) BETWEEN DATE_SUB(given_date, INTERVAL DAY(given_date) - 1 DAY)
    AND LAST_DAY(given_date) AND storeid=givenStoreId;
END;


CALL GetCategoriwiseOrders('2023-07-02',4,'seeds',@todaysOrders,@yesterdaysOrders,@weekOrders,@monthOrders);

SELECT @todaysOrders,@yesterdaysOrders,@weekOrders,@monthOrders ;

