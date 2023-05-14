---Input Required 
--1. Source
--2. Destination 
--3. NoofTraverllers
--4. Travel Class


--Output 
--1. Airline
--2. DepartureTime 
--3. Arival Time
--4. Stopage 
--5 BaseFare

--Step 1 We need to find weather there is any flight exists for the required source and destination 

CREATE FUNCTION ufn_FetchAvailableFlights(
@Source VARCHAR(50),
@Destination VARCHAR(50),
@NoOfTraverllers Numeric(10),
@TravelClass VARCHAR(10)
)
RETURNS TABLE 
AS 
RETURN 
(
SELECT AF.BaseFare,FL.FlightId,FL.FlightStatus,FL.AirlineName,FL.DepartureTime,FL.ArivalTime
FROM AirspaceExpress..Fare 
AS AF 
INNER JOIN 
AirspaceExpress..Flights AS  FL 
ON AF.FlightIndex = FL.FlightIndex
WHERE FL.SDID 
= (SELECT SDID FROM AirspaceExpress..FlightData
Where Source = @Source AND Destination = @Destination)
AND AF.Class = @TravelClass
AND FL.SeatsAvailable >= @NoOfTraverllers)
GO


--Execution Script

SELECT * FROM dbo.ufn_FetchAvailableFlights('Bengaluru','goa',2,'Economy')