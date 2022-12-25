
--CREATING DATABASE
create database AirspaceExpress

use AirspaceExpress
GO

--CREATING TABLE userData
CREATE TABLE userData (UserId NUMERIC  CONSTRAINT pk_userdata PRIMARY KEY IDENTITY(1,1),EmailId VARCHAR(50), Password VARCHAR(10) , UserName VARCHAR(10) , UserType VARCHAR(10),
WalletAmount NUMERIC(10))
--INSERTING VALUE INTO TABLE userData
INSERT INTO userData(EmailId,Password,UserName,UserType,WalletAmount) VALUES ('tom123@gmail.com','tom@1234','Tom','Platinum',0)

--CREATING TABLE Bookings
CREATE TABLE Bookings(BookingId NUMERIC(5) CONSTRAINT pk_bookings PRIMARY KEY IDENTITY(2001,1) , Status VARCHAR(10), UserId NUMERIC CONSTRAINT fk_bookings  References userData(UserId))
INSERT INTO Bookings (Status , UserId) VALUES ('Confirmed',1)
GO

--Table EXECUTION 

SELECT * FROM Bookings
SELECT * FROM userData
GO

--CREATING STORED PROCEDURE usp_registerUser
ALTER PROCEDURE [dbo].[usp_registerUser]
(
@EmailId VARCHAR(50),
@Password VARCHAR(50),
@UserName VARCHAR(10),
@UserType VARCHAR(10),
@WalletAmount NUMERIC(10)
)
AS 
BEGIN 
BEGIN TRY
	DECLARE @RETURN NUMERIC(2)
	IF  EXISTS (SELECT EmailId FROM userData WHERE EmailId = @EmailId)
		SET @RETURN = -1
	ELSE 
		BEGIN 
			INSERT INTO userData(EmailId,Password,UserName,UserType,WalletAmount) VALUES (@EmailId,@Password,@UserName,@UserType,@WalletAmount)
			SET @RETURN = 1
		END 
	SELECT @RETURN
	END TRY
		BEGIN CATCH 
			SET @RETURN = -99
		END CATCH
END 
GO

--CREATING PROCEDURE usp_bookings
CREATE PROCEDURE [dbo].[usp_bookings]
(
@EmailId VARCHAR(50),
@Status  VARCHAR(10)
)
AS 
BEGIN TRY
	DECLARE @UserId NUMERIC, @RETURN NUMERIC(2)	
	
	BEGIN 
		SELECT @UserId= UserId  FROM userData WHERE EmailId = @EmailId
		INSERT INTO Bookings (Status , UserId) VALUES (@Status,@UserId)
		SELECT @RETURN = 1
	END
END TRY
BEGIN CATCH
SELECT @RETURN = -99
END CATCH


--To Check curren Identity Value
select IDENT_CURRENT('Bookings')
--To Reset Identity Value
DBCC CHECKIDENT ('[Bookings]', RESEED, 2004);