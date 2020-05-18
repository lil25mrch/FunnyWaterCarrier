CREATE TABLE `employee` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Surname` varchar(45) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Patronymic` varchar(45) NOT NULL,
  `Birthday` datetime NOT NULL,
  `Gender` varchar(45) NOT NULL,
  `SubdivisionId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `SubdivisionId` (`SubdivisionId`)
);

CREATE TABLE `booking` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(45) NOT NULL,
  `EmployeeId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `EmployeeId` (`EmployeeId`),
  CONSTRAINT `booking_ibfk_1` FOREIGN KEY (`EmployeeId`) REFERENCES `employee` (`Id`)
);

CREATE TABLE `subdivision` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Leader` int NULL,
  PRIMARY KEY (`Id`),
  KEY `Leader` (`Leader`),
  CONSTRAINT `subdivision_ibfk_1` FOREIGN KEY (`Leader`) REFERENCES `employee` (`Id`)
); 

ALTER TABLE employee 
ADD CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`SubdivisionId`) REFERENCES `subdivision` (`Id`);

