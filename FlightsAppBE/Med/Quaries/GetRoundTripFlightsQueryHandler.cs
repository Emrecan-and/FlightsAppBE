using AutoMapper;
using FlightsAppBE.Helper;
using FlightsAppBE.Model.Models;
using MediatR;
using ServiceReference1;

namespace FlightsAppBE.Med.Quaries
{
    public class GetRoundTripFlightsQueryHandler : IRequestHandler<GetRoundTripFlightsQuery, ApiResponse<List<RoundTripFlight>>>
    {
        private readonly IMapper _mapper;
        public GetRoundTripFlightsQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<RoundTripFlight>>> Handle(GetRoundTripFlightsQuery request, CancellationToken cancellationToken)
        {
            if (request.roundTripFlightRequest == null)
            {
                return new ApiResponse<List<RoundTripFlight>>()
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Input parameter is required and cannot be null or empty."
                };
            }
            
            if (request.roundTripFlightRequest.Destination == request.roundTripFlightRequest.Origin || request.roundTripFlightRequest.ReturnDate<request.roundTripFlightRequest.DepartureDate || request.roundTripFlightRequest.DepartureDate<DateTime.UtcNow )
            {
                return new ApiResponse<List<RoundTripFlight>>()
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Incorrect input"
                };
            }
            var client = new AirSearchClient();

            var outbounds = await client.AvailabilitySearchAsync(new SearchRequest() { DepartureDate=request.roundTripFlightRequest.DepartureDate, 
             Destination=request.roundTripFlightRequest.Destination,
             Origin=request.roundTripFlightRequest.Origin
            });

            var returns = await client.AvailabilitySearchAsync(new SearchRequest() { DepartureDate=request.roundTripFlightRequest.ReturnDate,
             Destination = request.roundTripFlightRequest.Origin,
             Origin = request.roundTripFlightRequest.Destination
            });

            if(outbounds.HasError || returns.HasError || outbounds==null || returns == null)
            {
                return new ApiResponse<List<RoundTripFlight>>()
                {
                    Success = false,
                    StatusCode=500,
                    Message = "An unexpected error occurred. Please try again later."
                };
            }

            List<Flight> outboundFlights = _mapper.Map<List<Flight>>(outbounds.FlightOptions);
            List<Flight> returnFlights = _mapper.Map<List<Flight>>(returns.FlightOptions);
            
            var RoundTripFlights=FlightHelper.MatchRoundTripFlights(outboundFlights, returnFlights);

            return new ApiResponse<List<RoundTripFlight>>()
            {
                Success=true,
                Data = RoundTripFlights,
                StatusCode = 200
            };

        }
    }
}
