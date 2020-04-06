using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieCatalogue.Shared;

namespace MovieCatalogue.Server.Services
{
    public class MovieDataService: IMovieDataService
    {
        private readonly HttpClient _httpClient;

        public MovieDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MoviesOverview> GetAllMatchingMovies(string title)
        {
            return await JsonSerializer.DeserializeAsync<MoviesOverview>
                (await _httpClient.GetStreamAsync($"http://www.omdbapi.com/?apikey=e8fce7a8&s={title}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<MovieDetails> GetMovieDetails(string title)
        {
            return await JsonSerializer.DeserializeAsync<MovieDetails>
                (await _httpClient.GetStreamAsync($"http://www.omdbapi.com/?apikey=e8fce7a8&t={title}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<MovieDetails> AddMovie(MovieOverview movie)
        {
            var movieDetails = GetMovieDetails(movie.Title).Result;

            var movieJson =
                new StringContent(JsonSerializer.Serialize(movieDetails), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/employee", movieJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<MovieDetails>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateMovie(MovieDetails movie)
        {
            var employeeJson =
                new StringContent(JsonSerializer.Serialize(movie), Encoding.UTF8, "application/json");
           
            await _httpClient.PutAsync("api/employee", employeeJson);
        }

        public async Task DeleteMovie(string title)
        {
            await _httpClient.DeleteAsync($"api/employee/{title}");
        }

        public async Task<IEnumerable<MovieOverview>> GetAllMovies()
        {
            string title = "logan";
            return (await JsonSerializer.DeserializeAsync<MoviesOverview>
                (await _httpClient.GetStreamAsync($"http://www.omdbapi.com/?apikey=e8fce7a8&s={title}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })).Search;
        }
    }
}
