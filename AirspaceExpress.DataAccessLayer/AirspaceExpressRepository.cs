using System;
using System.Collections.Generic;
using System.Text;
using AirspaceExpress.DataAccessLayer.Models;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace AirspaceExpress.DataAccessLayer
{
  public class AirspaceExpressRepository
    {
        AirspaceExpressContext context;
        public AirspaceExpressRepository()
        {
            context = new AirspaceExpressContext();
        }
     //Function to extract all the user deatils form the database.
        public List<UserData> GetAllUsers()
        {
            var users = (from user in context.UserData select user).ToList();
            return users;
        }
        //Function use to implement login function by calling stroed procedure. 
        public int Authenticate_User(string emailId , string password)
        {
            int result = 0;
            int returnVal = 0;
            SqlParameter prmEmailId = new SqlParameter("@EmailId", emailId);
            SqlParameter prmPassword = new SqlParameter("@Password", password);
            SqlParameter prmResult = new SqlParameter("@Return", System.Data.SqlDbType.Int);
            prmResult.Direction = System.Data.ParameterDirection.Output;
            result = context.Database.ExecuteSqlRaw("EXEC @Return = usp_ValidateCredentials @EmailId,@Password",prmResult, prmEmailId, prmPassword);
            returnVal = Convert.ToInt32(prmResult.Value);
            return returnVal;
        }


        //Function use to Fetch availale flights by calling a table value function . 
        public List<AvailbleFlights> FetchAvailbleFlights(string source , string destination,int noOfTraverllers, string travelClass)
        {
            List<AvailbleFlights> allAvailableFlights = null;
            try
            {
                SqlParameter prmSource = new SqlParameter("@Source", source);
                SqlParameter prmdestination = new SqlParameter("@Destination", destination);
                SqlParameter prmnoOfTravellers = new SqlParameter("@NoOfTraverllers", noOfTraverllers);
                SqlParameter prmTravelClass = new SqlParameter("@TravelClass", travelClass);

               allAvailableFlights =  context.AvailbleFlights.FromSqlRaw("SELECT * FROM dbo.ufn_FetchAvailableFlights(@Source,@Destination,@NoOfTraverllers,@TravelClass)",
                    prmSource, prmdestination, prmnoOfTravellers, prmTravelClass).ToList();

            }
            catch (Exception)
            {
                allAvailableFlights = null;

            }

            return allAvailableFlights;
          
        }

        //Fucntion use to get all the desination from the database

        public List<string> Destination()
        {
            List<string> allFlight = new List<string>();
            try
            {
                allFlight = (from f in context.FlightData select f.Destination ).ToList();

            }
            catch (Exception)
            {

                allFlight = null;
            }

            return allFlight;
        }
        //Function use to implement all the sources from the database. 
        public List<string> Sources()
        {
            List<string> allSources = new List<string>();
            try
            {
            allSources =   (from p in context.FlightData select p.Source).ToList();
            }
            catch (Exception)
            {

                allSources = null;
            }
            return allSources;
        }
        //Function use to distinct travel class from the fare table. 
        public List<string> TravelClass()
        {
            List<string> travelClass = new List<string>();
            try
            {
                travelClass = (from c in context.Fare select c.Class).Distinct().ToList();
            }
            catch (Exception)
            {

                travelClass = null;
            }
            return travelClass;
        }

       
    }
}
