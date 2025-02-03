using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item that it is part of a <see cref="Sale"/>.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleItem : BaseEntity
{
    /// <summary>
    /// Gets the sale ID.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets the product ID.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Get the product name.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the product unit price.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets the total amount of the sale item.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Performs validation of the sale item entity using the SaleItemValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Sale data</list>
    /// <list type="bullet">Product data</list>
    /// <list type="bullet">Quantity and unit price validity</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}