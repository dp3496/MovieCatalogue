using System.Collections.Generic;
using System.Threading.Tasks;
using MovieCatalogue.Shared;
namespace MovieCatalogue.Api.Models
{
    public interface IMovieRepository
    {
        IEnumerable<MovieOverview> GetMoviesOverView();
        Task<MovieOverview> GetMovieById(string title);
        void AddMovie(MovieOverview movie);
        Task DeleteMovie(string title);
    }
}
