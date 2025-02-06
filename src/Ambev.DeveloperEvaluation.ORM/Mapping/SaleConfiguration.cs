using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(sale => sale.Id);
        builder.Property(sale => sale.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.HasIndex(sale => sale.Number).IsUnique();
        builder.Property(sale => sale.Date).IsRequired();
        builder.Property(sale => sale.CustomerName).HasMaxLength(50).IsRequired();
        builder.Property(sale => sale.CustomerEmail).IsRequired();
        builder.Property(sale => sale.BranchName).IsRequired();
        //We should have a proper relation for Branch and Sales, but since this is not in the scope of the challenge, i'm just doing basic mapping
        builder.Property(sale => sale.BranchId).IsRequired();
        builder.Property(sale => sale.IsCancelled).IsRequired();
        builder.Property(sale => sale.CreatedAt).IsRequired();

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(sale => sale.CustomerId);

        builder.HasMany(sale => sale.Items)
               .WithOne()
               .HasForeignKey(saleItem => saleItem.SaleId);
    }
}
