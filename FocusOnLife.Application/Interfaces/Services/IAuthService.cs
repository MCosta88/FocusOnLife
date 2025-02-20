using FocusOnLife.Application.DTOs;
using System.Security.Claims;
using System.Threading.Tasks;
using FocusOnLife.Application.DTO.Auth;

namespace FocusOnLife.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> AuthenticateAsync(LoginRequestDto request);
        Task<AuthResponseDto> RegisterUserAsync(RegisterUserDto request);
        Task<UserDto> GetCurrentUserAsync(ClaimsPrincipal userClaims);
    }
}