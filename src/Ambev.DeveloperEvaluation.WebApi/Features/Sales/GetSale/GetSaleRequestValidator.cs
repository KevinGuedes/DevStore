using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Validator for <see cref="GetSaleRequest"/> that defines validation rules for get sale operation.
/// </summary>
public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetSaleRequestValidator"/> with defined validation rules.
    /// </summary>
    /// /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Id: Must be a valid sale ID</list>
    /// </remarks>
    public GetSaleRequestValidator()
    {
        RuleFor(request => request.Id)
            .MustBeAValidId().WithMessage("Invalid sale ID");
    }
}
