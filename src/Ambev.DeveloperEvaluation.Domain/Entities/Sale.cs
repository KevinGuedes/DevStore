using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale in the system with it's information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets or sets the sale number.
    /// </summary>
    public long Number { get; set; }

    /// <summary>
    /// Gets or sets the date when the sale was made.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the customer ID.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the customer name.
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the customer email.
    /// </summary>
    public string CustomerEmail { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the branch ID.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Gets or sets the branch name.
    /// </summary>
    public string BranchName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the list of products in the sale.
    /// </summary>
    public List<SaleItem> Items { get; set; } = [];

    /// <summary>
    /// Gets or sets whether the sale is cancelled or not cancelled.
    /// </summary>
    public bool IsCancelled { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the sale was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time of the last update to the sale's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Gets the total amount of the sale before applying discounts.
    /// </summary>
    public decimal TotalSaleAmountBeforeDiscount
        => Items.Sum(item => item.TotalAmountBeforeDiscount);

    /// <summary>
    /// Gets the total amount of the sale after applying discounts.
    /// </summary>
    public decimal TotalSaleAmountWithDiscount
        => Items.Sum(item => item.TotalAmountWithDiscount);

    /// <summary>
    /// Gets the total number of items in the sale.
    /// </summary>
    public decimal ItemsCount => Items.Count;

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
        Number = GenerateSaleNumber();
    }

    /// <summary>
    /// Generates a unique sale number.
    /// </summary>
    /// <returns>A unique sale number</returns>
    // random number just for the challenge
    private static long GenerateSaleNumber()
        => new Random().NextInt64();

    /// <summary>
    /// Performs validation of the sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Customer data</list>
    /// <list type="bullet">Branch data</list>
    /// <list type="bullet">Sales items amount</list>
    /// <list type="bullet">Sale number validity</list>
    /// <list type="bullet">Sale date validity</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Cancels the sale.
    /// Changes the value of <see cref="IsCancelled"/> to true
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
        UpdatedAt = DateTime.UtcNow;
    }
}