using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieCatalogue.Shared;

namespace MovieCatalogue.Api.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies(string title);
        Movie GetMovieById(string title);
        Movie AddMovie(Movie movie);
        Movie UpdateMovie(Movie employee);
        void DeleteMovie(string employeeId);
    }
}
