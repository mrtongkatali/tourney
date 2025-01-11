using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tourney.api.Dtos.Tournament;
using tourney.api.Repositories;

namespace tourney.api.Controllers
{
    [ApiController]
    [Route("api/tournament")]
    public class Tournament : ControllerBase
    {
        private readonly ITournamentRepository _tournamentRepository;
        public Tournament(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetTournamentById(int id)
        {
            return Ok($"Get tournament with id {User.FindFirst(ClaimTypes.NameIdentifier)?.Value}");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] CreateTourneyDto request)
        {
            return Ok("Create a new tournament");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok($"Update tournament with id {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Delete tournament with id {id}");
        }

        [HttpPost("publish/{id}")]
        public IActionResult Publish(int id)
        {
            return Ok($"Update tournament with id {id}");
        }

        [HttpGet("{id}/teams")]
        public IActionResult GetSignedTeams(int id)
        {
            return Ok($"Get teams for tournament with id {id}");
        }
    }
}