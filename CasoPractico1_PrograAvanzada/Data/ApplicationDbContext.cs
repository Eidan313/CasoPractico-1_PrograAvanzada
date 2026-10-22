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

        // Una sola tabla para productos por unidad y por peso; TipoVenta los distingue.
        private static void ConfigurarProductos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos", t =>
                {
                    t.HasCheckConstraint("CK_Productos_Precio", "[Precio] > 0");
                    t.HasCheckConstraint("CK_Productos_Existencia", "[Existencia] BETWEEN 0 AND 9999");
                    t.HasCheckConstraint("CK_Productos_TipoVenta", "[TipoVenta] IN (1, 2)");
                });

                entity.Property(p => p.Precio).HasPrecision(18, 2);

                // 3 decimales para los productos por peso (gramos).
                entity.Property(p => p.Existencia).HasPrecision(10, 3);

                entity.HasIndex(p => p.Codigo).IsUnique();
                entity.HasIndex(p => p.Nombre);

                entity.Ignore(p => p.UnidadMedida);
            });
        }
    }
}
