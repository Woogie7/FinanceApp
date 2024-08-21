namespace Finance.Application.Interface;

public interface ICacheService
{
    T GetData<T>(string key);
    bool SetData<T>(string key, T value, DateTimeOffset timeOfDeath);
    object RemoveData(string key);
}
