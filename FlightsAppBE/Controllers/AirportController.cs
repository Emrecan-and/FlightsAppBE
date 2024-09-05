using FlightsAppBE.Med.Quaries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;

namespace FlightsAppBE.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AirportController : ControllerBase
    {
      
        private readonly IMediator _mediator;
        private readonly ILogger<AirportController> _logger;

        public AirportController(ILogger<AirportController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("GetAirportsByCountry")]
        public async Task<IActionResult> Get(string country)
        {
            var query=new GetAirportsByCountryQuery() { Country=country};
            var response=await _mediator.Send(query);
            if (response.Success)
            {
                return StatusCode(response.StatusCode, response);
            }
            return StatusCode(response.StatusCode, response);

        }

        [HttpGet("GetAirportsByCountryAndCity")]
        public async Task<IActionResult> GetByCity(string city,string country)
        {
            var query = new GetAirportsByCountryAndCityQuery() { Country = country, City=city };
            var response = await _mediator.Send(query);
            if (response.Success)
            {
                return StatusCode(response.StatusCode, response);
            }
            return StatusCode(response.StatusCode, response);

        }

        [HttpGet("GetCities")]
        public async Task<IActionResult> GetCities(string country)
        {
            var query = new GetCitiesQuery() { Country = country};
            var response = await _mediator.Send(query);
            if (response.Success)
            {
                return StatusCode(response.StatusCode, response);
            }
            return StatusCode(response.StatusCode, response);

        }

        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            var query = new GetCountriesQuery();
            var response = await _mediator.Send(query);
            if (response.Success)
            {
                return StatusCode(response.StatusCode, response);
            }
            return StatusCode(response.StatusCode, response);

        }
    }
}
