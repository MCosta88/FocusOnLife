using FocusOnLife.Domain.Entities.Auth;
using FocusOnLife.Domain.Interfaces.Repositories;
using FocusOnLife.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FocusOnLife.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ArxDbContext _context;

        public UserRepository(ArxDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}