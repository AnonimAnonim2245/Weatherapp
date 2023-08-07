
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace Weatherapp.Services;

public class HttpService : IHttpService
{
    public string BaseURL = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/monkeydata.json";
    private HttpClient _client;

    public HttpService()
    {
        _client = new HttpClient();
    }

    public async Task<T> GetData<T>(T value, string baseURL)
    {
        // daca necesita autorizare 
        //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{token}");

        try
        {
            HttpResponseMessage response = await _client.GetAsync(baseURL);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                value = JsonConvert.DeserializeObject<T>(content);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return value;
    }

    public async Task<string> PostData<T>(T value, string location)
    {
        // daca necesita autorizare 
        //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{token}");
        string cont = string.Empty;
        try
        {
            var serializedJsonRequest = JsonConvert.SerializeObject(value);
            HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(new Uri($"{BaseURL}{location}"), content);

            if (response.IsSuccessStatusCode)
            {
                cont = await response.Content.ReadAsStringAsync();
                return cont;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            cont = $"ERROR {ex.Message}";
        }

        return cont;
    }

    public async Task<string> DeleteData(string location)
    {
        // daca necesita autorizare 
        //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{token}");
        string cont = string.Empty;

        try
        {
            HttpResponseMessage response = await _client.DeleteAsync(new Uri($"{BaseURL}{location}"));

            if (response.IsSuccessStatusCode)
            {
                cont = await response.Content.ReadAsStringAsync();
                return cont;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            cont = $"ERROR {ex.Message}";
        }

        return cont;
    }
}
