using FlightsAppBE.Repository;
using Microsoft.Extensions.Caching.Memory;

namespace FlightsAppBE.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache, FlightsAppDbContext context)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
        {
            _memoryCache.TryGetValue(key, out T data);
            return data;
        }

        public void Set<T>(string key, T data, int day)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromDays(day));

            _memoryCache.Set(key, data, cacheEntryOptions);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

    }
}
