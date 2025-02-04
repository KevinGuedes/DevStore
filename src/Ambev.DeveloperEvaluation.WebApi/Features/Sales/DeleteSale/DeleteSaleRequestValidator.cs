using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Validator for <see cref="DeleteSaleRequest"/> that defines validation for get sale operations.
/// </summary>
public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleRequestValidator"/> with defined validation rules.
    /// </summary>
    /// /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Id: Must be a valid sale ID</list>
    /// </remarks>
    public DeleteSaleRequestValidator()
    {
        RuleFor(request => request.Id)
          .MustBeAValidId().WithMessage("Invalid sale ID");
    }
}
