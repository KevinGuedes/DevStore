using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the <see cref="Sale"> entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class SaleTest
{
    /// <summary>
    /// Tests that validation passes when all Sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid Sale data")]
    public void Given_ValidSaleItemData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = sale.Validate();

        // Assert
        result.IsValid.Should().BeTrue();
    }

    /// <summary>
    /// Tests that validation does not pass when Sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should not pass for invalid Sale data")]
    public void Given_InvalidSale_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = SaleTestData.GenerateInvalidSale();

        // Act
        var result = sale.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }

    /// <summary>
    /// Tests that when a sale is cancelled, the sale is marked as cancelled.
    /// </summary>
    [Fact(DisplayName = "Sale should be cancelled when cancelled")]
    public void Given_ANotCancelledSale_When_CancellingSale_Then_ShouldReturnCancelled()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        sale.Cancel();

        // Assert
        Assert.True(sale.IsCancelled);
    }
}
