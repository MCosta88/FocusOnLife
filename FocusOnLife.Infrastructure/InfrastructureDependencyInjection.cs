using FocusOnLife.Infrastructure.Data;
using FocusOnLife.Infrastructure.Repositories;
using FocusOnLife.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FocusOnLife.Domain.Interfaces.Repositories;
using FocusOnLife.Application.Interfaces.Services;  // Adicionado para resolver IAuthService

namespace FocusOnLife.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArxDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}