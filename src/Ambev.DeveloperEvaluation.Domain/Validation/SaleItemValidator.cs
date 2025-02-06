using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(saleItem => saleItem.SaleId)
            .MustBeAValidId().WithMessage("Item must have a valid SaleId");

        RuleFor(saleItem => saleItem.ProductId)
            .MustBeAValidId().WithMessage("Item must have a valid ProductId");

        RuleFor(sale => sale.ProductName)
            .NotEmpty().WithMessage("Product name must not be empty.")
            .Length(3, 100).WithMessage("Product name must be at least 3 characters long and cannot be longer than 100 characters.");

        RuleFor(saleItem => saleItem.Quantity)
            .InclusiveBetween(1, 20).WithMessage("Quantity must be at least 1 and cannot be higher than 20.");

        RuleFor(saleItem => saleItem.UnitPrice)
            .GreaterThan(0).WithMessage("Item price must be higher than 0");
    }
}
