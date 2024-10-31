-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bdincos2023
-- ------------------------------------------------------
-- Server version	8.0.39

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
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria` (
  `id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `descripcion` varchar(120) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `estado` tinyint NOT NULL DEFAULT '1',
  `fechaRegistro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` timestamp NULL DEFAULT NULL,
  `idUsuario` tinyint NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'LACTEOS','LECHE, YOGURT, QUESO, MANTEQUILLA',1,'2023-05-12 00:30:18',NULL,1),(2,'CARNICOS AAA','AAAA  CARNE DE RES, CERDO, ETC',0,'2023-05-12 00:36:11','2023-05-16 02:02:10',1),(3,'OTRA','DASDADSA',1,'2023-07-25 01:48:27',NULL,1);
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `id` smallint unsigned NOT NULL AUTO_INCREMENT,
  `nit` varchar(15) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `razonSocial` varchar(120) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `estado` tinyint NOT NULL DEFAULT '1',
  `fechaRegistro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` timestamp NULL DEFAULT NULL,
  `idUsuario` tinyint NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departamento`
--

DROP TABLE IF EXISTS `departamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `departamento` (
  `id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departamento`
--

LOCK TABLES `departamento` WRITE;
/*!40000 ALTER TABLE `departamento` DISABLE KEYS */;
INSERT INTO `departamento` VALUES (1,'COCHABAMBA'),(2,'LA PAZ'),(3,'ORURO'),(4,'SANTA CRUZ'),(5,'CHUQUISACA'),(6,'TARIJA');
/*!40000 ALTER TABLE `departamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle`
--

DROP TABLE IF EXISTS `detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalle` (
  `idVenta` mediumint unsigned NOT NULL,
  `idProducto` smallint unsigned NOT NULL,
  `precioUnitario` decimal(6,2) NOT NULL,
  `cantidad` smallint NOT NULL,
  PRIMARY KEY (`idVenta`,`idProducto`),
  KEY `fk_Venta_has_Producto_Producto1_idx` (`idProducto`),
  KEY `fk_Venta_has_Producto_Venta1_idx` (`idVenta`),
  CONSTRAINT `fk_Venta_has_Producto_Producto1` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`id`),
  CONSTRAINT `fk_Venta_has_Producto_Venta1` FOREIGN KEY (`idVenta`) REFERENCES `venta` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle`
--

LOCK TABLES `detalle` WRITE;
/*!40000 ALTER TABLE `detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleado`
--

DROP TABLE IF EXISTS `empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleado` (
  `id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `ci` varchar(15) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `nombres` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `primerApellido` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `segundoApellido` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin DEFAULT NULL,
  `fechaNacimiento` date NOT NULL,
  `sexo` char(1) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `estado` tinyint NOT NULL DEFAULT '1',
  `fechaRegistro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` timestamp NULL DEFAULT NULL,
  `idUsuario` tinyint unsigned DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado`
--

LOCK TABLES `empleado` WRITE;
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
INSERT INTO `empleado` VALUES (1,'784549-1A','ANGELA','CHARQUI','LOPEZ','1998-01-12','F',1,'2023-07-25 01:57:50',NULL,1);
/*!40000 ALTER TABLE `empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `producto` (
  `id` smallint unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `precioBaseVenta` decimal(6,2) NOT NULL,
  `unidadMedida` varchar(15) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `saldo` smallint NOT NULL,
  `estado` tinyint NOT NULL DEFAULT '1',
  `fechaRegistro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` timestamp NULL DEFAULT NULL,
  `idUsuario` tinyint NOT NULL,
  `idCategoria` tinyint unsigned NOT NULL,
  `idProveedor` smallint unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Producto_Categoria1_idx` (`idCategoria`),
  KEY `fk_proveedor_idx` (`idProveedor`),
  CONSTRAINT `fk_Producto_Categoria1` FOREIGN KEY (`idCategoria`) REFERENCES `categoria` (`id`),
  CONSTRAINT `fk_proveedor` FOREIGN KEY (`idProveedor`) REFERENCES `proveedor` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedor`
--

DROP TABLE IF EXISTS `proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proveedor` (
  `id` smallint unsigned NOT NULL AUTO_INCREMENT,
  `denominacion` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `direccion` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `latitud` float NOT NULL,
  `longitud` float NOT NULL,
  `estado` tinyint NOT NULL DEFAULT '1',
  `fechaRegistro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` timestamp NULL DEFAULT NULL,
  `idUsuario` tinyint NOT NULL,
  `idDepartamento` tinyint unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_departamento_idx` (`idDepartamento`),
  CONSTRAINT `fk_departamento` FOREIGN KEY (`idDepartamento`) REFERENCES `departamento` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,'PROFORMS','CALLE A',-17.403,-66.1492,1,'2023-06-13 02:02:22',NULL,1,1);
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `ci` varchar(15) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `nombres` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `primerApellido` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `segundoApellido` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin DEFAULT NULL,
  `fechaNacimiento` date NOT NULL,
  `sexo` char(1) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `rol` varchar(15) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL COMMENT 'Administrador: Propietario y Jefe\nCajero: Encargado de Ventas',
  `nombreUsuario` varchar(12) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `contrasenia` char(32) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `estado` tinyint NOT NULL DEFAULT '1',
  `fechaRegistro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` timestamp NULL DEFAULT NULL,
  `idUsuario` tinyint unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ci_UNIQUE` (`ci`),
  KEY `fk_Usuario_Usuario_idx` (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'7464644-1A','ANGELA','CHARQUI','LOPEZ','2003-01-01','F','Cajero','admin','c4ca4238a0b923820dcc509a6f75849b',1,'2023-05-18 23:16:48',NULL,1),(2,'12345678','Carlos','Gomez','Perez','1985-04-12','M','Cajero','cgomez','7c6a180b36896a0a8c02787eeafb0e4c',1,'2023-01-10 12:30:00',NULL,1),(3,'87654321','Maria','Lopez','Torres','1990-05-23','F','Cajero','mlopez','6cb75f652a9b52798eb6cf2201057c73',1,'2023-02-15 13:00:00',NULL,1),(4,'23456789','Royer','Nina',NULL,'1988-03-08','M','Administrador','royer123','5d0bb1ad8127a440d7e9740d4d4fcd2b',1,'2023-03-20 14:15:00',NULL,1),(5,'34567890','Pame','Santos','NULL','1992-07-17','F','Cajero','pame123','2cc498ad495437ddef2d1549c62e4ecb',1,'2023-04-22 15:45:00',NULL,2),(6,'45678901','Luis','Ruiz','Gonzales','1983-11-11','M','Cajero','lruiz','db0edd04aaac4506f7edab03ac855d56',1,'2023-05-25 16:25:00',NULL,2);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta`
--

DROP TABLE IF EXISTS `venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venta` (
  `id` mediumint unsigned NOT NULL AUTO_INCREMENT,
  `total` decimal(7,2) NOT NULL,
  `fecha` date NOT NULL,
  `estado` tinyint NOT NULL DEFAULT '1',
  `fechaRegistro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` timestamp NULL DEFAULT NULL,
  `idUsuario` tinyint unsigned NOT NULL,
  `idCliente` smallint unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Venta_Cliente1_idx` (`idCliente`),
  CONSTRAINT `fk_Venta_Cliente1` FOREIGN KEY (`idCliente`) REFERENCES `cliente` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta`
--

LOCK TABLES `venta` WRITE;
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-31 15:48:58
