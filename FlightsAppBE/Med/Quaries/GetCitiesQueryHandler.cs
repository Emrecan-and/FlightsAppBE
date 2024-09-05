using FlightsAppBE.Model.Models;
using FlightsAppBE.Repositories;
using FlightsAppBE.Repository.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ServiceModel.Channels;

namespace FlightsAppBE.Med.Quaries
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, ApiResponse<List<string>>>
    {
        private readonly IAirportRepository _airportRepository;

        public GetCitiesQueryHandler(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public async Task<ApiResponse<List<string>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            if (request.Country == null)
            {
                return new ApiResponse<List<string>>()
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Country parameter is required and cannot be null or empty."
                };
            }
            var cities = await _airportRepository.GetCitiesByCountry(request.Country);
            if (!cities.Any())
            {
                return new ApiResponse<List<string>>()
                {
                    Success = false,
                    StatusCode=404,
                    Message = "No cities found for the specified country."
                };
            }
            return new ApiResponse<List<string>>()
            {
                Success = true,
                Data = cities,
                StatusCode = 200
            };
        }
    }
}
