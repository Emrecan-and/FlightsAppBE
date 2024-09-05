using FlightsAppBE.Model.Models;
using MediatR;

namespace FlightsAppBE.Med.Quaries
{
    public class GetRoundTripFlightsQuery: IRequest<ApiResponse<List<RoundTripFlight>>>
    {
        public  RoundTripFlightRequest roundTripFlightRequest { get; set; }
    }
}
