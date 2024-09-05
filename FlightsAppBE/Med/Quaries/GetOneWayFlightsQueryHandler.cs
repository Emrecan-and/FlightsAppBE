using AutoMapper;
using FlightsAppBE.Model.Models;
using MediatR;
using ServiceReference1;

namespace FlightsAppBE.Med.Quaries
{
    public class GetOneWayFlightsQueryHandler : IRequestHandler<GetOneWayFlightsQuery, ApiResponse<List<Flight>>>
    {
        private readonly  IMapper _mapper;
        public GetOneWayFlightsQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<Flight>>> Handle(GetOneWayFlightsQuery request, CancellationToken cancellationToken)
        {
            if (request.flightRequest == null)
            {
                return new ApiResponse<List<Flight>>()
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Input parameter is required and cannot be null or empty."
                };
            }
            if (request.flightRequest.Destination ==request.flightRequest.Origin || request.flightRequest.DepartureDate < DateTime.UtcNow)
            {
                return new ApiResponse<List<Flight>>()
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Incorrect input"
                };
            }
            var client = new AirSearchClient();

            var clientRequest = _mapper.Map<SearchRequest>(request.flightRequest);

            var clientResponse = await client.AvailabilitySearchAsync(clientRequest);

            if (clientResponse.HasError || clientResponse==null) {
                return new ApiResponse<List<Flight>>()
                {
                    Success = false,
                    StatusCode=500,
                    Message= "An unexpected error occurred. Please try again later."
                };
            }

            var Flights= _mapper.Map<List<Flight>>(clientResponse.FlightOptions);
            await client.CloseAsync();

            return new ApiResponse<List<Flight>>()
            {
                Success = true,
                Data = Flights,
                StatusCode = 200
            };
        }
    }
}
