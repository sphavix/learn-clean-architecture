using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Movies.Application.Commands;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Entities;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieResponse>>> GetMovies()
        {
            var movies = new GetMoviesQuery();
            var result = await _mediator.Send(movies);
            return Ok(result);
        } 
        
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieResponse>> GetMovie(Guid id)
        {
            var movie = new GetMovieByIdQuery(id);
            var result = await _mediator.Send(movie);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieResponse>> CreateMovie([FromBody] CreateMovieCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand command)
        {
            var movie = await _mediator.Send(command);
            return Ok(movie);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var result = await _mediator.Send(new DeleteMovieCommand { Id = id });
            return Ok(result);
        }
    }
}