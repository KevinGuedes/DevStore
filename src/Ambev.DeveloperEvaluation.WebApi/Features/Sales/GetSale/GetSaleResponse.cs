namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// API response model for GetSale operation.
/// </summary>
public class GetSaleResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the sale number.
    /// </summary>
    public long Number { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the sale occurred.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the ID of the customer making the sale.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the email of the customer making the sale.
    /// </summary>
    public string CustomerEmail { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the customer making the sale.
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ID of the branch where the sale occurred.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Gets or sets the name of the branch where the sale occurred.
    /// </summary>
    public string BranchName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the list of items included in the sale.
    /// </summary>
    public List<GetSaleItemResponse> Items { get; set; } = [];

    /// <summary>
    /// Gets or sets the total amount of the sale before applying discounts.
    /// </summary>
    public decimal TotalSaleAmountBeforeDiscount { get; set; }

    /// <summary>
    /// Gets or sets the total amount of the sale after applying discounts.
    /// </summary>
    public decimal TotalSaleAmountWithDiscount { get; set; }
}

/// <summary>
/// API response model items within a sale.
/// </summary>
public class GetSaleItemResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale item.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the product being sold.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product being sold.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of the product being sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product being sold.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets the total amount of the item before applying discounts.
    /// </summary>
    public decimal TotalAmountBeforeDiscount { get; set; }

    /// <summary>
    /// Gets the total amount of the item after applying discounts.
    /// </summary>
    public decimal TotalAmountWithDiscount { get; set; }
}