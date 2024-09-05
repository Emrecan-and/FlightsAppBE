using FlightsAppBE.Helper;
using FlightsAppBE.Model.Models;
using FlightsAppBE.Repositories;
using FlightsAppBE.Repository.Models;
using MediatR;

namespace FlightsAppBE.Med.Quaries
{
    public class GetAirportsByCountryQueryHandler : IRequestHandler<GetAirportsByCountryQuery, ApiResponse<List<Airr>>>
    {
        private readonly IAirportRepository _airportRepository;
        
        public GetAirportsByCountryQueryHandler(IAirportRepository airportRepository) { 
          _airportRepository = airportRepository;
        }
        public async Task<ApiResponse<List<Airr>>> Handle(GetAirportsByCountryQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Country))
            {
                return new ApiResponse<List<Airr>>()
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Country cannot be null or empty."
                };
            }
            var airports = await _airportRepository.GetAirportsByCountry(request.Country);
            if (airports == null)
            {
                return new ApiResponse<List<Airr>>()
                {
                    Success=false,
                    StatusCode=404,
                    Message= "No airports found for the specified country."
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
