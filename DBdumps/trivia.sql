-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: trivia
-- ------------------------------------------------------
-- Server version	8.1.0

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
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `CategoryID` int NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CategoryID`),
  UNIQUE KEY `CategoryID_UNIQUE` (`CategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'History'),(2,'Sport'),(3,'Computer Games');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `players`
--

DROP TABLE IF EXISTS `players`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `players` (
  `PlayerID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Score` int DEFAULT NULL,
  `Time` float DEFAULT NULL,
  PRIMARY KEY (`PlayerID`),
  UNIQUE KEY `idplayers_UNIQUE` (`PlayerID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `players`
--

LOCK TABLES `players` WRITE;
/*!40000 ALTER TABLE `players` DISABLE KEYS */;
/*!40000 ALTER TABLE `players` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `questions` (
  `QuestionID` int NOT NULL AUTO_INCREMENT,
  `Question` varchar(200) DEFAULT NULL,
  `Answer1` varchar(80) DEFAULT NULL,
  `Answer2` varchar(80) DEFAULT NULL,
  `Answer3` varchar(80) DEFAULT NULL,
  `Answer4` varchar(80) DEFAULT NULL,
  `Correctanswer` int DEFAULT NULL,
  `CategoryID` int DEFAULT NULL,
  PRIMARY KEY (`QuestionID`),
  UNIQUE KEY `idquestions_UNIQUE` (`QuestionID`),
  KEY `CategoryID_idx` (`CategoryID`),
  CONSTRAINT `CategoryID` FOREIGN KEY (`CategoryID`) REFERENCES `categories` (`CategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
INSERT INTO `questions` VALUES (1,'What ancient wonder was a colossal statue of the Greek god Helios, standing in the city of Rhodes?','The Hanging Gardens of Babylon','The Great Pyramid of Giza','The Lighthouse of Alexandria','The Colossus of Rhodes',4,1),(2,'Which famous explorer is credited with being the first European to reach India by sea, opening up a direct trade route?','Christopher Columbus','Ferdinand Magellan','Vasco da Gama','Marco Polo',3,1),(3,'Which historical event marked the beginning of World War I?','The assassination of Archduke Franz Ferdinand','The signing of the Treaty of Versailles','The sinking of the Titanic','The Boston Tea Party',1,1),(4,'During which war did the famous Battle of Gettysburg take place?','American Revolutionary War','World War I','American Civil War','War of 1812',3,1),(5,'Which civilization built the ancient city of Machu Picchu?','Ancient Egyptians','Aztecs','Incas','Mayans',3,1),(6,'Which country won the FIFA World Cup in 2018?','Germany',' France','Brazil','Argentina',2,2),(7,'In which sport would you perform a slam dunk?','Tennis','Golf','Swimming','Basketball',4,2),(8,'Who is often referred to as \"The Greatest\" in the world of boxing and is known for his legendary bouts with opponents like Sonny Liston and Joe Frazier?','George Foreman','Mike Tyson','Muhammad Ali','Sugar Ray Robinson',3,2),(9,'Which country is traditionally associated with the sport of sumo wrestling?','Japan','South Korea','China','Mongolia',1,2),(10,'In the popular game \"Minecraft,\" what is the main objective of the game?','Surviving in a post-apocalyptic world','Building and crafting in an open world','Solving complex puzzles','Racing against other players',2,3),(11,'Which game features a battle royale mode called \"Warzone\" and is known for its annual releases with titles like \"Modern Warfare\" and \"Black Ops\"?','Fortnite','Apex Legends','PUBG','Call of Duty',4,3),(12,'In \"The Legend of Zelda\" series, what is the name of the protagonist, the hero of Hyrule?','Link','Zelda','Ganondorf','Epona',1,3),(13,'Which game, developed by Mojang Studios, involves placing and breaking blocks in a 3D procedurally generated world and has a creative mode and a survival mode?','Terraria','Minecraft','Roblox','Stardew Valley',2,3);
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-06 16:26:45
