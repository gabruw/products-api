using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Codigo);
            builder.HasOne(o => o.Order_Customer).WithMany(c => c.Customer_Orders).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(o => o.Order_Products).WithOne(p => p.Product_Order).OnDelete(DeleteBehavior.SetNull);
            builder.Property(o => o.Data).IsRequired().HasColumnType("DATETIME");
        }
    }
}
