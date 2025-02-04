using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Strategies.Discount;

/// <summary>
/// Class to select the discount strategy <see cref="IDiscountStrategy"/> based on the purchase
/// </summary>
public static class DiscountSelector
{
    private const int FOUR_ITEMS_DISCOUNT_THRESHOLD = 4;
    private const int LOWER_LIMIT_FOR_TEN_TO_TWENTY_DISCOUNT = 10;

    /// <summary>
    /// Selects the discount strategy based on the purchase
    /// </summary>
    /// <param name="saleItem">The sale item being purchased</param>
    /// <returns>The discount strategy for the given <param name="saleItem"></returns>
    public static IDiscountStrategy GetDiscountStrategy(SaleItem saleItem)
    {
        if (saleItem.Quantity >= LOWER_LIMIT_FOR_TEN_TO_TWENTY_DISCOUNT)
            return new TenToTwentyItemsDiscountStrategy();

        if (saleItem.Quantity > FOUR_ITEMS_DISCOUNT_THRESHOLD)
            return new FourItemsDiscountStrategy();

        return new NoDiscountStrategy();
    }
}
