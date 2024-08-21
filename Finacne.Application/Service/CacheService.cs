using Finance.Application.Interface;
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

        public T GetData<T>(string key)
        {
           var value = _cacheDb.StringGet(key);
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

        public object RemoveData(string key)
        {
            var exist = _cacheDb.KeyExists(key);

            if (exist)
                return _cacheDb.KeyDelete(key);

            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset timeOfDeath)
        {
            var experetyTime = timeOfDeath.DateTime.Subtract(DateTime.Now);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            return _cacheDb.StringSet(key, JsonSerializer.Serialize<T>(value, options), experetyTime);
        }
    }
}
