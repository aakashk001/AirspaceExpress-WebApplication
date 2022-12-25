
--FlightData Table Creation 
CREATE TABLE FlightData(SDID NUMERIC(10) CONSTRAINT pk_sdid PRIMARY KEY IDENTITY,Source VARCHAR(50), Destination VARCHAR(50))
--INSERT value into the table 
INSERT INTO FlightData(Source,Destination) VALUES ('Bengaluru','Delhi')
INSERT INTO FlightData(Source,Destination) VALUES ('Chennai','Kolkata')
GO

--DROP Table Flights
--CREATATING TABLE FLIGHTS
CREATE TABLE Flights(FlightIndex NUMERIC(10) CONSTRAINT pk_flightIndex PRIMARY KEY IDENTITY,FlightId VARCHAR(10), FlightStatus VARCHAR(10),AirlineName VARCHAR(10),DepartureTime DATETIME ,ArivalTime DATETIME,
SeatsAvailable NUMERIC(10),Stops NUMERIC(10),SDID NUMERIC(10) CONSTRAINT fk_sdid References FlightData(SDID) ,Bookings VARCHAR(10))

--INSERTING VALUES INTO Table
INSERT INTO Flights(
FlightId,FlightStatus,AirlineName,DepartureTime,ArivalTime,SeatsAvailable,Stops,SDID,Bookings
)VALUES ('I5-2878','Running','Air Asia','01-01-01 06:15:00','01-01-01 08:45:00',96,0,1,'---')

INSERT INTO Flights(
FlightId,FlightStatus,AirlineName,DepartureTime,ArivalTime,SeatsAvailable,Stops,SDID,Bookings
)VALUES ('E6-2135','Running','Indigo','01-01-01 06:00:00','01-01-01 08:50:00',4,0,1,'---')

INSERT INTO Flights(
FlightId,FlightStatus,AirlineName,DepartureTime,ArivalTime,SeatsAvailable,Stops,SDID,Bookings
)VALUES ('AI-766','Running','Air India','01-01-01 11:35:00','01-01-01 13:35:00',23,1,2,'---')

INSERT INTO Flights(
FlightId,FlightStatus,AirlineName,DepartureTime,ArivalTime,SeatsAvailable,Stops,SDID,Bookings
)VALUES ('E6-2145','Cancelled','Indigo','01-01-01 06:00:00','01-01-01 08:50:00',10,0,2,'---')
--ALTER TABLE 
ALTER TABLE Flights DROP COLUMN Bookings 
GO

---CREATING Fare Table
CREATE TABLE Fare (FareId NUMERIC(10) CONSTRAINT pk_fareId PRIMARY KEY IDENTITY , 
Class VARCHAR(10) , BaseFare NUMERIC(10), FlightIndex NUMERIC(10) CONSTRAINT fk_FlightIndex REFERENCES  Flights(FlightIndex))

INSERT INTO Fare(Class,BaseFare,FlightIndex) Values ('Economy',4485,1)
INSERT INTO Fare(Class,BaseFare,FlightIndex) Values ('Business',9485,1)

INSERT INTO Fare(Class,BaseFare,FlightIndex) Values ('Economy',3988,2)
INSERT INTO Fare(Class,BaseFare,FlightIndex) Values ('Business',9999,2)

INSERT INTO Fare(Class,BaseFare,FlightIndex) Values ('Economy',3587,3)
INSERT INTO Fare(Class,BaseFare,FlightIndex) Values ('Business',9649,3)

INSERT INTO Fare(Class,BaseFare,FlightIndex) Values ('Economy',3988,4)
INSERT INTO Fare(Class,BaseFare,FlightIndex) Values ('Business',9999,4)

GO

DROP TABLE Bookings
--CREATE Bookings Table 
CREATE TABLE Bookings (BookingId NUMERIC(10) CONSTRAINT pk_bookingId PRIMARY KEY IDENTITY(2001,1) ,EmailId VARCHAR(50), BookingCost NUMERIC(8,2), 
TravelBookingClass VARCHAR(50),DeparturDate DATE , NoOfTicket NUMERIC(3),TicketStatus VARCHAR(50),
FlightIndex NUMERIC(10) CONSTRAINT fk_BookingFlightIndex REFERENCES  Flights(FlightIndex))

INSERT INTO Bookings(EmailId,BookingCost,TravelBookingClass,DeparturDate,NoOfTicket,TicketStatus,FlightIndex)VALUES('tom123@gmail.com',13455,'Economy','01-01-01',3,'Confirmed',1)
go

CREATE TABLE PassengerDetails(PassengerID NUMERIC(10) CONSTRAINT pk_PrimaryKey PRIMARY KEY IDENTITY (101,1) , PassengerName VARCHAR(50), PassengerAge NUMERIC(3), 
Gender CHAR(1) CONSTRAINT check_gender CHECK(GENDER IN('M','F')), BookingStatus VARCHAR(50),FlightIndex NUMERIC(10) CONSTRAINT fk_passengerflightIndex  REFERENCES Flights(FlightIndex), BookingId NUMERIC(10) CONSTRAINT 
fk_passengerBookingId REFERENCES Bookings(BookingId))

INSERT INTO PassengerDetails (PassengerName,PassengerAge,Gender,BookingStatus,FlightIndex,BookingId) VALUES('John',45,'M','Confirmed',1,2001)



--DROP TABLE PassengerDetails