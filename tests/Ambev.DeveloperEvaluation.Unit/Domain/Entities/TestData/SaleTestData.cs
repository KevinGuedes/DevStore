using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    /// <summary>
    /// Generates valid <see cref="Sale"/> entities.
    /// </summary>
    /// <returns>A valid sale</returns>
    public static Sale GenerateValidSale(int saleItemsQuantity = 1) => new Faker<Sale>()
        .RuleFor(sale => sale.Id, f => f.Random.Guid())
        .RuleFor(sale => sale.Number, f => f.Random.Number(1, 100))
        .RuleFor(saleItem => saleItem.Date, f => f.Date.Past())
        .RuleFor(sale => sale.CustomerId, f => f.Random.Guid())
        .RuleFor(sale => sale.CustomerName, f => f.Person.FullName)
        .RuleFor(sale => sale.CustomerEmail, f => f.Person.Email)
        .RuleFor(sale => sale.BranchId, f => f.Random.Guid())
        .RuleFor(sale => sale.BranchName, f => f.Company.CompanyName())
        .RuleFor(sale => sale.Items, f => SaleItemTestData.GenerateValidSaleItem(saleItemsQuantity))
        .RuleFor(saleItem => saleItem.CreatedAt, f => f.Date.Past());

    /// <summary>
    /// Generates an invalid <see cref="Sale"> entity with randomized data.
    /// </summary>
    /// <returns>A invalid sale</returns>
    public static Sale GenerateInvalidSale() => new Faker<Sale>()
        .RuleFor(sale => sale.Number, _ => 0)
        .RuleFor(saleItem => saleItem.Date, f => f.Date.Future())
        .RuleFor(sale => sale.Items, _ => []);
}
