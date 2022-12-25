using System;
using System.Collections.Generic;

namespace AirspaceExpress.DataAccessLayer.Models
{
    public partial class FlightData
    {
        public FlightData()
        {
            Flights = new HashSet<Flights>();
        }

        public decimal Sdid { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

        public virtual ICollection<Flights> Flights { get; set; }
    }
}
