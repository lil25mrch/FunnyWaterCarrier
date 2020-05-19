CREATE TABLE `employee` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Surname` varchar(45) NULL,
  `Name` varchar(45) NULL,
  `Patronymic` varchar(45) NULL,
  `Birthday` datetime NULL,
  `Gender` int NULL,
  `SubdivisionId` int NULL,
  PRIMARY KEY (`Id`),
  KEY `SubdivisionId` (`SubdivisionId`)
);

CREATE TABLE `order` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(45) NULL,
  `EmployeeId` int NULL,
  PRIMARY KEY (`Id`),
  KEY `EmployeeId` (`EmployeeId`),
  CONSTRAINT `booking_ibfk_1` FOREIGN KEY (`EmployeeId`) REFERENCES `employee` (`Id`)
);

CREATE TABLE `subdivision` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NULL,
  `EmployeeId` int NULL,
  PRIMARY KEY (`Id`),
  KEY `EmployeeId` (`EmployeeId`),
  CONSTRAINT `subdivision_ibfk_1` FOREIGN KEY (`EmployeeId`) REFERENCES `employee` (`Id`)
); 

ALTER TABLE employee 
ADD CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`SubdivisionId`) REFERENCES `subdivision` (`Id`);

