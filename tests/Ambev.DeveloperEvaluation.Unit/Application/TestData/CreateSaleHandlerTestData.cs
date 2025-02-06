using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleHandlerTestData
{
    /// <summary>
    /// Generates valid <see cref="CreateSaleCommand"/>.
    /// </summary>
    /// <returns>A valid <see cref="CreateSaleCommand"/></returns>
    public static CreateSaleCommand GenerateValidCommand(int saleItemsQuantity = 1) => new Faker<CreateSaleCommand>()
        .RuleFor(saleItem => saleItem.Date, f => f.Date.Past())
        .RuleFor(sale => sale.CustomerId, f => f.Random.Guid())
        .RuleFor(sale => sale.CustomerName, f => f.Person.FullName)
        .RuleFor(sale => sale.CustomerEmail, f => f.Person.Email)
        .RuleFor(sale => sale.BranchId, f => f.Random.Guid())
        .RuleFor(sale => sale.BranchName, f => f.Company.CompanyName())
        .RuleFor(sale => sale.Items, _ => GenerateValidSaleItem(saleItemsQuantity));

    /// <summary>
    /// Generates a valid <see cref="CreateSaleItemCommand"> with randomized data.
    /// </summary>
    /// <param name="quantity">The amount of items to be generated</param>
    /// <returns>A list of valid <see cref="CreateSaleItemCommand"></returns>
    public static List<CreateSaleItemCommand> GenerateValidSaleItem(int quantity = 1) => new Faker<CreateSaleItemCommand>()
        .RuleFor(saleItem => saleItem.ProductId, f => f.Random.Guid())
        .RuleFor(saleItem => saleItem.ProductName, f => f.Commerce.ProductName())
        .RuleFor(saleItem => saleItem.Quantity, f => f.Random.Number(1, 20))
        .RuleFor(saleItem => saleItem.UnitPrice, f => f.Random.Decimal(1, 50))
        .Generate(quantity);
}
