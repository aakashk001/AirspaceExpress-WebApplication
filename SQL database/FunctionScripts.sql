Alter FUNCTION ufn_showFlights(
@Source VARCHAR(50),
@Destination VARCHAR(50),
@NoOfTravellers NUMERIC(10),
@NoStop NUMERIC(2),
@TravelBookingClass VARCHAR(50)
)
RETURNS TABLE 
AS 
RETURN (
SELECT F.FlightId, F.AirlineName,CAST(F.DepartureTime AS time ) AS [DepartureTime], CAST(F.ArivalTime as time)  AS [ArivalTime], F.Stops, FR.BaseFare 
FROM FlightData FD INNER JOIN Flights F ON FD.SDID = F.SDID INNER JOIN
Fare FR ON F.FlightIndex = FR.FlightIndex
WHERE FD.Source = @Source AND FD.Destination = @Destination AND F.SeatsAvailable >@NoOfTravellers AND F.Stops = @NoStop AND FR.Class = @TravelBookingClass
)






GO
SELECT * FROM FlightData
SELECT * FROM Flights

SELECT * FROM Fare