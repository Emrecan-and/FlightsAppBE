namespace FlightsAppBE.Services
{
    public interface ICacheService
    {
        T Get<T>(string key);
        void Set<T>(string key, T data, int day);
        void Remove(string key);
    }
}
