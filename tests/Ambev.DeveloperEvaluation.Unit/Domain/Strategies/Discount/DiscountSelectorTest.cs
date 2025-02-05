using Ambev.DeveloperEvaluation.Domain.Strategies.Discount;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Strategies.Discount;

/// <summary>
/// Contains unit tests for the <see cref="DiscountSelector"> class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class DiscountSelectorTest
{
    /// <summary>
    /// Tests that when a sale item has four items or less, the NoDiscountStrategy should be selected.
    /// </summary>
    [Fact(DisplayName = "No discount strategy should be selected for less than four items")]
    public void Given_ASaleItemWithLessThanFourItems_When_SelectingDiscount_Then_NoDiscountStrategyShouldBeSelected()
    {
        // Arrange
        var saleItem = SaleItemTestData.GenerateValidSaleItem().First();
        saleItem.Quantity = 4;

        // Act
        var discountStrategy = DiscountSelector.GetDiscountStrategy(saleItem);
        
        // Assert
        discountStrategy.Should().BeOfType<NoDiscountStrategy>();
    }

    /// <summary>
    /// Tests that when a sale item has more than 4 items, the FourItemsPlusDiscountStrategy should be selected.
    /// </summary>
    [Fact(DisplayName = "FourItemsPlusDiscountStrategy should be selected for more than four items")]
    public void Given_ASaleItemWithMoreThanFourItems_When_SelecintDiscount_Then_FourItemsPlusDiscountStrategyShouldBeSelected()
    {
        // Arrange
        var saleItem = SaleItemTestData.GenerateValidSaleItem().First();
        saleItem.Quantity = 5;

        // Act
        var discountStrategy = DiscountSelector.GetDiscountStrategy(saleItem);
        // Assert

        discountStrategy.Should().BeOfType<FourItemsPlusDiscountStrategy>();
    }

    /// <summary>
    /// Tests that when a sale item has ten items, the TenToTwentyItemsDiscountStrategy should be selected.
    /// </summary>
    [Fact(DisplayName = "TenToTwentyItemsDiscountStrategy should be selected for ten items")]
    public void Given_ASaleItemWithTenItems_When_SelectingDiscount_Then_TenToTwentyItemsDiscountStrategyShouldBeSelected()
    {
        // Arrange
        var saleItem = SaleItemTestData.GenerateValidSaleItem().First();
        saleItem.Quantity = 10;

        // Act
        var discountStrategy = DiscountSelector.GetDiscountStrategy(saleItem);

        // Assert
        discountStrategy.Should().BeOfType<TenToTwentyItemsDiscountStrategy>();
    }

    /// <summary>
    /// Tests that when a sale item has 20 items, the TenToTwentyItemsDiscountStrategy should be selected.
    /// </summary>
    [Fact(DisplayName = "TenToTwentyItemsDiscountStrategy should be selected for ten items")]
    public void Given_ASaleItemWithTwentyItems_When_SelectingDiscount_Then_TenToTwentyItemsDiscountStrategyShouldBeSelected()
    {
        // Arrange
        var saleItem = SaleItemTestData.GenerateValidSaleItem().First();
        saleItem.Quantity = 20;

        // Act
        var discountStrategy = DiscountSelector.GetDiscountStrategy(saleItem);

        // Assert
        discountStrategy.Should().BeOfType<TenToTwentyItemsDiscountStrategy>();
    }
}
