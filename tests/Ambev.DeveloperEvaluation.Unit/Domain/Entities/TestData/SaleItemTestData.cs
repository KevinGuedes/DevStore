using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleItemTestData
{
    /// <summary>
    /// Generates a valid SaleItem entity with randomized data.
    /// </summary>
    /// <param name="quantity">The amount of items to be generated</param>
    /// <returns>A list of valid items</returns>
    public static List<SaleItem> GenerateValidSaleItem(int quantity = 1) => new Faker<SaleItem>()
        .RuleFor(saleItem => saleItem.SaleId, f => f.Random.Guid())
        .RuleFor(saleItem => saleItem.ProductId, f => f.Random.Guid())
        .RuleFor(saleItem => saleItem.ProductName, f => f.Commerce.ProductName())
        .RuleFor(saleItem => saleItem.Quantity, f => f.Random.Number(1, 20))
        .RuleFor(saleItem => saleItem.UnitPrice, f => f.Random.Decimal(1, 50))
        .RuleFor(saleItem => saleItem.CreatedAt, f => f.Date.Past())
        .Generate(quantity);

    /// <summary>
    /// Generates an invalid SaleItem entity with randomized data.
    /// </summary>
    /// <param name="quantity">The amount of items to be generated</param>
    /// <returns>A list of invalid items</returns>
    public static List<SaleItem> GenerateInvalidSaleItem(int quantity = 1) => new Faker<SaleItem>()
        .RuleFor(saleItem => saleItem.Quantity, f => f.Random.Number(21, 100))
        .RuleFor(saleItem => saleItem.UnitPrice, f => f.Random.Decimal(1, 50))
        .Generate(quantity);
}
