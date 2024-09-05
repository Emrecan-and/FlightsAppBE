using FlightsAppBE.Model.Models;
using FlightsAppBE.Repositories;
using FlightsAppBE.Repository.Models;
using MediatR;

namespace FlightsAppBE.Med.Quaries
{
    public class GetAirpotsByCountryAndCityQueryHandler : IRequestHandler<GetAirportsByCountryAndCityQuery, ApiResponse<List<Airr>>>
    {
        private readonly IAirportRepository _airportRepository;

        public GetAirpotsByCountryAndCityQueryHandler(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }
       
        public async Task<ApiResponse<List<Airr>>> Handle(GetAirportsByCountryAndCityQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Country)||string.IsNullOrEmpty(request.City))
            {
                return new ApiResponse<List<Airr>>()
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Country or city cannot be null or empty."
                };
            }
            var airports = await _airportRepository.GetAiportsByCityAndCountry(request.City,request.Country);
            if (airports == null)
            {
                return new ApiResponse<List<Airr>>()
                {
                    Success = false,
                    StatusCode=404,
                    Message= "No airports found for the specified country and city."
                };
            }
            return new ApiResponse<List<Airr>>()
            {
                Success = true,
                Data = airports,
                StatusCode = 200
            };
        }
    }
}
