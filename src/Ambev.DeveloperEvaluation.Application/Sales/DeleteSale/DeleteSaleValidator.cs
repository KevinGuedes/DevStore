using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Validator for <see cref="DeleteSaleCommand"/> that defines validation for get sale operations.
/// </summary>
public class DeleteSaleValidator : AbstractValidator<DeleteSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleValidator"/> with defined validation rules.
    /// </summary>
    /// /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Id: Must be a valid sale ID</list>
    /// </remarks>
    public DeleteSaleValidator()
    {
        RuleFor(request => request.Id)
          .MustBeAValidId().WithMessage("Invalid sale ID");
    }
}
