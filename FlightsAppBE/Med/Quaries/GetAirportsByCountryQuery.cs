using FlightsAppBE.Model.Models;
using FlightsAppBE.Repository.Models;
using MediatR;

namespace FlightsAppBE.Med.Quaries
{
    public class GetAirportsByCountryQuery : IRequest<ApiResponse<List<Airr>>>
    {
        public string Country { get; set; }
    }
}
