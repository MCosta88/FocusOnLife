using FocusOnLife.Domain.Entities;
using FocusOnLife.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace FocusOnLife.Infrastructure.Data
{
    public class ArxDbContext : DbContext
    {
        public ArxDbContext(DbContextOptions<ArxDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Condominio> Condominios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArxDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}