using FlightsAppBE.Repository.Models;

namespace FlightsAppBE.Repositories
{
    public interface IAirportRepository
    {
        Task<List<string>> GetCountries();

        Task<List<string>> GetCitiesByCountry(string country);

        Task<List<Airr>> GetAirports();

        Task<List<Airr>> GetAirportsByCountry(string country);

        Task<List<Airr>> GetAiportsByCityAndCountry(string city,string country);

    }
}
