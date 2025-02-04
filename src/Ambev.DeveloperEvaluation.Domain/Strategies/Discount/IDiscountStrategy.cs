namespace Ambev.DeveloperEvaluation.Domain.Strategies.Discount;

/// <summary>
/// Represents a discount strategy.
/// </summary>
public interface IDiscountStrategy
{
    decimal GetDiscountRate();
}
