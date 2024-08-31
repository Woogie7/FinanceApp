using Finance.Application.Interface.Cache;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Finance.Application.Service
{
    public class CacheService : ICacheService
    {
        private IDatabase _cacheDb;

        public CacheService(IConfiguration configuration)
        {
            var redisConnectionString = configuration.GetConnectionString("Cache");
            var redis = ConnectionMultiplexer.Connect(redisConnectionString);
            _cacheDb = redis.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
           var value = await _cacheDb.StringGetAsync(key);
            if (!string.IsNullOrEmpty(value))
            {
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };

                return JsonSerializer.Deserialize<T>(value, options);
            }
            return default;
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> factory, DateTimeOffset expirationTime)
        {
            var cachedData = await GetAsync<T>(key);
            if (cachedData != null) 
                return cachedData;

            cachedData = await factory();

            await SetAsync<T>(key, cachedData, expirationTime);

            return cachedData;
        }

        public async Task<bool> RemoveAsync(string key)
        {
            var exist = await _cacheDb.KeyExistsAsync(key);

            if (exist)
                return _cacheDb.KeyDelete(key);

            return false;
        }

        public async Task<bool> SetAsync<T>(string key, T value, DateTimeOffset timeOfDeath)
        {
            var experetyTime = timeOfDeath.DateTime.Subtract(DateTime.Now);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            return await _cacheDb.StringSetAsync(key, JsonSerializer.Serialize<T>(value, options), experetyTime);
        }
    }
}
