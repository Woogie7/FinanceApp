namespace Finance.Application.Interface;

public interface ICacheService
{
    Task<T> GetAsync<T>(string key);
    Task<T> GetAsync<T>(string key, Func<Task<T>> fetchData, DateTimeOffset expirationTime);
    Task<bool> SetAsync<T>(string key, T value, DateTimeOffset timeOfDeath);
    Task<bool> RemoveAsync(string key);
}
