using Ambev.DeveloperEvaluation.Domain.Validation;

using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

/// <summary>
/// Validator for <see cref="CreateSaleRequest"/> that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleRequestValidator"/> with defined validation rules.
    /// </summary>
    /// /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">SaleDate: Must not be in the future</list>
    /// <list type="bullet">CustomerId and BranchId: Should both be valid</list>
    /// <list type="bullet">CustomerName and BranchName: Must both be within 3 to 50 characters (inclusive)</list>
    /// <list type="bullet">Items: Must not be empty and each item must be validated by <see cref="SaleItemRequestValidator"/></list>
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.Date)
            .NotEmpty().WithMessage("Sale date is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Sale date cannot be in the future.");

        RuleFor(sale => sale.CustomerId)
            .MustBeAValidId().WithMessage("Sale must have a valid Customer ID");

        RuleFor(sale => sale.CustomerName)
            .NotEmpty().WithMessage("Customer name must not be empty.")
            .Length(3, 50).WithMessage("Customer name must be at least 3 characters long and cannot be longer than 50 characters.");

        RuleFor(sale => sale.CustomerEmail).SetValidator(new EmailValidator());

        RuleFor(sale => sale.BranchId)
            .MustBeAValidId()
            .WithMessage("Sale must have a valid Branch ID");

        RuleFor(sale => sale.BranchName)
            .NotEmpty().WithMessage("Branch name must not be empty.")
            .Length(3, 50).WithMessage("Branch name must be at least 3 characters long and cannot be longer than 50 characters.");

        RuleFor(sale => sale.Items)
            .NotEmpty()
            .WithMessage("At least one sale item is required.")
            .ForEach(item => item.SetValidator(new CreateSaleItemRequestValidator()));
    }
}

/// <summary>
/// Validator for <see cref="CreateSaleItemRequest"/> that defines validation rules items whitin a sale.
/// </summary>
public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleItemRequestValidator"/> with defined validation rules.
    /// </summary>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">ProductId: Should be valid</list>
    /// <list type="bullet">ProductName: Must be within 3 to 50 characters (inclusive)</list>
    /// <list type="bullet">Quantity: Min 1 and max 20</list>
    /// <list type="bullet">UnitPrice: Must be greater than 0</list>
    /// </remarks>
    public CreateSaleItemRequestValidator()
    {
        RuleFor(item => item.ProductId)
            .MustBeAValidId().WithMessage("Sale item must have a valid Product ID");

        RuleFor(item => item.ProductName)
            .NotEmpty().WithMessage("Product name must not be empty.")
            .Length(3, 50).WithMessage("Product name must be at least 3 characters long and cannot be longer than 50 characters.");

        RuleFor(saleItem => saleItem.Quantity)
            .InclusiveBetween(1, 20).WithMessage("Quantity must be at least 1 and cannot be higher than 20.");

        RuleFor(saleItem => saleItem.UnitPrice)
            .GreaterThan(0).WithMessage("Item price must be higher than 0");
    }
}