using FlightsAppBE.Model.Models;
using ServiceReference1;

namespace FlightsAppBE.Helper
{
    public static class FlightHelper
    {
        public static List<RoundTripFlight> MatchRoundTripFlights(List<Flight> outboundFlights, List<Flight> returnFlights)
        {
            var roundTripFlights = new List<RoundTripFlight>();
            foreach (var outbound in outboundFlights)
            {
                foreach (var returnFlight in returnFlights)
                {
                    if (IsValidCombination(outbound, returnFlight))
                    {
                        roundTripFlights.Add(new RoundTripFlight
                        {
                           OutboundFlight=outbound,
                           ReturnFlight=returnFlight
                        });
                    }
                }
            }
            return roundTripFlights;
        }

        public static bool IsValidCombination(Flight outbound, Flight returnFlight)
        {
            return outbound.ArrivalDateTime < returnFlight.DepartureDateTime;
        }
    }
}
