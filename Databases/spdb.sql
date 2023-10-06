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


CREATE PROCEDURE GetOrdersByDate
(
    IN given_date DATE,
    OUT todaysOrders INT,
    OUT yesterdaysOrders INT,
    OUT weekOrders INT,
    OUT monthOrders INT
)
BEGIN
  
    SELECT count(*) INTO todaysOrders
    FROM Orders
    WHERE DATE(orderdate) = given_date;


    SELECT count(*) INTO yesterdaysOrders
    FROM Orders
    WHERE DATE(orderdate) = DATE_SUB(given_date, INTERVAL 1 DAY);

 
    SELECT count(*) INTO weekOrders
    FROM Orders
    WHERE DATE(orderdate) BETWEEN DATE_SUB(given_date, INTERVAL (DAYOFWEEK(given_date) - 1) DAY) //2023-09-08
    AND DATE_ADD(given_date, INTERVAL (7 - DAYOFWEEK(given_date)) DAY); //2023-09-14

  
     SELECT count(*) INTO monthOrders
    FROM Orders
    WHERE DATE(orderdate) BETWEEN DATE_SUB(given_date, INTERVAL DAY(given_date) - 1 DAY)
    AND LAST_DAY(given_date);
END;


CALL GetOrdersByDate('2023-09-10',@todaysOrders,@yesterdaysOrders,@weekOrders,@monthOrders);

SELECT @todaysOrders,@yesterdaysOrders,@weekOrders,@monthOrders ;