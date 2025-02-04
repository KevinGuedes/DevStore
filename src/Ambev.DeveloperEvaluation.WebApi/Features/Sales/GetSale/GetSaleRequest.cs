namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Represents a request to get sale in the system by it's ID.
/// </summary>
public class GetSaleRequest
{
    /// <summary>
    /// Gets or set the sale ID.
    /// </summary>
    public Guid Id { get; set; }
}