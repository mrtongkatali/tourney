using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tourney.api.Dtos.Tournament;
using tourney.api.Extensions;
using tourney.api.Helpers;
using tourney.api.Repositories;
using tourney.api.Mappers;
using api.Helpers;

namespace tourney.api.Controllers
{
    [ApiController]
    [Route("api/tournament")]
    public class Tournament : ControllerBase
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly int _sessionUserId;
        public Tournament(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
            _sessionUserId = HttpContext.User.GetClaimValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTournamentById(int id)
        {
            var userId = HttpContext.User.GetClaimValue(ClaimTypes.NameIdentifier);
            var tournament = await _tournamentRepository.GetByIdAsync(id, userId);

            if (tournament == null) {
                return BadRequest(ApiResponseHelper.Error("Tournament not found"));
            }

            return Ok(ApiResponseHelper.Success(tournament, "success"));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreatePatchTourneyDto request)
        {
            if (ModelState.IsValid == false)
            {
                var errorDetailed = ModelStateHelper.GetFieldErrors(ModelState);
                return BadRequest(ApiResponseHelper.Error<string>("", errorDetailed));
            }

            var tournamentRequest = request.ToModel();
            tournamentRequest.UserId = _sessionUserId;

            await _tournamentRepository.Create(tournamentRequest);

            return CreatedAtAction(nameof(GetTournamentById), new { id = tournamentRequest.Id }, ApiResponseHelper.Success(
                tournamentRequest.AsPartialResponse(),
                "Tournament created successfully"
            ));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreatePatchTourneyDto request)
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