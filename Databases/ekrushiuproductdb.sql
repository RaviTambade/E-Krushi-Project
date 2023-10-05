CREATE DATABASE  IF NOT EXISTS `ekrushi` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ekrushi`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: ekrushi
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cartitems`
--

DROP TABLE IF EXISTS `cartitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cartitems` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cartid` int NOT NULL,
  `productdetailsid` int NOT NULL,
  `quantity` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk02` (`cartid`),
  KEY `fkproduct2` (`productdetailsid`),
  CONSTRAINT `fk02` FOREIGN KEY (`cartid`) REFERENCES `carts` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fkproduct2` FOREIGN KEY (`productdetailsid`) REFERENCES `productdetails` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cartitems`
--

LOCK TABLES `cartitems` WRITE;
/*!40000 ALTER TABLE `cartitems` DISABLE KEYS */;
INSERT INTO `cartitems` VALUES (1,1,1,5),(2,1,3,4),(3,1,5,4),(4,1,11,1),(5,2,9,5),(6,2,17,2),(7,2,19,2);
/*!40000 ALTER TABLE `cartitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carts`
--

DROP TABLE IF EXISTS `carts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `carts` (
  `id` int NOT NULL AUTO_INCREMENT,
  `customerid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_1` (`customerid`),
  CONSTRAINT `fk_1` FOREIGN KEY (`customerid`) REFERENCES `userroles` (`userid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carts`
--

LOCK TABLES `carts` WRITE;
/*!40000 ALTER TABLE `carts` DISABLE KEYS */;
INSERT INTO `carts` VALUES (1,2),(2,3);
/*!40000 ALTER TABLE `carts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) DEFAULT NULL,
  `image` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'seeds','/assets/seed.jpeg'),(2,'Agriculture implements','/assets/Agri Equipments.jpeg'),(3,'fertilizers','/assets/fertilizer.jpeg'),(4,'pesticides','/assets/pestisides.jpeg'),(5,'cattel feed','/assets/cattle feed.jpeg');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderdetails`
--

DROP TABLE IF EXISTS `orderdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderdetails` (
  `id` int NOT NULL AUTO_INCREMENT,
  `orderid` int NOT NULL,
  `productdetailsid` int NOT NULL,
  `quantity` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fkorder` (`orderid`),
  KEY `fkproduct` (`productdetailsid`),
  CONSTRAINT `fkorder` FOREIGN KEY (`orderid`) REFERENCES `orders` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fkproduct` FOREIGN KEY (`productdetailsid`) REFERENCES `productdetails` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderdetails`
--

LOCK TABLES `orderdetails` WRITE;
/*!40000 ALTER TABLE `orderdetails` DISABLE KEYS */;
INSERT INTO `orderdetails` VALUES (2,3,50,1),(3,4,3,3),(5,6,3,1),(6,7,5,1),(7,8,29,4),(8,9,62,1),(9,10,42,1),(10,11,87,5),(11,12,74,3),(12,13,6,1),(13,14,47,1),(14,15,3,1),(15,16,27,3),(16,17,6,2),(17,18,36,1),(18,19,33,4),(19,20,40,10),(20,21,51,10),(21,22,66,4),(22,23,58,1);
/*!40000 ALTER TABLE `orderdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `id` int NOT NULL AUTO_INCREMENT,
  `orderdate` datetime NOT NULL,
  `shippeddate` datetime NOT NULL,
  `customerid` int NOT NULL,
  `addressid` int NOT NULL,
  `storeid` int DEFAULT NULL,
  `total` double DEFAULT NULL,
  `status` enum('initiated','approved','inprogress','cancelled','delivered') NOT NULL DEFAULT 'initiated',
  PRIMARY KEY (`id`),
  KEY `fk_storeid` (`storeid`),
  KEY `fk_cust_id_11` (`customerid`),
  CONSTRAINT `fk_cust_id_11` FOREIGN KEY (`customerid`) REFERENCES `userroles` (`userid`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_storeid` FOREIGN KEY (`storeid`) REFERENCES `stores` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (3,' 2023-08-04 08:00:44',' 2023-08-11 08:00:44',3,3,1,650,'initiated'),(4,' 2023-08-04 08:02:03',' 2023-08-11 08:02:03',3,4,1,900,'initiated'),(6,' 2023-08-04 08:30:19',' 2023-08-11 08:30:19',3,9,2,300,'initiated'),(7,' 2023-08-04 08:30:56',' 2023-08-11 08:30:56',3,4,1,2500,'initiated'),(8,' 2023-08-04 08:31:17',' 2023-08-11 08:31:17',3,4,1,1280,'initiated'),(9,' 2023-08-04 08:31:33',' 2023-08-11 08:31:33',3,3,1,1050,'initiated'),(10,' 2023-08-04 08:31:47',' 2023-08-11 08:31:47',3,4,1,600,'initiated'),(11,' 2023-08-04 08:32:30',' 2023-08-11 08:32:30',3,3,1,8000,'initiated'),(12,' 2023-08-04 08:34:47',' 2023-08-11 08:34:47',3,4,1,2100,'initiated'),(13,' 2023-08-04 08:35:06',' 2023-08-11 08:35:06',3,4,1,250,'initiated'),(14,' 2023-08-04 08:40:18',' 2023-08-11 08:40:18',3,4,1,300,'initiated'),(15,' 2023-08-04 08:42:29',' 2023-08-11 08:42:29',2,2,2,300,'initiated'),(16,' 2023-08-04 08:44:17',' 2023-08-11 08:44:17',2,10,2,7500,'initiated'),(17,' 2023-08-04 08:44:37',' 2023-08-11 08:44:37',2,10,2,500,'initiated'),(18,' 2023-08-04 08:44:56',' 2023-08-11 08:44:56',2,10,2,150,'initiated'),(19,' 2023-08-04 08:45:17',' 2023-08-11 08:45:17',2,10,2,1400,'initiated'),(20,' 2023-08-04 08:45:38',' 2023-08-11 08:45:38',2,10,2,7000,'initiated'),(21,' 2023-08-04 08:46:06',' 2023-08-11 08:46:06',2,10,2,65000,'initiated'),(22,' 2023-08-04 08:46:28',' 2023-08-11 08:46:28',2,10,2,1000,'initiated'),(23,' 2023-08-04 08:47:41',' 2023-08-11 08:47:41',2,10,2,250,'initiated');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `mode` enum('cash on delivery','net banking') DEFAULT NULL,
  `paymentstatus` enum('paid','paid','cancelled') DEFAULT NULL,
  `transactionid` int DEFAULT NULL,
  `orderid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fkorderid` (`orderid`),
  CONSTRAINT `fkorderid` FOREIGN KEY (`orderid`) REFERENCES `orders` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` VALUES (1,' 2023-08-04 08:00:44','cash on delivery','paid',NULL,3),(2,' 2023-08-04 08:02:04','net banking','paid',5,4),(4,' 2023-08-04 08:30:21','cash on delivery','paid',NULL,6),(5,' 2023-08-04 08:30:56','cash on delivery','paid',NULL,7),(6,' 2023-08-04 08:31:16','cash on delivery','paid',NULL,8),(7,' 2023-08-04 08:31:33','cash on delivery','paid',NULL,9),(8,' 2023-08-04 08:31:47','cash on delivery','paid',NULL,10),(9,' 2023-08-04 08:32:30','cash on delivery','paid',NULL,11),(10,' 2023-08-04 08:34:46','cash on delivery','paid',NULL,12),(11,' 2023-08-04 08:35:06','cash on delivery','paid',NULL,13),(12,' 2023-08-04 08:40:18','cash on delivery','paid',NULL,14),(13,' 2023-08-04 08:42:29','cash on delivery','paid',NULL,15),(14,' 2023-08-04 08:44:17','cash on delivery','paid',NULL,16),(15,' 2023-08-04 08:44:36','cash on delivery','paid',NULL,17),(16,' 2023-08-04 08:44:56','cash on delivery','paid',NULL,18),(17,' 2023-08-04 08:45:17','cash on delivery','paid',NULL,19),(18,' 2023-08-04 08:45:37','cash on delivery','paid',NULL,20),(19,' 2023-08-04 08:46:06','cash on delivery','paid',NULL,21),(20,' 2023-08-04 08:46:28','cash on delivery','paid',NULL,22),(21,' 2023-08-04 08:47:40','cash on delivery','paid',NULL,23);
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productdetails`
--

DROP TABLE IF EXISTS `productdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productdetails` (
  `id` int NOT NULL AUTO_INCREMENT,
  `productid` int DEFAULT NULL,
  `unitprice` double DEFAULT NULL,
  `stockavailable` int DEFAULT NULL,
  `size` varchar(255) DEFAULT NULL,
  `supplierid` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_supplierid` (`supplierid`),
  KEY `fk_productid` (`productid`),
  CONSTRAINT `fk_productid` FOREIGN KEY (`productid`) REFERENCES `products` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_supplierid` FOREIGN KEY (`supplierid`) REFERENCES `suppliers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=94 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productdetails`
--

LOCK TABLES `productdetails` WRITE;
/*!40000 ALTER TABLE `productdetails` DISABLE KEYS */;
INSERT INTO `productdetails` VALUES (1,1,120,1000,'1kg',1),(2,1,240,1000,'2kg',1),(3,2,300,995,'10kg',1),(4,2,550,1000,'25kg',1),(5,3,2500,999,'1kg',1),(6,4,250,997,'1kg',1),(7,4,500,1000,'2kg',1),(8,5,120,1000,'500gm',1),(9,5,210,1000,'1kg',2),(10,6,450,1000,'1kg',1),(11,6,600,1000,'1.5kg',1),(12,7,220,1000,'1kg',1),(13,7,400,1000,'2kg',1),(14,8,1400,1000,'1kg',1),(15,8,2800,1000,'2kg',1),(16,9,120,1000,'1kg',1),(17,9,240,1000,'2kg',1),(18,10,1200,1000,'1kg',1),(19,10,2400,1000,'2kg',1),(20,11,250,999,'S',1),(21,12,400,1000,'S',1),(22,12,800,1000,'M',1),(23,13,1050,1000,'10m',1),(24,13,2000,1000,'20m',1),(25,14,3000,1000,'16L',1),(26,14,4000,1000,'20L',1),(27,15,2500,997,'10m',2),(28,15,5000,1000,'25m',2),(29,16,320,996,'15m',2),(30,16,600,1000,'30m',2),(31,17,2500,1000,'L',2),(32,18,250,1000,'S',2),(33,18,350,996,'M',2),(34,19,1610,1000,'S',1),(35,20,400,1000,'S',1),(36,21,150,999,'25kg',2),(37,21,270,1000,'50kg',2),(38,22,250,1000,'25kg',2),(39,22,500,1000,'50kg',2),(40,23,700,990,'25kg',2),(41,23,1400,1000,'25kg',2),(42,24,600,999,'25kg',2),(43,24,1200,1000,'50kg',2),(44,25,550,1000,'25kg',2),(45,25,1150,1000,'50kg',1),(46,26,150,1000,'1kg',1),(47,27,300,999,'2kg',1),(48,28,750,1000,'10kg',2),(49,28,1400,1000,'50kg',2),(50,29,650,998,'5kg',1),(51,29,6500,990,'50kg',1),(52,30,600,1000,'25kg',2),(53,30,1150,1000,'50kg',1),(54,31,240,1000,'100ml',1),(55,31,500,1000,'250ml',1),(56,32,120,1000,'100ml',1),(57,32,220,1000,'220ml',1),(58,33,250,999,'100gm',1),(59,33,325,1000,'250gm',1),(60,34,120,1000,'100gm',1),(61,34,240,1000,'200gm',1),(62,35,1050,999,'25ml',1),(63,35,1600,1000,'50ml',1),(64,36,120,1000,'100gm',1),(65,36,200,1000,'200gm',1),(66,37,250,996,'100gm',2),(67,37,500,1000,'250gm',2),(68,38,320,1000,'150ml',2),(69,38,150,1000,'75ml',2),(70,39,250,1000,'100ml',2),(71,39,300,1000,'150ml',2),(72,40,300,1000,'150ml',2),(73,40,600,1000,'250ml',2),(74,41,700,997,'25kg',2),(75,41,1700,1000,'50kg',2),(76,42,800,1000,'25kg',1),(77,42,1610,1000,'50kg',1),(78,43,700,1000,'25kg',1),(79,43,1400,1000,'50kg',1),(80,44,800,1000,'25kg',1),(81,44,1600,1000,'50kg',1),(82,45,850,1000,'25kg',2),(83,45,1700,1000,'50kg',2),(84,46,1200,1000,'25kg',1),(85,46,2400,1000,'50kg',1),(86,47,800,1000,'25kg',1),(87,47,1600,995,'50kg',1),(88,48,1000,1000,'25kg',2),(89,48,2000,1000,'50kg',2),(90,49,700,1000,'25kg',2),(91,49,1400,1000,'50kg',2),(92,50,900,1000,'25kg',2),(93,50,1800,1000,'50kg',2);
/*!40000 ALTER TABLE `productdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productreview`
--

DROP TABLE IF EXISTS `productreview`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productreview` (
  `id` int NOT NULL AUTO_INCREMENT,
  `productid` int DEFAULT NULL,
  `customerid` int DEFAULT NULL,
  `rating` double DEFAULT NULL,
  `review` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `productid` (`productid`,`customerid`),
  KEY `fk_customeruser` (`customerid`),
  CONSTRAINT `fk_customeruser` FOREIGN KEY (`customerid`) REFERENCES `userroles` (`userid`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_productid2` FOREIGN KEY (`productid`) REFERENCES `products` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productreview`
--

LOCK TABLES `productreview` WRITE;
/*!40000 ALTER TABLE `productreview` DISABLE KEYS */;
INSERT INTO `productreview` VALUES (1,1,2,4.5,'Nice Product'),(2,1,3,2,'Nice Product'),(3,2,2,3,'Nice Product'),(4,2,3,4,'Nice Product'),(5,3,2,4.5,'Nice Product'),(6,3,3,3.5,'Nice Product'),(7,4,2,2.5,'Nice Product'),(8,4,3,4,'Nice Product'),(9,5,2,5,'Nice Product'),(10,5,3,4,'Nice Product'),(11,6,2,2,'Nice Product'),(12,6,3,2,'Nice Product'),(13,7,2,4.5,'Nice Product'),(14,7,3,5,'Nice Product'),(15,8,2,1,'Nice Product'),(16,8,3,4,'Nice Product'),(17,9,2,4,'Nice Product'),(18,9,3,4,'Nice Product'),(19,10,2,3,'Nice Product'),(20,10,3,3.5,'Nice Product'),(21,11,2,2.5,'Nice Product'),(22,11,3,1.5,'Nice Product'),(23,12,2,2.5,'Nice Product'),(24,12,3,3.5,'Nice Product'),(25,13,2,4.5,'Nice Product'),(26,13,3,5,'Nice Product'),(27,14,2,4,'Nice Product'),(28,14,3,4,'Nice Product'),(29,15,2,3,'Nice Product'),(30,15,3,4.5,'Nice Product'),(31,16,2,3.5,'Nice Product'),(32,16,3,3.5,'Nice Product'),(33,17,2,1.5,'Nice Product'),(34,17,3,4,'Nice Product'),(35,18,2,4,'Nice Product'),(36,18,3,4.5,'Nice Product'),(37,19,2,1.5,'Nice Product'),(38,19,3,2.5,'Nice Product'),(39,20,2,2.5,'Nice Product'),(40,20,3,3.5,'Nice Product'),(41,21,2,4.5,'Nice Product'),(42,21,3,4.5,'Nice Product'),(43,22,2,3,'Average quality'),(44,22,3,4,'Better than expected'),(45,23,2,5,'Excellent product!'),(46,23,3,4.5,'Very satisfied'),(47,24,2,3.5,'Decent quality, but could be better'),(48,24,3,4,'Satisfactory purchase'),(49,25,2,2.5,'Not very pleased with the product'),(50,25,3,3,'Could be improved'),(51,26,2,4,'Good quality product'),(52,26,3,4.5,'Satisfied with the purchase'),(53,27,2,3.5,'Decent product for the price'),(54,27,3,4,'Met my expectations'),(55,28,2,4,'Above-average quality'),(56,28,3,3.5,'Fair purchase'),(57,29,2,2,'Not as expected'),(58,29,3,2.5,'Could be improved'),(59,30,2,4.5,'Outstanding quality!'),(60,30,3,5,'Impressed with the product'),(61,31,2,3,'Average product'),(62,31,3,3.5,'Met my basic requirements'),(63,32,2,4,'Good value for money'),(64,32,3,4.5,'Satisfied with the purchase'),(65,33,2,3,'Average product'),(66,33,3,3.5,'Met my basic requirements'),(67,34,2,4,'Good value for money'),(68,34,3,4.5,'Satisfied with the purchase'),(69,35,2,2.5,'Below expectations'),(70,35,3,3,'Could be improved'),(71,36,2,4,'Good quality product'),(72,36,3,4.5,'Satisfied with the purchase'),(73,37,2,3.5,'Decent product for the price'),(74,37,3,4,'Met my expectations'),(75,38,2,2,'Not as expected'),(76,38,3,2.5,'Could be improved'),(77,39,2,4.5,'Outstanding quality!'),(78,39,3,5,'Impressed with the product'),(79,40,2,3,'Average product'),(80,40,3,3.5,'Met my basic requirements'),(81,41,2,4,'Good value for money'),(82,41,3,4.5,'Satisfied with the purchase'),(83,42,2,2.5,'Below expectations'),(84,42,3,3,'Could be improved'),(85,43,2,4,'Good quality product'),(86,43,3,4.5,'Satisfied with the purchase'),(87,44,2,3.5,'Decent product for the price'),(88,44,3,4,'Met my expectations'),(89,45,2,2,'Not as expected'),(90,45,3,2.5,'Could be improved'),(91,46,2,4.5,'Outstanding quality!'),(92,46,3,5,'Impressed with the product'),(93,47,2,3,'Average product'),(94,47,3,3.5,'Met my basic requirements'),(95,48,2,4,'Good value for money'),(96,48,3,4.5,'Satisfied with the purchase'),(97,49,2,2.5,'Below expectations'),(98,49,3,3,'Could be improved'),(99,50,2,4,'Good quality product'),(100,50,3,4.5,'Satisfied with the purchase');
/*!40000 ALTER TABLE `productreview` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) DEFAULT NULL,
  `description` varchar(2000) DEFAULT NULL,
  `image` varchar(255) DEFAULT NULL,
  `categoryid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fkcategoryid` (`categoryid`),
  CONSTRAINT `fkcategoryid` FOREIGN KEY (`categoryid`) REFERENCES `categories` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'oats seeds','For healthier and nutritiously growing food preferences, Oats are largely recommended by the topmost dieticians and nutritionists. Oats are the quintessential healthy food and make for an excellent and highly nutritious meal or even a snack. Being considered a superfood with an abundance of dietary fibres, beta-glucan, and several essential nutrients, Oats have become an everyday partner of every health-conscious individual. However, not everyone is familiar with the different kinds of Oats, having different generics, available in the market. Goodness and Wellness are the two common essences amongst all the different oats varieties. Let’s have a better understanding of the different types of oats, their key features, and nutrition components.','/assets/oat.jfif',1),(2,'wheat seeds','Wheat is the second most important staple food after rice consumed by 65% of the population in India and is likely to increase further due to changes in food habits. Wheat is mostly consumed in the form of ‘chapati’ in our country for which bread wheat is cultivated in nearly 95 per cent of the cropped area. ','/assets/wheat.jpg',1),(3,'corn seeds','Corn is one of the world’s most productive and dominant crops. It is grown extensively as food for both humans and livestock, as a biofuel, and as a crude material in industry. Corn is the third largest plant-based food source in the world.','/assets/corn.jfif',1),(4,'cluster Beans','Cluster beans, or Guar beans or Gawar beans, are annual legumes. They are a popular veggie in India. Cluster beans, also known as Cyamopsis tetragonoloba, are a member of the Fabaceae family. Plants like guar legumes live in symbiosis with nitrogen-fixing bacteria of the soil. This symbiotic action makes guar crucial in crop rotation cycles and replenishes the soil with essential nutrients for the next crop.','/assets/clusterbeans.jpeg',1),(5,'okra seeds','Product Description Number of seeds: 30 Seeds: Okra - Lady Finger Variety: Export Quality Seeds Germination: Min. 70% Plant to plant spacing: 20 cm Sunlight: Prefer Full Ease-of-care: Easy Best if grown directly from seeds Perfect for Indian climate; can be grown at Home in Pots and Gardens. Soil Preparation: Vegetable grows well in any fast-draining garden loam. It thrives in soils with a lot of organic matter, as long as they’re not too acidic. Incorporate 3” (8 cm) of good garden compost or well-aged manure into the bed at planting time. A slightly more alkaline soil than most vegetables (pH 6.5-7.5). Adaptability of this variety: Areas: State of Andhra Pradesh, Karnataka, TN, Kerala, MP, Maharastra, UP, Uttaranchal, Bihar, Jharkand, Haryana, Punjab, Delhi, Rajasthan, West Bengal, Chhatisgarh and North eastern states.','/assets/okra.webp',1),(6,'sunflower seeds','Sunflower Seeds is the perfect choice of Farmers for quality output. It requires around 4 kilograms of seeds to cultivate in one acre. Approximately yield of 5-6 quintals from one acre of Sunflower field. All the details above depends on the Fertility of Soil, Amount and duration of Water and pre-treatment of seeds before sowing. Also Climate is huge factor in quantity and quality of Every Yeild, Presoaking for 6-8 hours of Seeds before sowing is must. This enable to softening of thick outer shell for easy Germination.','/assets/sunflower.webp',1),(7,'pumpkin seeds','Pumpkin seeds are rich in vitamins and minerals like manganese and vitamin K, both of which are important in helping wounds heal. They also contain zinc, a mineral that helps the immune system fight bacteria and viruses. Pumpkin seeds are also an excellent source of: Phosphorus.','/assets/pumpkin.jpeg',1),(8,' Rice Paddy Seeds','VISION CRAFTED Rice Paddy Seed for Sowing - Basmati seeds for farming | Basmati seeds for cultivation -1121 Variety (1 KG, Basmati 1121) Pusa Basmati 1121 is the first early maturing Basmati rice variety with seed to seed maturity of only 145 days and average yield of 4.5 to 5 tonne/ hectare. Pusa Basmati 1121 is a semi-dwarf (110-120 cm).Basmati rice variety with sturdy stem and plant height ranging from 110 - 120 cm. It takes140-145 days','/assets/ricepaddyseed.webp',1),(9,' Bajra Seeds',' Its annual seed bajra when compared to fodder bajra will re-grow after each harvest (multi-cut), fast-growing cover crop with an extensive root system and heat-loving summer annual grass. It can grow 7-11 feet tall with long depending upon soil conditions, low water requirement, drought tolerance, slender leaves and no leaf blades. The leaves are similar to corn/maize but are shorter and sometimes wider. Fodder quality will be high due to low fibre content if cut frequently. Seed rate is 9-10 kg/acre, good seed germination like above 95 %; spacing is 0.5x1 feet for single seeds sow. Irrigation is 7–9 days depending upon soil conditions and suitable for anywhere climatic conditions in India. Give irrigation immediately after sowing and life/second irrigation on 3rd day from date of sowing then irrigate once in 10 days. Conduct on first harvest 60th days after sowing, then subsequent harvest 30-35 days once. It’s having 8.93-11.5 % of Crude Protein and Fat contains 4.81 %. Green fodder yield is 27-30 t/acre/yr. Used primarily for pastures, grazing, green chop, silage and hay. Good green fodder to Cow, Buffalo, Goat and Sheep. Improving milk yield and body weight also.','/assets/bajra-seeds.webp',1),(10,' Muli Seeds',' Long Radish Seeds for Home Garden | Farming | Vegetable | Hybrid | Kitchen | Planting | Terrace | Balcony | Eating | Mula | Mulia | Mooli | Muli | Mullangi | White Mooli - 10 Gram : 834 Seed How fast do radishes grow from a seed? : Plant radishes from seeds in early spring, four to six weeks before the average date of your last spring frost. In fall, plant four to six weeks before the first expected fall frost. Radish seedlings usually take three to four days to sprout, but some varieties take a few weeks. What time of year do you plant radishes? : Radishes do best when grown in cooler conditions, and are tolerant of cold weather. Loosen soil before planting at least six inches deep, a foot or more for long types. Plant seeds from April through early May, and again in August. Are radishes easy to grow? : Radishes are quick, easy and fun to grow from seed, ready to eat in as little as four weeks. These compact plants can be grown in even the smallest of gardens and are great gap-fillers on the veg plot. Sow small batches every few weeks for harvesting throughout summer, to add a crunchy tang to your salads. Best Suitable for Terrace Gardening, Grow bag cultivation, Kitchen Gardening, Terrace Gardening & Roof Top Balcony Gardening. Organic Vegetable seeds, Best for planting throughout the year. Best in class germination, Suitable for all Seasons, Fresh Seeds. Easy to Grow - Can be grown in indian climate/weather conditions. Do not use for food, feed, or oil purposes, Seeds are only for Gardening Purpose. Very showy High Impact Bedding all season Vegetables for all beautiful gardens and landscape to keep your garden noticed by all.High Quality Seeds with Germination rate of above 90%.','/assets/muli.webp',1),(11,'Hand Sprayer','User instruction: Pour  fluid into the Garden sprayer and with the help of air compressor, pump-in until the pressure fills and then adjust the nozzle for either fine mist or for pressure jet. This sprayer has dual flow i.e Mist flow and Pressure Jet flow and the sprayer has a capacity of 2 litres. Can be used for multiple purposes. . This lawn sprayer is not suitable for corrosive or acidic solutions. Adjustable brass nozzle. . The high-quality brass nozzle can adjust the intensity of the water spray from direct injection to fine mist spray. An arthritis-friendly easy grip handle, efficient pump and trigger lock make continuous spraying less straining Spray plants and more - plants need fertilizer, pesticides, insecticides and even neem oil, and of course water.','/assets/handsprayer.jpg',2),(12,'Garden Scissors','Garden Sharp Cutter Pruners Scissor with grip-handle This reliable tree Pruner is ideal for all varieties of general pruning tasks. Its cutting ability is stronger than ordinary pruning shears. Be a good partner for your garden work. Sharp and reliable can easily for most of the lightweight pruning work, also can help your to do some heavy duty for less than 3/4\"\" diameter size tree branches. ERGONOMIC DESIGN Lightweight metal ergonomic handles with rubber cushioning for a comfortable yet solid grasp. Features: 1.Premium durable, sharp & reliable bypass pruning shear is a must-have for any gardener! 2.Material: stainless steel (handle material pp plastic); 3.Prune your favorite plants, flowers, bushes and hedges with ease - smoothly cut through stems, branches, roots, vines and more. Our blade use non-stick coating for rust resistant, lower friction when cutting and prevent the blade gumming up with sap or debris. 4.The forged stainless steel handles of the pruning shear are ergonomically designed to always be comfortable, even after long hours in the garden. Handles feature a non-slip rubber grip as well as an easy-to-use security lock. 5.Long-lasting, Dependable and Reliable','/assets/gardenscissors.webp',2),(13,'Hose pipe',' PVC HOSE PIPES, Used For Gardening , Car Washing , Bike Washing , Pet Bath , Floor Clean , Construction , Agricultural, Sprinkling , ETC. Our Long Lasting Hose Pipes Are Made With Premium And High-Quality PVC & Abrasion Resistant Materials And Are Designed For Both Hot And Cold Conditions. Our Hose Pipes Comes With Accessories To Make Them User Friendly And For Perfect Gardening Experience. Made With ?? In INDIA','/assets/Hosepipe.jpeg',2),(14,'Balwan Battery Sprayer ','You can use the Balwaan Battery sprayer for agriculture, sanitizer, chemicals, farming, gardening, and many more purposes. This sprayer pump is 12 volt 8 ampere. It will get fully charged in 3-4 Hours. With a fully charged battery, you can use this 18-litre tank 15-20 times. We give our customers the best quality pump. No manual efforts are required to create pressure. Continuous & Mist spray. This sprayer has multiple applications and is widely used in agriculture, horticulture, sericulture, plantations, forestry, and gardens. Note - Damage parts not covered in the warranty','/assets/batterysprayer.webp',2),(15,'Mulch Film ','Blocks sunlight and prevent weed seed germination without chemicals Protect soil from water loss due to evaporation. Good for water conservation Increases crop yield due to low pest attack Material : LLDPE Plastic. Quality : 30 Micron, Usage: Weed Prevention','/assets/mulch-film.jpg',2),(16,'ShedNet ','This 75 % UV stabilization protect to direct sun rays. longer life durability. Sun protection and dust protection netting material usable: - usable in garden and farm plants for UV sun protection. Usable in window, gallery and balcony cover. usable for car cover for dust protection and sun protection. usable industrial machinary covers. Usable for stop working construction part. Usable for home roof shade to protect sun rays. Usable for indoor outdoor curtain. item color is green but can be changed normally light green or dark green.','/assets/shednet.webp',2),(17,'Pickaxe ','Strong Wooden Handle Made for rough use and long lasting Alloy Steel, Hardened and Tempered Ideal for Digging','/assets/pickaxe.jpg',2),(18,'Weeding Hook ','This Agricultural and Gardening crop cutting tool is specially designed to remove weed and grass. An excellent product with sharp zigzag teeth For smooth Cutting Performance.','/assets/weedinghook.jpg',2),(19,'Axe ','ERGONOMIC DESIGN: Our Hatched is Designed with a Shock Absorbing Anti Slip Grip, Cold Resistant Ergonomic Shaped Fiberglass Handle which will reduce the strain on your hand, resists slipping and adds comfort.\r\nEASY STORAGE: The head comes with a Rubber Protective Sheath for safe storage and transport. After use, simply apply the rubber protective cover and hang the Hatchet from the hole that is featured for easy and convenient storage.\r\nDURABLE CONSTRUCTION: The Forged Carbon Steel Heat Treated head which improves its density and makes the axe more durable produces smooth and quick splits and stays sharp longer than traditional axes. You can count on this Hand Axe to deliver superior, long lasting performance.','/assets/axe.jpg',2),(20,'Favda ','Agriculture Tool Primarily Used for Digging.\r\nIt Contain a Blade Attached with a Long Handle.\r\nThe Handle is Very Strong & Spade were Made with Sharper Tips of Metal.\r\nHeavy Duty Gardening Spade with Strong Wooden Handle Suitable for digging, balancing, forming hard/raw ground soil\r\nlike as a kassi fawda khurpi spade or hor shovel','/assets/favda.jpg',2),(21,'Urea','Urea is the chief nitrogenous end product of the metabolic breakdown of proteins in all mammals and some fishes. It occurs not only in the urine of mammals but also in their blood, bile, milk, and perspiration.','/assets/UREA.png',3),(22,'12-32-16','This is one of the highest nutrients containing NPK complex fertiliser with total nutrients of 60%\r\nNitrogen and Phosphate are available in the ratio 1:2.6 as in the case of DAP, but in Mahadhan 12:32:16 also contains 16% Potash additionally\r\nMahadhan 12:32:16 helps the young plants to grow faster, even under adverse soil or climatic condition','/assets/12-32-16.jpeg',3),(23,'10-26-26','Improves nutrient availability & reduce nutrient loss.\r\nIt increases crop yield by 10% to 15%.\r\nIncreases CEC and nutrient holding capacity of soil.\r\nRich in organic carbon and mineral substances essential to plant growth\r\nRetains water soluble fertilisers and releases in root zones as needed\r\nIncreases plant uptake of nutrients\r\n','/assets/10-26-26.jpeg',3),(24,'Diammonium Phosphate (DAP)','Diammonium phosphate contains nitrogen and phosphorus, making it suitable for a wide range of crops. It promotes healthy plant growth.','/assets/dap.jpeg',3),(25,'Potassium Sulfate','Potassium sulfate contains potassium and sulfur, benefiting fruits and vegetables. It improves overall plant health and yield.','/assets/potassiumsulphate.jpeg',3),(26,'Iron Chelates','Iron chelates are used to correct iron deficiencies in plants, particularly in alkaline soils. They enhance chlorophyll production.','/assets/chelatediron.jpeg',3),(27,'Zinc Sulfate','Zinc sulfate provides essential zinc for plant health and development. It is crucial for various enzymatic processes.','/assets/zincsulphate.jpeg',3),(28,'Calcium Nitrate','Calcium nitrate provides calcium and nitrogen, benefiting fruiting crops and overall plant health.','/assets/calciumnitrate.jpeg',3),(29,'Boron Fertilizer','Boron fertilizer is used to prevent boron deficiency in crops like broccoli and cauliflower.','/assets/boron.jpeg',3),(30,'Liquid Seaweed Fertilizer','Liquid seaweed fertilizer contains trace elements and growth-promoting hormones, suitable for a variety of crops.','/assets/ls.jpeg',3),(31,'Admire','Admire contains Imidacloprid, one of the world best selling insecticides. It is a systemic insecticide belonging to the chemical class of neonicotinoids and is very effective against various insect pests','/assets/mira.webp',4),(32,'Rogor','It can be applied by mixing 1-2 ml with a liter of water and spraying over the concerned plants.\r\nRogor Is 30% EC Formulation Of Dimethoate\r\nIt Is Highly Effective In Controlling The Sucking And Caterpillar Pests\r\nIt Is highly Compatible With Other Insecticides And Fungicides','/assets/Rogor.jpeg',4),(33,'Antracol','Antracol contains Propineb, a contact fungicide with broad spectrum activity against various diseases of rice, chilli, grapes, potato and other vegetables and fruits. Propineb is a polymeric zinc-containing dithiocarbamate. Due to the release of zinc, the application of Antracol results in greening effect on the crop and subsequent improvement in quality of produce.','/assets/antracol.jpeg',4),(34,'Avatar','Avtar is a Broad-spectrum fungicide, which controls large number of diseases with its multisite and systemic action. Avatar is an effective fungicide that is useful for all crops and vegetables.','/assets/Avtar.jpeg',4),(35,'coragen','\r\nCoragen® insecticide is an anthranilic diamide Broad Spectrum insecticide in the form of a suspension concentrate.\r\nCoragen® insecticide is particularly active on Lepidopteran insect pests, primarily as a larvicide.\r\nCoragen® insecticide is powered by active ingredient Rynaxypyr® active which has a unique mode of action that controls pests resistant to other insecticides.\r\nCoragen® insecticide is selective & safe for non-target arthropods and conserves natural parasitoids, predators and pollinators.','/assets/coragen.jpeg',4),(36,'Zyme','V-Zyme Sport is specially designed for turf , its a unique formulation of micronutrients with amino acid, growth-supporting co-factors and biostimulator, consisting of various minerals suspended in amino acids.\r\nThe micronutrients are used in such a peculiar form that ensures the bioavailability of these micronutrients to the maximum extent. Such bioavailability of these micronutrients is rarely seen in any other products available in the market.','/assets/zyme.jpeg',4),(37,'Melody','Melody Duo is a modern fungicide containing the two active ingredients Iprovalicarb and Propineb.','/assets/Melody.jpeg',4),(38,'Goal','Goal® contains oxyfluorfen as active ingredient which belongs to diphenyl ether.\r\nAs pre-emergence, Goal® forms a chemical barrier on the soil surface and affects weed plants through direct contact at emergence.\r\nActively growing plants are very susceptible to Goal® as post-emergence action','/assets/Goal.jpeg',4),(39,'Targa-super','Targa Super is selective, systemic herbicide of Aryloxyphenoxy-propionates group. It is used to control narrow leaf weeds in broad leaf crops.','/assets/targa-super.png',4),(40,'Profex','Profex Super can be used for lerva type insect killing. It can be used for all types of vegetables, fruits, and flowers. Also, use for home garden plants excellent result.','/assets/profex.jpeg',4),(41,'Sarki pend','Perfect mixture\r\nQuality examined\r\nCompletely organic\r\nLower price\r\nFree from damage by water','/assets/sarki pend.jpeg',5),(42,'Kandi','This useful to cow, Goat, buffawlo. This is one of the most important feed for animal','/assets/kandi.jpeg',5),(43,'Bhusa','This useful to cow, Goat, buffawlo. This is one of the most important feed for animal','/assets/bhusa.jpeg',5),(44,'Milkgen','Form: 3mm roasted pellets\r\nCrude protein: 24%* (min)\r\nCrude fat: 4%* (min)\r\nCrude fiber: 10%* (max)\r\nMoisture: 11%* (max)','/assets/milkgen10000.png',5),(45,'Pragati','Dairy Gold is a balanced source of essential nutrients required for body maintenance, growth and milk production. It is manufactured using good quality grains, oil cakes/ meals, brans, molasses, com- mon salt, minerals and vitamins. It is comparatively cheaper and highly palatable to the animals.','/assets/Pragati.png',5),(46,'Buffgen4000','Form: 3mm roasted pellets\r\nCrude protein: 22%* (min)\r\nCrude fat: 5%* (min)\r\nCrude fiber: 12%* (max)\r\nMoisture: 11%* (max)\r\n','/assets/buffgen.png',5),(47,'Dairy Gold','Dairy Gold is a balanced source of essential nutrients required for body maintenance, growth and milk production. It is manufactured using good quality grains, oil cakes/ meals, brans, molasses, com- mon salt, minerals and vitamins. It is comparatively cheaper and highly palatable to the animals.','/assets/dairygold.webp',5),(48,'Kapila Dairy Special','Contains By Pass Protein & Fat to increase the absorption of fats & protein.\r\nContains 3.5% Fat, 25-28% Crude Protein and other minerals.\r\nKapila Dairy Special (By Pass) is beneficial for cows of foreign breed.\r\nRecommended for any dairy breed of average weight yielding large quantity of milk.','/assets/dairy-special-small.jpg',5),(49,'Amul Nutri Rich','Amul Nutri Rich, Cattle Feed - Bis Type-1, 50 Kg Bag is a feed that is rich in protein and minerals. It is specially designed for cows that are pregnant or lactating. The cows will produce milk and their offspring will be healthier. The cows will also be able to produce more milk for longer periods of time. Bis Type-1 is a quality cattle feed that has been developed to provide optimum nutrition for dairy cattle. The ingredients in this feed are carefully selected to promote rapid growth and healthy conditions for the animals. The result is a product that not only improves the animals quality of life, but also the quality of the milk and dairy products that are produced.','/assets/nutririch.webp',5),(50,'KAPILA HI PRO','A feed that has just right amount of protein (24%) and fat (4%), Manufactured under International Organisation Standards. It is made of completely natural products that will help your cattle to give milk to its full potential and remain healthy for longer period of time.','/assets/hi-pro.jpg',5);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Shop owner'),(2,'Customer'),(3,'Supplier'),(4,'Shipper'),(5,'SubjectMatterExpert');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shippers`
--

DROP TABLE IF EXISTS `shippers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shippers` (
  `id` int NOT NULL AUTO_INCREMENT,
  `corporateid` int NOT NULL,
  `userid` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `corporateid` (`corporateid`),
  KEY `fk_shipperuser` (`userid`),
  CONSTRAINT `fk_shipperuser` FOREIGN KEY (`userid`) REFERENCES `userroles` (`userid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shippers`
--

LOCK TABLES `shippers` WRITE;
/*!40000 ALTER TABLE `shippers` DISABLE KEYS */;
/*!40000 ALTER TABLE `shippers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stores`
--

DROP TABLE IF EXISTS `stores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stores` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `userid` int NOT NULL,
  `addressid` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_storeuser` (`userid`),
  CONSTRAINT `fk_storeuser` FOREIGN KEY (`userid`) REFERENCES `userroles` (`userid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stores`
--

LOCK TABLES `stores` WRITE;
/*!40000 ALTER TABLE `stores` DISABLE KEYS */;
INSERT INTO `stores` VALUES (1,'store 1',1,1),(2,'store 2',4,5);
/*!40000 ALTER TABLE `stores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subjectmatterexperts`
--

DROP TABLE IF EXISTS `subjectmatterexperts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subjectmatterexperts` (
  `id` int NOT NULL AUTO_INCREMENT,
  `expertise` varchar(40) DEFAULT NULL,
  `userid` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `userid` (`userid`),
  CONSTRAINT `fk_smeuser` FOREIGN KEY (`userid`) REFERENCES `userroles` (`userid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subjectmatterexperts`
--

LOCK TABLES `subjectmatterexperts` WRITE;
/*!40000 ALTER TABLE `subjectmatterexperts` DISABLE KEYS */;
INSERT INTO `subjectmatterexperts` VALUES (1,'crop related information',8),(2,'soil related information',9);
/*!40000 ALTER TABLE `subjectmatterexperts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliers` (
  `id` int NOT NULL AUTO_INCREMENT,
  `corporateid` int NOT NULL,
  `userid` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `corporateid` (`corporateid`),
  KEY `fk_supplieruser` (`userid`),
  CONSTRAINT `fk_supplieruser` FOREIGN KEY (`userid`) REFERENCES `userroles` (`userid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,8,11),(2,9,12);
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroles`
--

DROP TABLE IF EXISTS `userroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userroles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid` int NOT NULL,
  `roleid` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `userid` (`userid`),
  KEY `fkroleid` (`roleid`),
  CONSTRAINT `fkroleid` FOREIGN KEY (`roleid`) REFERENCES `roles` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES (1,1,1),(2,4,1),(3,2,2),(4,3,2),(5,11,3),(6,12,3),(7,6,4),(8,7,4),(9,8,5),(10,9,5);
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'ekrushi'
--
/*!50003 DROP PROCEDURE IF EXISTS `insertpayment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_unicode_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'IGNORE_SPACE,STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertpayment`(

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
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZON 2023-08TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on   2023-08-04  9:13:02
