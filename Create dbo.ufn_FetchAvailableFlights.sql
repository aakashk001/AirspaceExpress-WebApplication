USE [AirspaceExpress]
GO

/****** Object: Table Valued Function [dbo].[ufn_FetchAvailableFlights] Script Date: 18-05-2023 07:36:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--=======================================================================
---Input Required 
--1. Source -- where the passanger is currently
--2. Destination --This is where passanger user wants to go
--3. NoofTraverllers --How many peoples are traving with him or the no of tickets he want to book
--4. Travel Class - This can be either 1.Economy 2.Business.


--Output 
--1. Airline --Name of the airline
--2. DepartureTime  --The time at which the airline is going to departure
--3. Arival Time --The time at which the airline is ariving at the desintaion location 
--4. FlightStatus  -- Weather flight is suspended or running. 
--5 BaseFare -- cost of one ticket accoring to travel class. 
--6. Stops - if 0 non stop .1 if there is any stopage. 
--7. FlightId -- Id of the flight. 

--Step 1 We need to find weather there is any flight exists for the required source and destination 

-- =======================================================================================================


CREATE FUNCTION [dbo].[ufn_FetchAvailableFlights](
@Source VARCHAR(50),
@Destination VARCHAR(50),
@NoOfTraverllers Numeric(10),
@TravelClass VARCHAR(10),
@TravelTime DATE,
@Stops INT
)
RETURNS TABLE 
AS 
RETURN 
(
SELECT AF.BaseFare,FL.FlightId,FL.FlightStatus,FL.AirlineName,
CAST(FL.DepartureTime AS time ) AS [DepartureTime],
CAST(FL.ArivalTime as time)  AS [ArivalTime],
FL.Stops
FROM AirspaceExpress..Fare 
AS AF 
INNER JOIN 
AirspaceExpress..Flights AS  FL 
ON AF.FlightIndex = FL.FlightIndex
WHERE FL.SDID 
= (SELECT SDID FROM AirspaceExpress..FlightData
Where Source = @Source AND Destination = @Destination)
AND AF.Class = @TravelClass
AND FL.SeatsAvailable >= @NoOfTraverllers
AND FL.DepartureTime >= @TravelTime
AND FL.Stops =@Stops
)


SELECT * FROM dbo.ufn_FetchAvailableFlights('Bengaluru','Delhi',2,'Economy','2001-01-01',0)