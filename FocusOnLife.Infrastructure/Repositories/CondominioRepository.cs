using FocusOnLife.Domain.Entities;
using FocusOnLife.Domain.Interfaces.Repositories;
using FocusOnLife.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FocusOnLife.Infrastructure.Repositories
{
    public class CondominioRepository : ICondominioRepository
    {
        private readonly ArxDbContext _context;

        public CondominioRepository(ArxDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Condominio>> GetAllAsync()
        {
            return await _context.Condominios.ToListAsync();
        }

        public async Task<Condominio> GetByIdAsync(int id)
        {
            return await _context.Condominios.FindAsync(id);
        }

        // ✅ Implementação do método AddAsync para resolver o erro
        public async Task AddAsync(Condominio condominio)
        {
            await _context.Condominios.AddAsync(condominio);
            await _context.SaveChangesAsync();
        }
    }
}