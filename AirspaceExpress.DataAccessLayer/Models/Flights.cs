using System;
using System.Collections.Generic;

namespace AirspaceExpress.DataAccessLayer.Models
{
    public partial class Flights
    {
        public Flights()
        {
            Bookings = new HashSet<Bookings>();
            Fare = new HashSet<Fare>();
            PassengerDetails = new HashSet<PassengerDetails>();
        }

        public decimal FlightIndex { get; set; }
        public string FlightId { get; set; }
        public string FlightStatus { get; set; }
        public string AirlineName { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArivalTime { get; set; }
        public decimal? SeatsAvailable { get; set; }
        public decimal? Stops { get; set; }
        public decimal? Sdid { get; set; }

        public virtual FlightData Sd { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
        public virtual ICollection<Fare> Fare { get; set; }
        public virtual ICollection<PassengerDetails> PassengerDetails { get; set; }
    }
}
