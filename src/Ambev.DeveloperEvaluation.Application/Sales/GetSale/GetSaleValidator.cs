using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Validator for <see cref="GetSaleQuery"/> that defines validation for get sale operations.
/// </summary>
public class GetSaleValidator : AbstractValidator<GetSaleQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetSaleValidator"/> with defined validation rules.
    /// </summary>
    /// /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Id: Must be a valid sale ID</list>
    /// </remarks>
    public GetSaleValidator()
    {
        RuleFor(request => request.Id)
           .MustBeAValidId().WithMessage("Invalid sale ID");
    }
}
