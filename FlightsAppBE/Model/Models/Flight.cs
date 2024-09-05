namespace FlightsAppBE.Model.Models
{
    public class Flight
    {
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }


    }
}
