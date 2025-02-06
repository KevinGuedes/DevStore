using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Integration.TestData;

public static class SaleTestData
{
    private const int DEFAULT_SALE_SEED = 1;

    public static Sale GetDefaultSale()
    {
        var defaultTestUser = UserTestData.GetDefaultUser();

        return new Faker<Sale>()
            .RuleFor(sale => sale.Number, f => f.Random.Number())
            .RuleFor(sale => sale.Id, f => f.Random.Guid())
            .RuleFor(sale => sale.Date, f => f.Date.Past())
            .RuleFor(sale => sale.CustomerId, _ => defaultTestUser.Id)
            .RuleFor(sale => sale.CustomerName, _ => defaultTestUser.Username)
            .RuleFor(sale => sale.CustomerEmail, _ => defaultTestUser.Email)
            .RuleFor(sale => sale.BranchId, f => f.Random.Guid())
            .RuleFor(sale => sale.BranchName, f => f.Company.CompanyName())
            .RuleFor(sale => sale.Items, f => SaleItemTestData.GetDefaultSaleItem())
            .UseSeed(DEFAULT_SALE_SEED);
    }

    public static CreateSaleRequest CreateValidSaleRequest(int saleItemsQuantity = 1)
        => new Faker<CreateSaleRequest>()
            .RuleFor(saleItem => saleItem.Date, f => f.Date.Past())
            .RuleFor(sale => sale.CustomerId, f => f.Random.Guid())
            .RuleFor(sale => sale.CustomerName, f => f.Person.FullName)
            .RuleFor(sale => sale.CustomerEmail, f => f.Person.Email)
            .RuleFor(sale => sale.BranchId, f => f.Random.Guid())
            .RuleFor(sale => sale.BranchName, f => f.Company.CompanyName())
            .RuleFor(sale => sale.Items, f => SaleItemTestData.CreateValidSaleItemRequest(saleItemsQuantity));
}
