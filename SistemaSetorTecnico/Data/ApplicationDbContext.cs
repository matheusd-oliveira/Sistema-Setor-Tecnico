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
        public DbSet<Motivo> Motivos { get; set; }
        public DbSet<Localidade> Localidades { get; set; }
        public DbSet<Status> Status { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Recoleta>()
        //        .HasOne(r => r.Status)
        //        .WithMany(rec => rec.Recoleta)
        //        .HasForeignKey(r => r.StatusId)
        //        .HasPrincipalKey(s => s.Id);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
