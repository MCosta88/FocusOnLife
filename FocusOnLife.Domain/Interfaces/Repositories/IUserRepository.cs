using FocusOnLife.Domain.Entities.Auth;

namespace FocusOnLife.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task<User> GetUserByIdAsync(int id); // Adicionado para buscar usuário pelo ID
    }
}
