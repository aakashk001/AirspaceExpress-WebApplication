using System;
using System.Collections.Generic;

namespace AirspaceExpress.DataAccessLayer.Models
{
    public partial class PassengerDetails
    {
        public decimal PassengerId { get; set; }
        public string PassengerName { get; set; }
        public decimal? PassengerAge { get; set; }
        public string Gender { get; set; }
        public string BookingStatus { get; set; }
        public decimal? FlightIndex { get; set; }
        public decimal? BookingId { get; set; }

        public virtual Bookings Booking { get; set; }
        public virtual Flights FlightIndexNavigation { get; set; }
    }
}
