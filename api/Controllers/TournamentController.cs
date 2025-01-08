using Microsoft.AspNetCore.Mvc;
using tourney.api.Dtos.Tournament;

namespace tourney.api.Controllers
{
    [ApiController]
    [Route("api/tournament")]
    public class Tournament : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetTournamentById(int id)
        {
            return Ok($"Get tournament with id {id}");
        }

        [HttpPost]
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