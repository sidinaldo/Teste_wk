-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: db_wk
-- ------------------------------------------------------
-- Server version	8.0.23

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
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `Id` char(36) NOT NULL,
  `Name` varchar(250) NOT NULL,
  `Active` tinyint(1) NOT NULL,
  `CategoryId` char(36) NOT NULL,
  `Description` varchar(500) NOT NULL,
  `Image` longtext,
  `DataRegistration` datetime NOT NULL,
  `ProductValue` decimal(65,30) NOT NULL,
  `Quantity` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `prod_cat_fk_idx` (`CategoryId`),
  CONSTRAINT `prod_cat_fk` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('4bc6e8ea-dba5-11ec-9b70-00ffd46fe11d','Pneu Bridgestone T',1,'1c73439b-dba4-11ec-9b70-00ffd46fe11d','Pneu Bridgestone Aro 16 185/55R16 83V','pneu.jpg','2022-05-24 18:05:52',542.900000000000000000000000000000,46),('6e005fb3-dba5-11ec-9b70-00ffd46fe11d','Cadeirinha Tour 9',1,'1c7867ac-dba4-11ec-9b70-00ffd46fe11d','Cadeirinha Tour 9 a 36 Kg Cosco - Cinza  e Rosa','cadeirinha.png','2022-05-24 18:06:50',43.000000000000000000000000000000,4),('6ecd29b5-dba5-11ec-9b70-00ffd46fe11d','Limpa e Hidrata',1,'1c73439b-dba4-11ec-9b70-00ffd46fe11d','Limpa e Hidrata Couro Proauto','indratente.png','2022-05-24 18:06:51',45.000000000000000000000000000000,56),('6f3e1c76-dba5-11ec-9b70-00ffd46fe11d','Limpa Parabrisas Rodabrill',1,'1c73439b-dba4-11ec-9b70-00ffd46fe11d','Limpa Parabrisas Rodabrill','limpa_parabrisa.jpg','2022-05-24 18:06:52',675.000000000000000000000000000000,3),('6f625cd3-dba5-11ec-9b70-00ffd46fe11d','Bateria Moura Selada Vrla',1,'1c77ae81-dba4-11ec-9b70-00ffd46fe11d','Bateria Moura Selada Vrla 12V 7Ah Estacionaria 12M','bateria.png','2022-05-24 18:06:52',45.000000000000000000000000000000,4),('6f7f25b8-dba5-11ec-9b70-00ffd46fe11d','Relógio com GPS',1,'1c73439b-dba4-11ec-9b70-00ffd46fe11d','Relógio com GPS e Frequência Cardíaca no Pulso','relogio.jpg','2022-05-24 18:06:52',23.000000000000000000000000000000,78),('6f96d00c-dba5-11ec-9b70-00ffd46fe11d','Bicicleta Ergométrica BP',1,'1c73439b-dba4-11ec-9b70-00ffd46fe11d','Bicicleta Ergométrica BP-880, Polimet, Preto','ergonomica.jpg','2022-05-24 18:06:52',12.000000000000000000000000000000,9),('6fb43212-dba5-11ec-9b70-00ffd46fe11d','Colchonete de Espuma ',1,'1c73439b-dba4-11ec-9b70-00ffd46fe11d','Colchonete de Espuma D18 95cm x 55cm x 3cm','cochonete.jpg','2022-05-24 18:06:53',54.000000000000000000000000000000,12),('6fcbe592-dba5-11ec-9b70-00ffd46fe11d','GPS Portátil Garmin eTrex',1,'1c73439b-dba4-11ec-9b70-00ffd46fe11d','GPS Portátil Garmin eTrex 10 Amarelo','gps.jpg','2022-05-24 18:06:53',67.000000000000000000000000000000,21),('6fe85cab-dba5-11ec-9b70-00ffd46fe11d','Cama Elástica 1,40m',1,'1c73439b-dba4-11ec-9b70-00ffd46fe11d','Cama Elástica 1,40m Henri Trampolim Linha Kids Preta','cama-elastica.jpg','2022-05-24 18:06:53',98.000000000000000000000000000000,3),('7001b519-dba5-11ec-9b70-00ffd46fe11d','Leite Condensado',1,'1c76d5ad-dba4-11ec-9b70-00ffd46fe11d','Leite Condensado, Moça Lata, 395g','leitemoca.webp','2022-05-24 18:06:53',76.000000000000000000000000000000,6),('701e1f51-dba5-11ec-9b70-00ffd46fe11d','Cereal Matinal, Snow',1,'1c76d5ad-dba4-11ec-9b70-00ffd46fe11d','Cereal Matinal, Snow Flakes, 620gCereal Matinal','cereal.jpg','2022-05-24 18:06:53',567.000000000000000000000000000000,8),('70392ab8-dba5-11ec-9b70-00ffd46fe11d','Whisky Singleton',1,'1c76d5ad-dba4-11ec-9b70-00ffd46fe11d','Whisky Singleton Of Dufftown 12 Anos, 750ml','wisk.jfif','2022-05-24 18:06:54',87.000000000000000000000000000000,9),('7055a248-dba5-11ec-9b70-00ffd46fe11d','Whisky Jack Daniels',1,'1c76d5ad-dba4-11ec-9b70-00ffd46fe11d','Whisky Jack Daniels, Apple, 1L','Whisky.webp','2022-05-24 18:06:54',56.000000000000000000000000000000,23),('7070ee44-dba5-11ec-9b70-00ffd46fe11d','Kit Whisky Passport Scotch',1,'1c76d5ad-dba4-11ec-9b70-00ffd46fe11d','Kit Whisky Passport Scotch 1L - 12 Unidades','Kit-Whisky-Passport.jpg','2022-05-24 18:06:54',45.000000000000000000000000000000,1),('708c806c-dba5-11ec-9b70-00ffd46fe11d','Potinhos Empilhar e Rolar',1,'1c7867ac-dba4-11ec-9b70-00ffd46fe11d','Potinhos Empilhar e Rolar, Fisher Price, Mattel','Potinho_Empilhar.webp','2022-05-24 18:06:54',345.000000000000000000000000000000,35),('70a70080-dba5-11ec-9b70-00ffd46fe11d','Dixit Odyssey, Galápagos',1,'1c7867ac-dba4-11ec-9b70-00ffd46fe11d','Pneu Bridgestone Aro 16 185/55R16 83V','DixitOdyssey.webp','2022-05-24 18:06:54',65.000000000000000000000000000000,56),('70c16f3e-dba5-11ec-9b70-00ffd46fe11d','Quadriciclo Spider Caixa',1,'1c7867ac-dba4-11ec-9b70-00ffd46fe11d','Pneu Bridgestone Aro 16 185/55R16 83V','Quadriciclo.webp','2022-05-24 18:06:54',432.000000000000000000000000000000,87),('70e32da3-dba5-11ec-9b70-00ffd46fe11d','Casa Malibu, Barbie, Mattel',1,'1c7867ac-dba4-11ec-9b70-00ffd46fe11d','Pneu Bridgestone Aro 16 185/55R16 83V','CasaMalibu.jpg','2022-05-24 18:06:55',123.000000000000000000000000000000,56),('70fb1c39-dba5-11ec-9b70-00ffd46fe11d','Lego CITY Quartel',1,'1c7867ac-dba4-11ec-9b70-00ffd46fe11d','Pneu Bridgestone Aro 16 185/55R16 83V','LegoCITY.webp','2022-05-24 18:06:55',54.000000000000000000000000000000,34),('711760ae-dba5-11ec-9b70-00ffd46fe11d','Smart TV LED 32\" HD LG',1,'1c79204f-dba4-11ec-9b70-00ffd46fe11d','Pneu Bridgestone Aro 16 185/55R16 83V','SmartTV.webp','2022-05-24 18:06:55',67.000000000000000000000000000000,76),('713589cc-dba5-11ec-9b70-00ffd46fe11d','Kit Capa Anti Impacto',1,'1c79204f-dba4-11ec-9b70-00ffd46fe11d','Kit Capa Anti Impacto e Película De Vidro ','KitCapaAnti.webp','2022-05-24 18:06:55',89.000000000000000000000000000000,10),('714d8369-dba5-11ec-9b70-00ffd46fe11d','Smartphone Xiaomi',1,'1c79204f-dba4-11ec-9b70-00ffd46fe11d','Smartphone Xiaomi Redmi 9 Dual Chip 64gb 4gb','Smartphone.webp','2022-05-24 18:06:55',78.000000000000000000000000000000,87),('716c412d-dba5-11ec-9b70-00ffd46fe11d','Notebook Acer Spin 3',1,'1c79204f-dba4-11ec-9b70-00ffd46fe11d','Notebook Acer Spin 3 SP314-54N Intel Core I5 8GB','Notebook.webp','2022-05-24 18:06:56',67.000000000000000000000000000000,9),('71858a45-dba5-11ec-9b70-00ffd46fe11d','COMPUTADOR BUSINESS',1,'1c79204f-dba4-11ec-9b70-00ffd46fe11d','COMPUTADOR BUSINESS B700 3.4GHZ 8GB DDR3 SSD','COMPUTADOR.webp','2022-05-24 18:06:56',567.000000000000000000000000000000,23);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-25 21:38:35
