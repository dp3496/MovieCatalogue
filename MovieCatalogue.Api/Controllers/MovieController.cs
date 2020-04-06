using MovieCatalogue.Api.Models;
using MovieCatalogue.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.ComponentModel;

namespace MovieCatalogue.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private const string V = "calling get all movies";
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet("movies")]
        public IActionResult GetAllMovies()
        {
            return Ok(_movieRepository.GetMoviesOverView());
        }

        [HttpGet("movies/{title}")]
        public IActionResult GetMovieByTitle(string title)
        {
            return Ok(_movieRepository.GetMovieById(title));
        }

        [HttpPost("movies")]
        public IActionResult AddMovie([FromBody] MovieOverview movieOverview)
        {
            if (movieOverview == null)
                return BadRequest();

            if (movieOverview.Title == string.Empty)
            {
                ModelState.AddModelError("Title", "The Title shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _movieRepository.AddMovie(movieOverview);

            return Ok();
        }

        
        public IActionResult DeleteMovie([FromBody] MovieOverview movieOverview)
        {
            return Ok(_movieRepository.DeleteMovie(movieOverview.Title));
        }
    }
}
