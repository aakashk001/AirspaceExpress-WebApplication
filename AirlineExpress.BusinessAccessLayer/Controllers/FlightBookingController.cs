using AirspaceExpress.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirspaceExpress.DataAccessLayer.Models;


namespace AirlineExpress.BusinessAccessLayer.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlightBookingController : Controller
    {
        AirspaceExpressRepository repository;

            public FlightBookingController()
        {
            repository = new AirspaceExpressRepository();
        }
        //API to fetch all the available flight from the data access layer. 
        [HttpGet]
        public JsonResult FetchAvailableFlights(string source ,string destination , int noOfTravellers, string travelClass,DateTime travelTime)
        {
            List<AvailbleFlights> availbleFlight = new List<AvailbleFlights>();
            try
            {
                availbleFlight = repository.FetchAvailbleFlights(source, destination, noOfTravellers, travelClass,travelTime);
            }
            catch (Exception)
            {
                availbleFlight = null;
            }
            return Json(availbleFlight);

        }
        //API to fetch all the desintation from the DAL.
        [HttpGet]
        public JsonResult GetAllDestination()
        {
            List<string> allFlights = new List<string>();
            try
            {
                allFlights = repository.Destination();
            }
            catch (Exception)
            {

                allFlights = null;
            }
            return Json(allFlights);
        }
        //API to fetch all the source from the DAL 
        [HttpGet]

        public JsonResult GetAllSources()
        {
            List<string> getallSources = new List<string>();
            try
            {
             getallSources =  repository.Sources();
            }
            catch (Exception)
            {

                getallSources = null;
            }

            return  Json(getallSources);
        }

        //API to fetch all the travel call from the dal 

        [HttpGet]
        
        public JsonResult GetTravelClasses()
        {
            List<string> travelClass = new List<string>();
            try
            {
                travelClass = repository.TravelClass();
            }
            catch (Exception)
            {

                travelClass = null;
            }
            return Json(travelClass);
        }
    }
}
