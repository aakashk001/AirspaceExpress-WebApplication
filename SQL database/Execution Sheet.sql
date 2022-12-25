--Executing Stored Procdure usp_registerUser 
DECLARE @EmailId VARCHAR(50) ,
@Password VARCHAR(50)  ,
@UserName VARCHAR(10),
@UserType VARCHAR(10) ,
@WalletAmount NUMERIC(10),
@ReturnVal NUMERIC(2)
EXEC usp_registerUser @EmailId  = 'steve_12@gmail.com' , @Password = 'steve@uk12' , @UserName ='Steve',@UserType = 'Silver' ,@WalletAmount = 45300
GO

--Executing Stored procedure bookings

DECLARE  @EmailId VARCHAR(50),
@TravelBookingClass VARCHAR(50),
@DeparturDate DATE,
@NoOfTicket NUMERIC(3),
@FlightId VARCHAR(10),
@ReturnVal NUMERIC(3)
EXEC usp_booking @EmailId = 'John94@gmail.com',@TravelBookingClass = 'Economy',@DeparturDate = '01-02-22', @NoOfTicket = 1 , @FlightId = 'AI-766'
--EXEC usp_booking @EmailId = 'maria10@gmail.com', @TravelBookingClass = 'Economy',@DeparturDate = '01-03-22' , @NoOfTicket = 2,@FlightId = 'AI-766'
--EXEC usp_booking @EmailId = 'John94@gmail.com', @TravelBookingClass = 'Economy',@DeparturDate = '02-02-22' , @NoOfTicket = 0,@FlightId = 'E6-2135'
--EXEC usp_booking @EmailId = 'John94@gmail.com', @TravelBookingClass = 'Economy',@DeparturDate = '01-02-22' , @NoOfTicket = 1,@FlightId = 'E6-2135'
--EXEC usp_booking @EmailId = 'John94@gmail.com', @TravelBookingClass = 'Economy',@DeparturDate = '01-02-22' , @NoOfTicket = 1,@FlightId = 'I5-2878'

--Executing STORED PROCEDURE usp_registerUser
GO

--Executing Stored Procedure usp_PassengerDetails
DECLARE @PassengerName VARCHAR(50),
@PassengerAge NUMERIC(3), 
@Gender CHAR(1),
@BookingId NUMERIC(10)
--EXEC usp_passengerDetails @PassengerName  = 'David',@PassengerAge = 35  , @Gender = 'M', @BookingId = 2001
--EXEC usp_passengerDetails @PassengerName  = 'Maria',@PassengerAge = 38  , @Gender = 'F', @BookingId = 2001
--EXEC usp_passengerDetails @PassengerName  = 'Emily',@PassengerAge = 29  , @Gender = 'F', @BookingId = 2002
--EXEC usp_passengerDetails @PassengerName  = 'Steve',@PassengerAge = 25  , @Gender = 'M', @BookingId = 2003
--EXEC usp_passengerDetails @PassengerName  = 'Richard',@PassengerAge = 29  , @Gender = 'M', @BookingId = 2004
--EXEC usp_passengerDetails @PassengerName  = 'Joe',@PassengerAge = 25  , @Gender = 'M', @BookingId = 2005
--EXEC usp_passengerDetails @PassengerName  = 'Jack',@PassengerAge = 35  , @Gender = 'M', @BookingId = 2005
--EXEC usp_passengerDetails @PassengerName  = 'Emily',@PassengerAge = 29  , @Gender = 'F', @BookingId = 2006
--Runting the table
go

DECLARE 
@EmailId VARCHAR(50),
@Password VARCHAR(50),
@Return NUMERIC(3)
EXEC @Return = usp_ValidateCredentials @EmailId = 'tom123@gmail.com' , @Password = 'tom@1234'
SELECT @Return

SELECT * FROM userData
SELECT * FROM FlightData
SELECT * FROM Flights
SELECT * FROM Fare
SELECT * FROM Bookings
SELECT * FROM PassengerDetails
GO


SELECT * FROM Bookings
DELETE Bookings WHERE BookingId = 2005 
--To Check curren Identity Value
select IDENT_CURRENT('Bookings')
--To Reset Identity Value
DBCC CHECKIDENT ('[Bookings]', RESEED, 2004);
UPDATE Bookings SET TicketStatus = 'Cancelled' WHERE BookingId = 2004