using Microsoft.EntityFrameworkCore;
using CasoPractico1_PrograAvanzada.Models;

namespace CasoPractico1_PrograAvanzada.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos => Set<Producto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurarProductos(modelBuilder);
        }

        private static void ConfigurarProductos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos", t =>
                {
                    t.HasCheckConstraint("CK_Productos_Precio", "[Precio] > 0");
                    t.HasCheckConstraint("CK_Productos_Existencia", "[Existencia] BETWEEN 0 AND 9999");
                    t.HasCheckConstraint("CK_Productos_UnidadMedida", "[UnidadMedida] IN (1, 2, 3)");
                });

                entity.Property(p => p.Precio).HasPrecision(18, 2);

                // 3 decimales para kilogramos y litros.
                entity.Property(p => p.Existencia).HasPrecision(10, 3);

                entity.HasIndex(p => p.Codigo).IsUnique();
                entity.HasIndex(p => p.Nombre);
            });
        }

    }
}
