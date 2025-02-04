namespace Ambev.DeveloperEvaluation.Domain.Strategies.Discount;

/// <summary>
/// Represents a discount strategy that does not apply any discount. 
/// </summary>
public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal GetDiscountRate() => 0;
}
