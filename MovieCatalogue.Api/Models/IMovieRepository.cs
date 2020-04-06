using System.Collections.Generic;
using System.Threading.Tasks;
using MovieCatalogue.Shared;
namespace MovieCatalogue.Api.Models
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieOverview>> GetMoviesOverView();
        Task<MovieOverview> GetMovieById(string title);
        Task AddMovieAsync(MovieOverview movie);
        Task DeleteMovie(string title);
    }
}
