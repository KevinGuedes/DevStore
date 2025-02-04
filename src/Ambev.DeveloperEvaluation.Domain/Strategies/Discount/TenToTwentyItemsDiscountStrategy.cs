namespace Ambev.DeveloperEvaluation.Domain.Strategies.Discount;

/// <summary>
/// Discount strategy for purchases with 10 to 20 identical items.
/// </summary>
public class TenToTwentyItemsDiscountStrategy : IDiscountStrategy
{
    public decimal GetDiscountRate() => 0.2m;
}
