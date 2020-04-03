using System.Collections.Generic;
using System.Threading.Tasks;
using MovieCatalogue.Shared;

namespace MovieCatalogue.Server.Services
{
    public interface IMovieDataService
    {
        Task<RootObject> GetAllMovies(string title);
        Task<Movie> GetMovieDetails(string title);
        Task<Movie> AddMovie(Search title);
        Task UpdateMovie(Movie title);
        Task DeleteMovie(string title);
    }
}
