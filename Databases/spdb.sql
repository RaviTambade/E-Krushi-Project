-- Active: 1696576841746@@127.0.0.1@3306@ekrushi


DELIMITER $$

CREATE PROCEDURE insertpayment(
    IN mode VARCHAR(255),
    IN paymentstatus VARCHAR(255),
    IN transactionid INT,
    IN orderid INT
)
BEGIN
    IF mode = 'cash on delivery' THEN
        INSERT INTO payments (mode, paymentstatus, orderid)
        VALUES (mode, paymentstatus, orderid);
    ELSEIF mode = 'net banking' THEN
        INSERT INTO payments (mode, paymentstatus, transactionid, orderid)
        VALUES (mode, paymentstatus, transactionid, orderid);
    END IF;
END$$

DELIMITER ;


DELIMITER $$

CREATE TRIGGER after_order_insert
AFTER INSERT ON orders
FOR EACH ROW
BEGIN
    INSERT INTO ordershistory (orderid, status)
    VALUES (NEW.id, NEW.status);
END$$

DELIMITER ;



DELIMITER $$

CREATE TRIGGER after_order_update
AFTER UPDATE ON orders
FOR EACH ROW
BEGIN
    IF NEW.status <> OLD.status THEN
        INSERT INTO ordershistory (orderid, status)
        VALUES (OLD.id, NEW.status);
    END IF;
END$$

DELIMITER ;


DELIMITER $$

CREATE PROCEDURE GetStoreOrderCountForMonth(
    IN given_date DATE,
    IN givenStoreId INT,
    OUT todaysOrders INT,
    OUT yesterdaysOrders INT,
    OUT weekOrders INT,
    OUT monthOrders INT
)
BEGIN
    -- Count of today's orders
    SELECT COUNT(*) INTO todaysOrders
    FROM orders
    WHERE DATE(orderdate) = given_date AND status <> 'cancelled' AND storeid = givenStoreId;

    -- Count of yesterday's orders
    SELECT COUNT(*) INTO yesterdaysOrders
    FROM orders
    WHERE DATE(orderdate) = DATE_SUB(given_date, INTERVAL 1 DAY) AND status <> 'cancelled' AND storeid = givenStoreId;

    -- Count of week's orders
    SELECT COUNT(*) INTO weekOrders
    FROM orders
    WHERE DATE(orderdate) BETWEEN DATE_SUB(given_date, INTERVAL (DAYOFWEEK(given_date) - 1) DAY) 
    AND DATE_ADD(given_date, INTERVAL (7 - DAYOFWEEK(given_date)) DAY) AND status <> 'cancelled' AND storeid = givenStoreId;

    -- Count of month's orders
    SELECT COUNT(*) INTO monthOrders
    FROM orders
    WHERE DATE(orderdate) BETWEEN DATE_SUB(given_date, INTERVAL DAY(given_date) - 1 DAY)
    AND LAST_DAY(given_date) AND status <> 'cancelled' AND storeid = givenStoreId;
END$$

DELIMITER ;


-- drop procedure if exists GetTopFiveSellingProductQuantityByStore

DELIMITER $$
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
    WHERE DATE(orders.orderdate) = todays_date AND orders.status <> 'cancelled'  AND storeid=store_id;

    SELECT totalquantity, products.id as productid,SUM(orderdetails.quantity) as quantity,
    ((SUM(orderdetails.quantity)/totalquantity)*100) as percentage,
    products.title as title,products.image as imageurl FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orders.orderdate) = todays_date AND orders.status <> 'cancelled'  AND storeid=store_id
    GROUP BY productid
    ORDER BY quantity DESC
    LIMIT 5; 

 ELSEIF mode='yesterday' THEN
    SELECT SUM(orderdetails.quantity) INTO totalquantity FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orderdate) = DATE_SUB(todays_date, INTERVAL 1 DAY) AND orders.status <> 'cancelled' AND storeid=store_id;
 
    SELECT totalquantity, products.id AS productid, SUM(orderdetails.quantity) AS quantity,
    ((SUM(orderdetails.quantity)/totalquantity)*100) as percentage,
    products.title as title ,products.image as imageurl FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orderdate) = DATE_SUB(todays_date, INTERVAL 1 DAY) AND orders.status <> 'cancelled'  AND storeid=store_id
    GROUP BY productid
    ORDER BY quantity DESC
    LIMIT 5;

 ELSEIF mode='week' THEN

    SELECT SUM(orderdetails.quantity) INTO totalquantity FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orders.orderdate) BETWEEN DATE_SUB(todays_date, INTERVAL (DAYOFWEEK(todays_date) - 1) DAY) 
    AND DATE_ADD(todays_date, INTERVAL (7 - DAYOFWEEK(todays_date)) DAY) AND orders.status <> 'cancelled'  AND storeid=store_id;
    

    SELECT totalquantity, products.id AS productid, SUM(orderdetails.quantity) AS quantity,
    ((SUM(orderdetails.quantity)/totalquantity)*100) as percentage,
    products.title as title ,products.image as imageurl FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orders.orderdate) BETWEEN DATE_SUB(todays_date, INTERVAL (DAYOFWEEK(todays_date) - 1) DAY) 
    AND DATE_ADD(todays_date, INTERVAL (7 - DAYOFWEEK(todays_date)) DAY) AND orders.status <> 'cancelled'  AND storeid=store_id
    GROUP BY productid
    ORDER BY quantity DESC
    LIMIT 5;
 ELSEIF mode='month' THEN

    SELECT SUM(orderdetails.quantity) INTO totalquantity FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orders.orderdate) BETWEEN DATE_SUB(todays_date, INTERVAL DAY(todays_date) - 1 DAY)
    AND LAST_DAY(todays_date) AND orders.status <> 'cancelled'  AND storeid=store_id;
    
    SELECT totalquantity, products.id AS productid,SUM(orderdetails.quantity) AS quantity,
    ((SUM(orderdetails.quantity)/totalquantity)*100) as percentage,
    products.title as title ,products.image as imageurl FROM orderdetails
    INNER JOIN productdetails ON productdetails.id = orderdetails.productdetailsid
    INNER JOIN orders ON orders.id = orderdetails.orderid
    INNER JOIN products ON productdetails.productid = products.id
    WHERE DATE(orders.orderdate) BETWEEN DATE_SUB(todays_date, INTERVAL DAY(todays_date) - 1 DAY)
    AND LAST_DAY(todays_date) AND orders.status <> 'cancelled'  AND storeid=store_id
    GROUP BY productid
    ORDER BY quantity DESC
    LIMIT 5;

 END IF;
END$$
DELIMITER ;



-- categoriwise product count
DELIMITER $$
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
    WHERE DATE(orders.orderdate) = given_date AND orders.status <> 'cancelled' AND storeid=store_id
    GROUP BY categories.id  ; 

  ELSEIF mode='yesterday' THEN
    SELECT categories.title, sum(orderdetails.quantity) as quantity
    FROM categories
    INNER JOIN products on categories.id=products.categoryid
    INNER JOIN productdetails on products.id=productdetails.productid
    INNER JOIN orderdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN orders on orderdetails.orderid=orders.id
    WHERE DATE(orders.orderdate)=DATE_SUB(given_date, INTERVAL 1 DAY)AND orders.status <> 'cancelled' AND storeid=store_id
    GROUP BY categories.id  ; 

 ELSEIF mode='week' THEN
    SELECT categories.title, sum(orderdetails.quantity) as quantity
    FROM categories
    INNER JOIN products on categories.id=products.categoryid
    INNER JOIN productdetails on products.id=productdetails.productid
    INNER JOIN orderdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN orders on orderdetails.orderid=orders.id
    WHERE  DATE(orders.orderdate) BETWEEN DATE_SUB(given_date, INTERVAL (DAYOFWEEK(given_date) - 1) DAY) 
    AND DATE_ADD(given_date, INTERVAL (7 - DAYOFWEEK(given_date)) DAY) AND orders.status <> 'cancelled' AND storeid=store_id
    GROUP BY categories.id  ; 

  
 ELSEIF mode='month' THEN
    SELECT categories.title, sum(orderdetails.quantity) as quantity
    FROM categories
    INNER JOIN products on categories.id=products.categoryid
    INNER JOIN productdetails on products.id=productdetails.productid
    INNER JOIN orderdetails on productdetails.id=orderdetails.productdetailsid
    INNER JOIN orders on orderdetails.orderid=orders.id
    WHERE  DATE(orders.orderdate) BETWEEN DATE_SUB(given_date, INTERVAL DAY(given_date) - 1 DAY)
    AND LAST_DAY(given_date) AND orders.status <> 'cancelled' AND storeid=store_id
    GROUP BY categories.id  ; 
    END IF;
END;
END$$
DELIMITER ;

CALL  GetCategorywiseProductCountByStore('2023-10-10','month',1);



DELIMITER $$

CREATE PROCEDURE GetStoreOrderCountByMonth(
    IN given_year INT,
    IN given_storeid INT
)
BEGIN
    WITH MonthNumbers AS (
        SELECT 1 AS month_number
        UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5
        UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9
        UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL SELECT 12
    )
    SELECT MONTHNAME(CONCAT(given_year, '-', MonthNumbers.month_number, '-01')) AS month,
           COUNT(orders.orderdate) AS order_count
    FROM MonthNumbers
    LEFT JOIN orders ON MonthNumbers.month_number = MONTH(orders.orderdate)
                     AND YEAR(orders.orderdate) = given_year
                     AND orders.status <> 'cancelled'
                     AND storeid = given_storeid
    GROUP BY MonthNumbers.month_number
    ORDER BY MonthNumbers.month_number;
END$$

DELIMITER ;


DELIMITER $$

CREATE PROCEDURE GetStoreOrderCountByStatus(
    IN store_id INT
)
BEGIN
    -- Declare variables for holding the results
    DECLARE pending INT DEFAULT 0;
    DECLARE approved INT DEFAULT 0;
    DECLARE ready_to_dispatch INT DEFAULT 0;
    DECLARE picked INT DEFAULT 0;
    DECLARE in_progress INT DEFAULT 0;
    DECLARE delivered INT DEFAULT 0;
    DECLARE cancelled INT DEFAULT 0;

    -- Error handling: Check if store_id exists in the 'stores' table
    IF NOT EXISTS (SELECT 1 FROM stores WHERE id = store_id) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Store ID not found';
    ELSE
        -- Count orders by status for the given store_id
        SELECT 
            SUM(CASE WHEN status = 'pending' THEN 1 ELSE 0 END) INTO pending,
            SUM(CASE WHEN status = 'approved' THEN 1 ELSE 0 END) INTO approved,
            SUM(CASE WHEN status = 'ready to dispatch' THEN 1 ELSE 0 END) INTO ready_to_dispatch,
            SUM(CASE WHEN status = 'picked' THEN 1 ELSE 0 END) INTO picked,
            SUM(CASE WHEN status = 'in progress' THEN 1 ELSE 0 END) INTO in_progress,
            SUM(CASE WHEN status = 'delivered' THEN 1 ELSE 0 END) INTO delivered,
            SUM(CASE WHEN status = 'cancelled' THEN 1 ELSE 0 END) INTO cancelled
        FROM orders 
        WHERE storeid = store_id;

        -- Output the results
        SELECT pending, approved, ready_to_dispatch, picked, in_progress, delivered, cancelled;
    END IF;
END$$

DELIMITER ;




DELIMITER $$

CREATE PROCEDURE GetShipperOrderCountByStatus(
   IN shipper_id INT
)
BEGIN
    -- Error handling: Check if shipper_id exists in the 'shippers' table
    IF NOT EXISTS (SELECT 1 FROM shippers WHERE id = shipper_id) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Shipper ID not found';
    ELSE
        -- Count orders by status for the given shipper_id
        SELECT
            SUM(CASE WHEN status = 'ready to dispatch' THEN 1 ELSE 0 END) AS ready_to_dispatch,
            SUM(CASE WHEN status = 'picked' THEN 1 ELSE 0 END) AS picked,
            SUM(CASE WHEN status = 'in progress' THEN 1 ELSE 0 END) AS in_progress,
            SUM(CASE WHEN status = 'delivered' THEN 1 ELSE 0 END) AS delivered,
            SUM(CASE WHEN status = 'cancelled' THEN 1 ELSE 0 END) AS cancelled
        FROM orders   
        INNER JOIN shipperorders ON orders.id = shipperorders.orderid 
        WHERE shipperorders.shipperid = shipper_id;
    END IF;
END$$

DELIMITER ;

DROP PROCEDURE IF EXISTS deliverorderscountbymonth

DELIMITER $$

CREATE PROCEDURE deliverorderscountbymonth(
    IN given_shipperid INT,
    IN given_year INT
)
BEGIN
    SELECT all_months.Month AS Month,
           IFNULL(delivered_orders.Count, 0) AS Count
    FROM (
        -- Generate a list of months (January to December)
        SELECT DATE_FORMAT(DATE_ADD('2023-01-01', INTERVAL n MONTH), '%M') AS Month
        FROM (
            SELECT 0 AS n UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL
            SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11
        ) AS numbers
    ) AS all_months
    LEFT JOIN (
        -- Count delivered orders per month for the given shipper and year
        SELECT DATE_FORMAT(orders.shippeddate, '%M') AS Month, COUNT(*) AS Count
        FROM orders
        INNER JOIN shipperorders ON orders.id = shipperorders.orderid
        WHERE orders.status = 'delivered' 
          AND shipperorders.shipperid = given_shipperid  
          AND YEAR(orders.orderdate) = given_year
        GROUP BY DATE_FORMAT(orders.shippeddate, '%M')
    ) AS delivered_orders ON all_months.Month = delivered_orders.Month
    ORDER BY STR_TO_DATE(all_months.Month, '%M');
END$$

DELIMITER ;

CALL deliverorderscountbymonth(4,2023);


DROP PROCEDURE IF EXISTS NotAnsweredQuestions

DELIMITER $$

CREATE PROCEDURE NotAnsweredQuestions(
    IN given_userid INT
)
BEGIN
    SELECT questions.id, questions.description
    FROM questions
    LEFT JOIN answers ON questions.id = answers.questionid
    LEFT JOIN subjectmatterexperts ON subjectmatterexperts.categoryid = questions.categoryid
    WHERE answers.questionid IS NULL 
      AND subjectmatterexperts.userid = given_userid;
END$$

DELIMITER ;


CALL NotAnsweredQuestions(40);