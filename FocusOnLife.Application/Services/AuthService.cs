using FocusOnLife.Application.DTO.Auth;
using FocusOnLife.Domain.Entities.Auth;
using FocusOnLife.Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using IAuthService = FocusOnLife.Application.Interfaces.Services.IAuthService;
using FocusOnLife.Domain.Interfaces.Repositories;

namespace FocusOnLife.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly string _jwtSecret;
        private readonly int _jwtExpirationHours;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _jwtSecret = configuration["JwtSettings:Secret"] ?? throw new ArgumentNullException("JWT Secret não configurado.");
            _jwtExpirationHours = int.Parse(configuration["JwtSettings:ExpirationHours"] ?? "2");
        }

        public async Task<AuthResponseDto> AuthenticateAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null || !VerifyPasswordHash(request.Password, user.PasswordHash))
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Errors = new[] { "Credenciais inválidas." }
                };
            }

            var token = GenerateJwtToken(user);
            return new AuthResponseDto
            {
                Success = true,
                Token = token,
                Role = user.Role.ToString()
            };
        }

        public async Task<AuthResponseDto> RegisterUserAsync(RegisterUserDto request)
        {
            // Aqui você pode implementar a lógica de registro do usuário.
            // Para este exemplo, vamos supor que o registro foi realizado com sucesso.
            // Crie um novo objeto User e calcule o hash da senha.

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = ComputeHash(request.Password),
                Role = Enum.Parse<UserRoles>(request.Role, true)
            };

            await _userRepository.AddUserAsync(user);

            var token = GenerateJwtToken(user);
            return new AuthResponseDto
            {
                Success = true,
                Token = token,
                Role = user.Role.ToString()
            };
        }

        public async Task<UserDto> GetCurrentUserAsync(ClaimsPrincipal userClaims)
        {
            var userIdClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return null;

            int userId = int.Parse(userIdClaim.Value);
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(_jwtExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            using var sha256 = SHA256.Create();
            var computedHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return computedHash == storedHash;
        }

        private string ComputeHash(string password)
        {
            using var sha256 = SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}
