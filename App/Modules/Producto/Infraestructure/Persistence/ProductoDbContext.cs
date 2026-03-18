using Backend.App.Modules.Producto.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.App.Modules.Producto.Infrastructure.Persistence
{
    public class ProductoDbContext : DbContext
    {
        public ProductoDbContext(DbContextOptions<ProductoDbContext> options) : base(options) { }

        public DbSet<ProductoEntity> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoEntity>(entity => {
                entity.ToTable("productos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Precio).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Stock).IsRequired();
            });
        }
    }
}