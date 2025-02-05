using Ambev.DeveloperEvaluation.Domain.Strategies.Discount;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the SaleItem entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class SaleItemTest
{
    /// <summary>
    /// Tests that validation passes when all SaleItem properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid SaleItem data")]
    public void Given_ValidSaleItemData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var saleItems = SaleItemTestData.GenerateValidSaleItem();

        // Act
        var result = saleItems[0].Validate();

        // Assert
        result.IsValid.Should().BeTrue();
    }

    /// <summary>
    /// Tests that validation does not pass when SaleItem properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should not pass for invalid SaleItem data")]
    public void Given_InvalidSaleItemData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var saleItems = SaleItemTestData.GenerateInvalidSaleItem();

        // Act
        var result = saleItems[0].Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }

    /// <summary>
    /// Tests that when a discount strategy is applied, the SaleItem is discounted.
    /// </summary>
    [Fact(DisplayName = "Discount should be applied properly")]
    public void Given_ADiscountStrategy_When_ApplyingDiscount_Then_ShouldReturnDiscountedPrice()
    {
        // Arrange
        var saleItems = SaleItemTestData.GenerateValidSaleItem();
        var discountStrategy = new FourItemsPlusDiscountStrategy();
        var saleItem = saleItems[0];
        saleItem.Quantity = 5;

        // Act
        saleItem.ApplyDiscount(discountStrategy);

        // Assert
        saleItem.TotalAmountBeforeDiscount.Should().Be(saleItem.UnitPrice * saleItem.Quantity);
        saleItem.TotalAmountWithDiscount.Should().Be(saleItem.Quantity * (1 - 0.1m) * saleItem.UnitPrice);
    }
}
