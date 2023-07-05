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
DECLARE cart_cursor CURSOR  FOR SELECT cartitems.productid,cartitems.quantity FROM cartitems WHERE cartid=cartId; 
DECLARE CONTINUE HANDLER FOR NOT FOUND SET noMoreRow = 1;
SELECT carts.custid INTO custId FROM carts WHERE id=cartId;
INSERT INTO orders (orderdate,shippeddate, custid,total,status) VALUES (now(),now(),custId,0,'initiated');
SET orderId=last_insert_id();
OPEN cart_cursor ;
cartitems:LOOP
    FETCH cart_cursor INTO productId,quantity;
    IF noMoreRow=1 THEN 
		LEAVE cartitems;
    END IF;
     INSERT INTO orderdetails(orderid, productid, quantity)VALUES(orderId,productId,quantity); 
END LOOP cartitems;
DELETE FROM cartitems WHERE cartitems.cartid=cartId;
CLOSE cart_cursor;
END $$
DELIMITER ;

