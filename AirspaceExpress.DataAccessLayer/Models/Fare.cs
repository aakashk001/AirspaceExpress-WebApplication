using System;
using System.Collections.Generic;

namespace AirspaceExpress.DataAccessLayer.Models
{
    public partial class Fare
    {
        public decimal FareId { get; set; }
        public string Class { get; set; }
        public decimal? BaseFare { get; set; }
        public decimal? FlightIndex { get; set; }

        public virtual Flights FlightIndexNavigation { get; set; }
    }
}
