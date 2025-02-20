using FocusOnLife.Application.DTOs;
using FocusOnLife.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FocusOnLife.Application.DTO.Auth;


namespace FocusOnLife.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
        {
            var result = await _authService.RegisterUserAsync(model);
            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok(new { message = "Usuário registrado com sucesso!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _authService.LoginAsync(model);
            if (!result.Success)
                return Unauthorized(new { message = "Credenciais inválidas." });

            return Ok(new { token = result.Token });
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            var userInfo = await _authService.GetCurrentUserAsync(User);
            return Ok(userInfo);
        }
    }
}