using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Commands;
using Movies.Application.Queries;
using Movies.Application.Responses;

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
        public async Task<ActionResult<IEnumerable<MovieResponse>>> GetMoviesByDirectorName(string name)
        {
            var query = new GetMoviesByDirectorNameQuery(name);
            var movies = await _mediator.Send(query);
            return Ok(movies);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieResponse>> CreateMovie([FromBody] CreateMovieCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}