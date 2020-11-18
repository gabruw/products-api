using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Codigo);
            builder.HasOne(p => p.Product_Order).WithMany(o => o.Order_Products).OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex(p => p.CodigoBarras).IsUnique();
            builder.Property(p => p.CodigoBarras).IsRequired().HasColumnType("VARCHAR(255)");
            builder.Property(p => p.Descricao).IsRequired().HasColumnType("VARCHAR(255)");
            builder.Property(p => p.Valor).IsRequired().HasColumnType("DOUBLE");
        }
    }
}
