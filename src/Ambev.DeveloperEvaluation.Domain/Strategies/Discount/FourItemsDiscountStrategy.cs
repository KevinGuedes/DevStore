namespace Ambev.DeveloperEvaluation.Domain.Strategies.Discount;

/// <summary>
/// Discount strategy for purchases with more than 4 identical items.
/// </summary>
public class FourItemsDiscountStrategy : IDiscountStrategy
{
    public decimal GetDiscountRate() => 0.1m;
}
