namespace Weatherapp.Services
{
    public interface IHttpService
    {
        Task<string> DeleteData(string location);
        Task<T> GetData<T>(T value, string baseURL);
        Task<string> PostData<T>(T value, string location);
    }
}