using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(saleItem => saleItem.Id);
        builder.Property(saleItem => saleItem.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        // We would need a proper relation between Sale and Product, but since this is not in the scope of the challenge, i'm just doing basic mapping 
        builder.Property(saleItem => saleItem.ProductId).IsRequired().HasColumnType("uuid");
        builder.Property(saleItem => saleItem.ProductName).IsRequired().HasMaxLength(100);
        builder.Property(saleItem => saleItem.Quantity).IsRequired();
        builder.Property(saleItem => saleItem.Discount).IsRequired();
        builder.Property(saleItem => saleItem.UnitPrice).IsRequired().HasColumnType("money");
        builder.Property(sale => sale.CreatedAt).IsRequired();
    }
}
