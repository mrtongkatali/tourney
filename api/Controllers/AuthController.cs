using tourney.api.Dtos.Auth;
using tourney.api.Mappers;
using Microsoft.AspNetCore.Mvc;
using tourney.api.Repositories;
using tourney.api.Services;

namespace tourney.api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase 
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
        public AuthController(ILogger<AuthController> logger, IUserRepository userRepository, JwtService jwtService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var dto = users.Select(s => s.AsPartialResponse());

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.AsPartialResponse());
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto request)
        {
            if (request.Password != request.confirmPassword)
            {
                ModelState.AddModelError("Confirm Password", "Password and Confirm Password do not match.");
            }

            if (await _userRepository.CheckEmailUnique(request.Email) == false) {
                ModelState.AddModelError("Email", "Email already exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userRequest = request.ToModel();

            await _userRepository.Create(userRequest, "");

            return CreatedAtAction(nameof(GetById), new { id = userRequest.Id }, userRequest.AsPartialResponse()); 
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            var user = await _userRepository.Authenticate(request.Email, request.Password);

            if (user == null)
            {
                return BadRequest("Invalid email address or password");
            }

            string token = _jwtService.GenerateToken(user.Email);

            return Ok(new {
                Token = token,
                Data = user.AsPartialResponse()
            });
        }
    }
}