using System.Collections.Generic;
using System.Threading.Tasks;
using FocusOnLife.Application.DTOs.Condominio;

namespace FocusOnLife.Application.Interfaces.Services
{
    public interface ICondominioService
    {
        Task<IEnumerable<CondominioDto>> GetAllAsync();
        Task<CondominioDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CondominioDto condominio);
    }
}