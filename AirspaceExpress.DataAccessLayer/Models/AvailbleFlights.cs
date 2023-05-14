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

        public DateTime? DepartureTime { get; set; }

        public DateTime? ArivalTime { get; set; }

    }
}
