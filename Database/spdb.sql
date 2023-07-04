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


DELIMITER $$
CREATE PROCEDURE CreateOrder(IN cartId BIGINT )
BEGIN
DECLARE noMoreRow INT default 0; 
DECLARE orderId INT;
DECLARE productId INT;
DECLARE quantity INT;
DECLARE custId INT;
DECLARE cart_cursor CURSOR  FOR SELECT cart_items.product_id,cart_items.quantity FROM cart_items WHERE cart_id=cartId; 
DECLARE CONTINUE HANDLER FOR NOT FOUND SET noMoreRow = 1;
SELECT cust_id INTO custId FROM carts WHERE cart_id=cartId;
INSERT INTO orders (order_date, cust_id,total,status) VALUES (now(),custId,0,'initiated');
SET orderId=last_insert_id();
OPEN cart_cursor ;
cart_items:LOOP
    FETCH cart_cursor INTO productId,quantity;
    IF noMoreRow=1 THEN 
		LEAVE cart_items;
    END IF;
     INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(orderId,productId,quantity); 
END LOOP cart_items;
DELETE FROM cart_items WHERE cart_id=cartId;
CLOSE cart_cursor;
END $$
DELIMITER ;
-- CALL CreateOrder();