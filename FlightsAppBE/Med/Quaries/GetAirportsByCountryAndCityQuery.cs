using FlightsAppBE.Model.Models;
using FlightsAppBE.Repository.Models;
using MediatR;

namespace FlightsAppBE.Med.Quaries
{
    public class GetAirportsByCountryAndCityQuery : IRequest<ApiResponse<List<Airr>>>
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
