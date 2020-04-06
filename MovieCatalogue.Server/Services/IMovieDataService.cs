using System.Collections.Generic;
using System.Threading.Tasks;
using MovieCatalogue.Shared;

namespace MovieCatalogue.Server.Services
{
    public interface IMovieDataService
    {
        Task<IEnumerable<MovieOverview>> GetAllMovies();
        Task<MoviesOverview> GetAllMatchingMovies(string title);
        Task<MovieDetails> GetMovieDetails(string title);
        Task<MovieDetails> AddMovie(MovieOverview title);
        Task DeleteMovie(string title);
    }
}
