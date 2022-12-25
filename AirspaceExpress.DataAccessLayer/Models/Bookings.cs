using System;
using System.Collections.Generic;

namespace AirspaceExpress.DataAccessLayer.Models
{
    public partial class Bookings
    {
        public Bookings()
        {
            PassengerDetails = new HashSet<PassengerDetails>();
        }

        public decimal BookingId { get; set; }
        public string EmailId { get; set; }
        public decimal? BookingCost { get; set; }
        public string TravelBookingClass { get; set; }
        public DateTime? DeparturDate { get; set; }
        public decimal? NoOfTicket { get; set; }
        public string TicketStatus { get; set; }
        public decimal? FlightIndex { get; set; }

        public virtual Flights FlightIndexNavigation { get; set; }
        public virtual ICollection<PassengerDetails> PassengerDetails { get; set; }
    }
}
