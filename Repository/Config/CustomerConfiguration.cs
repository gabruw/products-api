using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Codigo);
            builder.HasMany(c => c.Customer_Orders).WithOne(o => o.Order_Customer).OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex(c => c.Cpf).IsUnique();
            builder.Property(c => c.Cpf).IsRequired().HasColumnType("VARCHAR(14)");
            builder.Property(c => c.Nome).IsRequired().HasColumnType("VARCHAR(255)");
            builder.Property(c => c.Senha).IsRequired().HasColumnType("VARCHAR(40)");
            builder.Property(c => c.DataNascimento).IsRequired().HasColumnType("DATETIME");
        }
    }
}
