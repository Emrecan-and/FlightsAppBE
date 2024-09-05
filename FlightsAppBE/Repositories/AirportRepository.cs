using FlightsAppBE.Repository;
using FlightsAppBE.Repository.Models;
using FlightsAppBE.Services;
using Microsoft.EntityFrameworkCore;

namespace FlightsAppBE.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly ICacheService _cacheService;
        private readonly FlightsAppDbContext _context;

        public AirportRepository(ICacheService cacheService, FlightsAppDbContext context)
        {
            _cacheService = cacheService;
            _context = context;
        }

        public async Task<List<Airr>> GetAiportsByCityAndCountry(string city, string country)
        {
            var Airports = await _context.Airrs.Where(x => x.Country == country && x.City==city).ToListAsync();
            return Airports;
        }

        public async Task<List<Airr>> GetAirports()
        {
            var Airports = await _context.Airrs.ToListAsync();
            return Airports;
        }

        public async Task<List<Airr>> GetAirportsByCountry(string country)
        {
            var Airports=await _context.Airrs.Where(x=>x.Country==country).ToListAsync();
            return Airports;
        }

        public async Task<List<string>> GetCitiesByCountry(string country)
        {
            var cacheKey=$"cities_by_country_{country}";
            var cachedData = _cacheService.Get<List<string>>(cacheKey);
            if (cachedData != null)
            {
                return cachedData;
            }
            var cities=await _context.Airrs.Where(a=>a.Country==country).Select(x => x.City).Distinct().ToListAsync();
            if (cities != null)
            {
                _cacheService.Set(cacheKey, cities, 2);
            }
            return cities;
        }

        public async Task<List<string>> GetCountries()
        {
            var cacheKey = "countries";
            var cachedData=_cacheService.Get<List<string>>(cacheKey);
            if (cachedData != null) { 
               return cachedData;
            }
            var countries=await _context.Airrs.Select(x => x.Country).Distinct().ToListAsync();
            if (countries != null)
            {
                _cacheService.Set(cacheKey, countries, 10);
            }
            return countries;
        }
    }
}
