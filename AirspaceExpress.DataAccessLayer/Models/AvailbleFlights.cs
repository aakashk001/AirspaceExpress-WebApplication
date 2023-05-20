using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AirspaceExpress.DataAccessLayer.Models
{
   public class AvailbleFlights
    {
        
        public decimal? BaseFare { get; set; }
        [Key]
        public string FlightId { get; set; }

        public string FlightStatus { get; set; }

        public string AirlineName { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public TimeSpan? ArivalTime { get; set; }

        public decimal? Stops { get; set; }

    }
}
