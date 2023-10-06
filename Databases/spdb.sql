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


CREATE PROCEDURE OrdersByDate
(
    IN given_date DATE
)
BEGIN
  --todays orders query
    SELECT *
    FROM Orders
    WHERE DATE(orderdate) = given_date;


--yesterdays order query
    SELECT *
    FROM Orders
    WHERE DATE(orderdate) = DATE_SUB(given_date, INTERVAL 1 DAY);

 --weekly orders
    SELECT *
    FROM Orders
    WHERE DATE(orderdate) BETWEEN DATE_SUB(given_date, INTERVAL (DAYOFWEEK(given_date) - 1) DAY) 
    AND DATE_ADD(given_date, INTERVAL (7 - DAYOFWEEK(given_date)) DAY);

    --monthly orders
     SELECT *
    FROM Orders
    WHERE DATE(orderdate) BETWEEN DATE_SUB('2023-09-06', INTERVAL DAY('2023-09-06') - 1 DAY)
    AND LAST_DAY('2023-09-06');
END;


CALL OrdersByDate('2023-09-06');
