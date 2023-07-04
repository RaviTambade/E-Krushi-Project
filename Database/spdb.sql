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

