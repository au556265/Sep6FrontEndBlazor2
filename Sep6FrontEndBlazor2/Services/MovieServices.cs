using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Sep6FrontEndBlazor2.DomainClasses;

namespace Sep6FrontEndBlazor2.Services;

public class MovieServices
{
    private readonly HttpClient _client = new HttpClient();
    private string path = "https://localhost:5001";
        
    public async Task<List<Movie>> GetMostPopularMoviesAsync()
    {
        HttpResponseMessage response = await _client.GetAsync($"{path}/Movie/getMostPopularMovies");
        if (response.IsSuccessStatusCode)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            return await System.Text.Json.JsonSerializer.DeserializeAsync<List<Movie>>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });
        }

        throw new Exception(response.Content.ReadAsStringAsync().Result);
    }

    public async Task<List<Movie>> get5MoviesBySearchAsync(string movieTittle)
    {
        HttpResponseMessage response = await _client.GetAsync($"{path}/Movie/get5MoviesBySearch/{movieTittle}");
        if (response.IsSuccessStatusCode)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            return await System.Text.Json.JsonSerializer.DeserializeAsync<List<Movie>>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });
        }

        throw new Exception(response.Content.ReadAsStringAsync().Result);
        
    }
    
    public async Task<Movie> getMovieAsync(int id)
    {
        HttpResponseMessage response = await _client.GetAsync($"{path}/Movie/getMovie/{id}");
        if (response.IsSuccessStatusCode)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            return await System.Text.Json.JsonSerializer.DeserializeAsync<Movie>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });
        }

        throw new Exception(response.Content.ReadAsStringAsync().Result);
        
    }
}
