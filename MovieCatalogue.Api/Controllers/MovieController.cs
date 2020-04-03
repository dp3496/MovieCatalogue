using MovieCatalogue.Api.Models;
using MovieCatalogue.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MovieCatalogue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult GetAllMovies(string title)
        {
            return Ok(_movieRepository.GetAllMovies(title));
        }

        [HttpGet("{title}")]
        public IActionResult GetMovieByTitle(string id)
        {
            return Ok(_movieRepository.GetMovieById(id));
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Movie movie)
        {
            if (movie == null)
                return BadRequest();

            if (movie.Title == string.Empty)
            {
                ModelState.AddModelError("Title", "The Title shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addedMovie = _movieRepository.AddMovie(movie);

            return Created("movie", addedMovie);
        }
    }
}
