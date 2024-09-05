namespace FlightsAppBE.Model.Models
{
    public class RoundTripFlightRequest
    {
        public DateTime DepartureDate { get; set; }

        public DateTime  ReturnDate { get; set; }

        public  string Destination { get; set; }

        public string Origin { get; set; }
    }
}
