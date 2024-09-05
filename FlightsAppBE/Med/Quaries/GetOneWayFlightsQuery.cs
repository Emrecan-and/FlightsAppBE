using FlightsAppBE.Model.Models;
using MediatR;

namespace FlightsAppBE.Med.Quaries
{
    public class GetOneWayFlightsQuery : IRequest<ApiResponse<List<Flight>>>
    {
        public OneWayFlightRequest flightRequest { get; set; }
    }
}
