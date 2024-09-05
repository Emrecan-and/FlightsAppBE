namespace FlightsAppBE.Model.Models
{
    public class OneWayFlightRequest
    {
        public DateTime DepartureDate { get; set; }

        public string Destination { get; set; }

        public string Origin { get; set; }
    }
}
