using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using tourney.Repositories;

namespace api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase 
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepository _userRepository;
        public AuthController(ILogger<AuthController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> HelloWorld()
        {
            var users = await _userRepository.GetAllAsync();
            var dto = users.Select(s => s.AsPartialResponse());

            return Ok(dto);
        }

        // [HttpPost]
        // [Route("register")]
        // public IActionResult Register([FromBody] RegisterRequest request)
        // {
        //     var user = _userRepository.Register(request);
        //     return Ok(user);
        // }

    }
}