using FocusOnLife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusOnLife.Domain.Interfaces.Repositories
{
    public interface ICondominioRepository
    {
        Task<IEnumerable<Condominio>> GetAllAsync();
        Task<Condominio> GetByIdAsync(int id);
        Task AddAsync(Condominio condominio);
    }
}
