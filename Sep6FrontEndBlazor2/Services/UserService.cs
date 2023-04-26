using System.Text;
using System.Text.Json;
using Sep6FrontEndBlazor2.DomainClasses;

namespace Sep6FrontEndBlazor2.Services;

public class UserService
{
    private readonly HttpClient _client = new HttpClient();
    private string path = "https://localhost:5001";
    
    public async Task setMovieRatingAsync(string userName,int movieId, int rating)
    {
        RatingObject ratingObject = new RatingObject();
        ratingObject.Username = userName;
        ratingObject.MovieId = movieId;
        ratingObject.Rating = rating;
        
        using StringContent jsonContent = new(
            JsonSerializer.Serialize( ratingObject),
            Encoding.UTF8,
            "application/json");
        
        HttpResponseMessage response = await _client.PostAsync($"{path}/User/setMovieRating",jsonContent);
        if (response.IsSuccessStatusCode)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
        }

        throw new Exception(response.Content.ReadAsStringAsync().Result);
        
    }
    public async Task<int> getMovieRatingAsync(string userName,int movieId)
    {
   
        HttpResponseMessage response = await _client.GetAsync($"{path}/User/getMovieRating/{userName}/{movieId}");
        if (response.IsSuccessStatusCode)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            return await System.Text.Json.JsonSerializer.DeserializeAsync<int>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });
        }

        throw new Exception(response.Content.ReadAsStringAsync().Result);
        
    }

    public async Task<bool> getFavoriteMovieAsync(string userName, int movieId)
    {
        HttpResponseMessage response = await _client.GetAsync($"{path}/User/getFavoriteMovie/{userName}/{movieId}");
        if (response.IsSuccessStatusCode)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            return await System.Text.Json.JsonSerializer.DeserializeAsync<bool>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });
        }

        throw new Exception(response.Content.ReadAsStringAsync().Result);
    }

    public async Task setMovieFavoriteAsync(string userName, int movieId, int favorit)
    {
        RatingObject ratingObject = new RatingObject();
        ratingObject.Username = userName;
        ratingObject.MovieId = movieId;
        ratingObject.Favorit = favorit;
        
        using StringContent jsonContent = new(
            JsonSerializer.Serialize( ratingObject),
            Encoding.UTF8,
            "application/json");
        
        HttpResponseMessage response = await _client.PostAsync($"{path}/User/setFavoriteMovie",jsonContent);
        if (response.IsSuccessStatusCode)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
        }

        throw new Exception(response.Content.ReadAsStringAsync().Result);
    }
}