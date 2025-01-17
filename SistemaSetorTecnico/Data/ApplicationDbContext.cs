using Microsoft.EntityFrameworkCore;
using SistemaSetorTecnico.Models;

namespace SistemaSetorTecnico.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Recoleta> Recoletas { get; set; }
    }
}
