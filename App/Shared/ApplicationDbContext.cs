using Backend.App.Modules.Producto.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.App.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ProductoEntity> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoEntity>(entity => {
                entity.ToTable("productos"); // Regla estricta: minúsculas
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Precio).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Stock).IsRequired();
            });
        }
    }
}