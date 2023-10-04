-- Active: 1682349138553@@127.0.0.1@3306@ekrushi


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






