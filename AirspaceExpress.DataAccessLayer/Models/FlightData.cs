using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<Flights> Flights { get; set; }
    }
}
