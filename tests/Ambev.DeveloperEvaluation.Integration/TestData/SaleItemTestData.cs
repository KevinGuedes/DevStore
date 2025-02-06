using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Integration.TestData;

public static class SaleItemTestData
{
    private const int DEFAULT_SALE_ITEM_SEED = 1;

    public static List<SaleItem> GetDefaultSaleItem()
        => new Faker<SaleItem>()
        .RuleFor(saleItem => saleItem.Id, f => f.Random.Guid())
        .RuleFor(saleItem => saleItem.ProductId, f => f.Random.Guid())
        .RuleFor(saleItem => saleItem.ProductName, f => f.Commerce.ProductName())
        .RuleFor(saleItem => saleItem.Quantity, f => f.Random.Number(1, 20))
        .RuleFor(saleItem => saleItem.UnitPrice, f => f.Random.Decimal(1, 50))
        .RuleFor(saleItem => saleItem.CreatedAt, f => f.Date.Past())
        .UseSeed(DEFAULT_SALE_ITEM_SEED)
        .Generate(2);

    public static List<CreateSaleItemRequest> CreateValidSaleItemRequest(int quantity = 1)
        => new Faker<CreateSaleItemRequest>()
        .RuleFor(saleItem => saleItem.ProductId, f => f.Random.Guid())
        .RuleFor(saleItem => saleItem.ProductName, f => f.Commerce.ProductName())
        .RuleFor(saleItem => saleItem.Quantity, f => f.Random.Number(1, 20))
        .RuleFor(saleItem => saleItem.UnitPrice, f => f.Random.Decimal(1, 50))
        .Generate(quantity);
}
