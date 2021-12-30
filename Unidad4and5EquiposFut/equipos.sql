-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: equipos
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `equipo`
--

DROP TABLE IF EXISTS `equipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `equipo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) NOT NULL,
  `Pais` varchar(45) NOT NULL,
  `descripcion` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipo`
--

LOCK TABLES `equipo` WRITE;
/*!40000 ALTER TABLE `equipo` DISABLE KEYS */;
INSERT INTO `equipo` VALUES (2,'América','México','El Club de Fútbol América S. A. de C. V., es un equipo de fútboln 1profesional de la Primera División de México. Fue fundado el 12 de octubre de 1916 en la Ciudad de México, por un grupo de estudiantes encabezados por el jugador Rafael Garza Gutiérrez, y el profesor y entrenador Eugenio Cenoz. Disputa sus partidos, como local, en el Estadio Azteca, y los colores tradicionales del uniforme americanista son el amarillo y el azul.Es la institución con el mayor número de campeonatos en todo tipo de competencias oficiales entre los clubes del fútbol mexicano, sumando un total de 35 (25 nacionales y 10 internacionales).Ostenta el primer lugar en campeonatos de liga de Primera División con 13 títulos ganados. Al mismo tiempo, ocupa la primera posición en la lista de clubes con más títulos nacionales en México con veinticinco (trece de Liga, seis de Copa México —máximo ganador— y seis de Campeón de Campeones).1112 Es, junto al Club Deportivo Guadalajara, uno de los dos equipos que ha participado en todas las temporadas de Liga, desde 1943-44.'),(3,'Barcelona','España','El Fútbol Club Barcelona (en catalán, Futbol Club Barcelona), conocido popularmente como Barça,n. 1​ es una entidad polideportiva con sede en Barcelona, España. Fue fundado como club de fútbol el 29 de noviembre de 1899 y registrado oficialmente el 5 de enero de 1903.7​8​9​ Es uno de los cuatro clubes profesionales de España junto a Real Madrid Club de Fútbol, Athletic Club y Club Atlético Osasuna que no es sociedad anónima deportiva (S. A. D.), de manera que la propiedad del club recae en sus socios.'),(4,'Real Madrid','España','El Real Madrid Club de Fútbol, más conocido simplemente como Real Madrid, es una entidad polideportiva con sede en Madrid, España. Fue declarada oficialmente registrada como club de fútbol por sus socios el 6 de marzo de 1902 con el objeto de la práctica y desarrollo de este deporte —si bien sus orígenes datan al año 1900,8​ y su denominación de (Sociedad) Madrid Foot-ball Club a noviembre de 1901— siendo el quinto club fundado en la capital.n. 3​ Tuvo a Julián Palacios y los hermanos Juan Padrós y Carlos Padrós como principales valedores de su creación.');
/*!40000 ALTER TABLE `equipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `integrante`
--

DROP TABLE IF EXISTS `integrante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `integrante` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) NOT NULL,
  `Genero` varchar(45) NOT NULL,
  `Edad` int(11) NOT NULL,
  `NumCamiseta` int(11) NOT NULL,
  `Posicion` varchar(45) NOT NULL,
  `Estado` varchar(45) NOT NULL,
  `Aceleracion` int(11) NOT NULL,
  `Agilidad` int(11) NOT NULL,
  `Salto` int(11) NOT NULL,
  `ControlDeBalon` int(11) NOT NULL,
  `Ofensividad` int(11) NOT NULL,
  `Curva` int(11) NOT NULL,
  `Fuerza` int(11) NOT NULL,
  `Salario` decimal(10,0) NOT NULL,
  `IdEquipo` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_integrante_equipo` (`IdEquipo`),
  CONSTRAINT `fk_integrante_equipo` FOREIGN KEY (`IdEquipo`) REFERENCES `equipo` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `integrante`
--

LOCK TABLES `integrante` WRITE;
/*!40000 ALTER TABLE `integrante` DISABLE KEYS */;
INSERT INTO `integrante` VALUES (5,'Marcelo','Masculino',35,10,'Defensa','Activo',10,10,10,10,10,10,10,750000,4),(6,'Lionel messi','Masculino',35,10,'Delantero','Activo',10,10,10,10,10,10,10,750000,3),(10,'Cristiano ronaldo','Hombre',35,10,'Delantero','Activo',10,10,10,10,10,10,10,760000,4),(11,'El rol','gjhgjhg',19,10,'bhbjhb','jhb',10,10,10,10,10,10,10,77777,2),(12,'a','Hombre',19,10,'10','10',10,10,10,10,10,10,10,99999,2);
/*!40000 ALTER TABLE `integrante` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) NOT NULL,
  `NombreUsuario` varchar(45) NOT NULL,
  `Contraseña` varchar(128) NOT NULL,
  `Rol` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Blanca Rios','Blanca','f06f026bbae4c7f7ee4bac6544c292e59ed9d5f1e2ad186dc388b10fe52abc354fdfeac87d3c9dd13aeea284255a4fdd16db9d9e4ec2bb9d2b4d3d5b0581f926','Administrador'),(2,'Adan romero','adan','d1b69b3a313cd0eceb36cd4d3988c5ecf4fb8ea0a882ecbe10ecda6110dd158cce79184f0be194ad14516f26d6e329356f02969c95444498e0dd8a3e32f77aee','Supervisor');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'equipos'
--

--
-- Dumping routines for database 'equipos'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-29 20:56:20
