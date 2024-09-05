using FlightsAppBE.Model.Models;
using FlightsAppBE.Repositories;
using FlightsAppBE.Repository.Models;
using MediatR;

namespace FlightsAppBE.Med.Quaries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, ApiResponse<List<string>>>
    {
        private readonly IAirportRepository _airportRepository;

        public GetCountriesQueryHandler(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public async Task<ApiResponse<List<string>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {

            var countries = await _airportRepository.GetCountries();
            if (!countries.Any())
            {
                return new ApiResponse<List<string>>()
                {
                    Success = false,
                    StatusCode=404,
                    Message = "No countries found"
                };
            }
            return new ApiResponse<List<string>>()
            {
                Success = true,
                Data = countries,
                StatusCode= 200
            };
        }
    }
}
