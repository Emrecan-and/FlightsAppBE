using ServiceReference1;

namespace FlightsAppBE.Model.Models
{
    public class RoundTripFlight
    {
        public Flight OutboundFlight { get; set; }

        public Flight ReturnFlight { get; set; }
    }
}
