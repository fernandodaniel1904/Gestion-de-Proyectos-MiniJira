using Gestion_de_Proyectos_MiniJira.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Proyectos_MiniJira.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto> Proyectos { get; set; } = default!;
        public DbSet<Tarea> Tareas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Proyecto
            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.HasMany(e => e.Tareas)
                    .WithOne(t => t.Proyecto)
                    .HasForeignKey(t => t.ProyectoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de Tarea
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.ProyectoId).IsRequired();
            });
        }
    }
}
