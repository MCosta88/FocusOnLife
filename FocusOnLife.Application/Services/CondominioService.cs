using FocusOnLife.Application.DTOs.Condominio;
using FocusOnLife.Application.Interfaces.Services;
using FocusOnLife.Domain.Entities;
using FocusOnLife.Domain.Interfaces.Repositories;

namespace FocusOnLife.Application.Services
{
    public class CondominioService : ICondominioService
    {
        private readonly ICondominioRepository _condominioRepository;

        public CondominioService(ICondominioRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }

        public async Task<IEnumerable<CondominioDto>> GetAllAsync()
        {
            var condominios = await _condominioRepository.GetAllAsync();
            return condominios.Select(c => new CondominioDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Morada = c.Morada,
                Localidade = c.Localidade,
                CodigoPostal = c.CodigoPostal,
                NumeroFracoes = c.NumeroFracoes,
                NIF = c.NIF
            });
        }

        public async Task<CondominioDto> GetByIdAsync(int id)
        {
            var condominio = await _condominioRepository.GetByIdAsync(id);
            if (condominio == null) return null;

            return new CondominioDto
            {
                Id = condominio.Id,
                Nome = condominio.Nome,
                Morada = condominio.Morada,
                Localidade = condominio.Localidade,
                CodigoPostal = condominio.CodigoPostal,
                NumeroFracoes = condominio.NumeroFracoes,
                NIF = condominio.NIF
            };
        }

        public async Task<bool> CreateAsync(CondominioDto dto)
        {
            var condominio = new Condominio
            {
                Nome = dto.Nome,
                Morada = dto.Morada,
                Localidade = dto.Localidade,
                CodigoPostal = dto.CodigoPostal,
                NumeroFracoes = dto.NumeroFracoes,
                NIF = dto.NIF
            };

            await _condominioRepository.AddAsync(condominio);
            return true;
        }
    }
}
