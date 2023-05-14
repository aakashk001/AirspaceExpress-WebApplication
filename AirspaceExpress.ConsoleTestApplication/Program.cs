using System;
using AirspaceExpress.DataAccessLayer;
namespace AirspaceExpress.ConsoleTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
           var repository = new AirspaceExpressRepository();
            //var users =  repository.GetAllUsers();
            //foreach(var user in users)
            // {
            //     Console.WriteLine("{0}\t\t{1}",user.EmailId, user.UserName);

            // }

            //var returnval = repository.Authenticate_User("maria10@gmail.com", "maria_10");
            //   if(returnval == 1)
            //   {
            //       Console.WriteLine("Login Successfull");
            //   }
            //   else
            //   {
            //       Console.WriteLine("Invalid Credentails");
            //   }

            //var repos = repository.FetchAvailbleFlights("Bengaluru", "Delhi", 2, "Economy");

            //Console.WriteLine("{0, -12}{1, -30}{2, -30}{3, -30}{4, -30}{5}", "BaseFare", "FlightId", "FlightStatus", "AirlineName", "DepartureTime", "ArivalTime");

            //if (repos == null)
            //{
            //    Console.WriteLine("Something went wrong !!!!Or not flight");
            //}
            //else
            //{
            //    foreach(var flight in repos)
            //    {
            //        Console.WriteLine("{0,-12}{ 1,-30}{ 2,-30}{ 3,-30}{4,-30}{5}",flight.BaseFare, flight.FlightId, flight.FlightStatus, flight.AirlineName, flight.DepartureTime, flight.ArivalTime);
            //    }
            //}

            //var repos = repository.FetchAvailbleFlights("Bengaluru", "Delhi", 2, "Economy");

            //Console.WriteLine("{0, -12}{1, -12}{2,12}", "BaseFare", "FlightId", "FlightStatus");

            //if (repos == null)
            //{
            //    Console.WriteLine("Something went wrong !!!!Or not flight");
            //}
            //else
            //{
            //    foreach (var flight in repos)
            //    {
            //        Console.WriteLine("{0,-12}{1, -12}{2,12}",flight.BaseFare,flight.FlightId,flight.FlightStatus);
            //    }
            //}

            //var repos = repository.allFlights();
            //Console.WriteLine("==============================");
            //if(repos == null)
            //{
            //    Console.WriteLine("Something went wrong");
            //}
            //else
            //{
            //    foreach(var Flight in repos)
            //    {
            //        Console.WriteLine("{0,-12}{1}", Flight.Source, Flight.Destination);
            //    }
            //}


        }
    }
}
