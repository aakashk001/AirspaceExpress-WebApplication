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


---Stored Procedure For Adding Booking Flight Ticket 
CREATE PROCEDURE [dbo].[usp_booking](
@EmailId VARCHAR(50),
@TravelBookingClass VARCHAR(50),
@DeparturDate DATE,
@NoOfTicket NUMERIC(3),
@FlightId VARCHAR(10)
)
AS
BEGIN TRY
	DECLARE @ReturnVal NUMERIC(3) ,
	@FlightIndex NUMERIC(10),
	@BaseFare NUMERIC(10),
	@BookingCost NUMERIC(8,2),
	@FlightStatus VARCHAR(50),
	@TicketStatus VARCHAR(50)
		BEGIN
			IF @EmailId IS NULL OR @TravelBookingClass IS NULL OR @DeparturDate IS NULL OR @NoOfTicket IS NULL OR @FlightId IS NULL
				SET @ReturnVal = -1
			ELSE
				BEGIN
				SELECT @FlightIndex = FlightIndex FROM Flights WHERE FlightId = @FlightId 
				SELECT @BaseFare = BaseFare FROM Fare WHERE Class =  @TravelBookingClass AND FlightIndex = @FlightIndex
				SELECT @FlightStatus =  FlightStatus  FROM Flights WHERE FlightId = @FlightId
				IF @FlightStatus = 'Running' 
						BEGIN
						SET @TicketStatus = 'Confirmed'
							BEGIN
							INSERT INTO Bookings(EmailId,BookingCost,TravelBookingClass,DeparturDate,NoOfTicket,TicketStatus,FlightIndex)
							VALUES(@EmailId,@BaseFare*@NoOfTicket,@TravelBookingClass,@DeparturDate,@NoOfTicket,@TicketStatus,@FlightIndex)
							SET @ReturnVal = 1
							END
						END
					ELSE 
						BEGIN
						SET @TicketStatus = 'Cancelled'
						BEGIN
							INSERT INTO Bookings(EmailId,BookingCost,TravelBookingClass,DeparturDate,NoOfTicket,TicketStatus,FlightIndex)
							VALUES(@EmailId,@BaseFare*@NoOfTicket,@TravelBookingClass,@DeparturDate,@NoOfTicket,@TicketStatus,@FlightIndex)
							SET @ReturnVal = 1
							END
						END
				END
		END
		SELECT @ReturnVal
	END TRY
	BEGIN CATCH 
			SELECT @ReturnVal = -99
	END CATCH
GO

--Stored Procedure For Adding  PassengerDetails

alter PROCEDURE [dbo].[usp_passengerDetails]
(
@PassengerName VARCHAR(50),
@PassengerAge NUMERIC(3), 
@Gender CHAR(1),
@BookingId NUMERIC(10)
)
AS
BEGIN TRY 
	DECLARE @ReturnVal NUMERIC(3),
	@FlightIndex NUMERIC(10),
	@BookingStatus VARCHAR(10)
	BEGIN 
		IF @BookingId IS NULL OR @PassengerName IS NULL OR @PassengerAge IS NULL OR @Gender IS NULL 
			SET @ReturnVal = -1
		ELSE IF @Gender NOT IN ('M','F')
			SET @ReturnVal = -2
		ELSE IF @PassengerAge > 100
			SET @ReturnVal = -3
		ELSE 
			BEGIN
			SELECT @BookingStatus = TicketStatus , @FlightIndex = FlightIndex FROM Bookings WHERE BookingId = @BookingId
			INSERT INTO PassengerDetails (PassengerName,PassengerAge,Gender,BookingStatus,FlightIndex,BookingId)
			VALUES(@PassengerName,@PassengerAge,@Gender,@BookingStatus,@FlightIndex,@BookingId)
			SET @ReturnVal = 1
			END
	END
	SELECT @ReturnVal
END TRY
BEGIN CATCH
SELECT @ReturnVal = -99
END CATCH

GO

---Stored Procedure For UserLogin
ALTER PROCEDURE usp_ValidateCredentials(
@EmailId VARCHAR(50),
@Password VARCHAR(50)
)
AS 
BEGIN TRY
	BEGIN
	IF NOT EXISTS (SELECT EmailId FROM userData WHERE EmailId = @EmailId)
		RETURN  -1
	ELSE IF NOT  EXISTS (SELECT Password FROM userData WHERE EmailId = @EmailId AND Password = @Password)
		RETURN -2
	ELSE 
		BEGIN
		IF EXISTS (SELECT 1 FROM userData WHERE EmailId = @EmailId AND Password = @Password)
			BEGIN
			RETURN 1
			END
		ELSE 
			RETURN -3
		END
	END
END TRY
 BEGIN CATCH
 RETURN -99
 END CATCH
