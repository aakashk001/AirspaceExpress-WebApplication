
--CREATING DATABASE
create database AirspaceExpress

use AirspaceExpress
GO

--CREATING TABLE userData
CREATE TABLE userData (UserId NUMERIC  CONSTRAINT pk_userdata PRIMARY KEY IDENTITY(1,1),EmailId VARCHAR(50), Password VARCHAR(10) , UserName VARCHAR(10) , UserType VARCHAR(10),
WalletAmount NUMERIC(10))
--INSERTING VALUE INTO TABLE userData
INSERT INTO userData(EmailId,Password,UserName,UserType,WalletAmount) VALUES ('tom123@gmail.com','tom@1234','Tom','Platinum',0)
--Table EXECUTION 

SELECT * FROM Bookings
SELECT * FROM userData
GO


--CREATING PROCEDURE usp_bookings


--To Check curren Identity Value
select IDENT_CURRENT('Bookings')
--To Reset Identity Value
DBCC CHECKIDENT ('[Bookings]', RESEED, 2004);