using FlightsAppBE.Med.Quaries;
using FlightsAppBE.Model.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;

namespace FlightsAppBE.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FlightController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<AirportController> _logger;

        public FlightController(ILogger<AirportController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("GetOneWayFlights")]
        public async Task<IActionResult> GetOneWayFlights(OneWayFlightRequest request)
        {
            var query = new GetOneWayFlightsQuery() { flightRequest=request };
            var response = new ApiResponse<List<Flight>>();
            response = await _mediator.Send(query);
            
            if (response.Success)
            {
                return StatusCode(response.StatusCode, response);
            }
            return StatusCode(response.StatusCode, response);

        }

        [HttpPost("GetRoundTripFlights")]
        public async Task<IActionResult> GetRoundTripFlights(RoundTripFlightRequest request)
        {
            var query = new GetRoundTripFlightsQuery() { roundTripFlightRequest=request };
            var response = new ApiResponse<List<RoundTripFlight>>();
            response = await _mediator.Send(query);
            if (response.Success)
            {
                return StatusCode(response.StatusCode, response);
            }
            return StatusCode(response.StatusCode, response);

        }

    }
}
