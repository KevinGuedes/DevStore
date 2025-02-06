using Ambev.DeveloperEvaluation.Integration.Common;
using Ambev.DeveloperEvaluation.Integration.TestData;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using FluentAssertions;
using System.Net;

namespace Ambev.DeveloperEvaluation.Integration.Features;

/// <summary>
/// Tests for the Sales feature.
/// </summary>
/// <param name="applicationFactory">Application factory instance</param>
public sealed class SalesTests(ApplicationFactory applicationFactory)
    : BaseIntegrationTest(applicationFactory, "/api/sales")
{
    /// <summary>
    /// Tests happy path for the Create Sale endpoint.
    /// </summary>
    [Fact]
    public async Task CreateSaleEndpoint_ShouldReturnASale_WhenSuccess()
    {
        var request = SaleTestData.CreateValidSaleRequest();
        var user = UserTestData.GetDefaultUser();
        request.CustomerId = user.Id;
        request.CustomerName = user.Username;

        var (response, createSaleResponse) = await PostAsync<CreateSaleRequest, ApiResponseWithData<CreateSaleResponse>>(request);

        response.EnsureSuccessStatusCode();

        var sale = createSaleResponse!.Data;
        Assert.NotNull(sale);
        Assert.NotEqual(Guid.Empty, sale.Id);
        Assert.Equal(request.Date, sale.Date);
        Assert.Equal(request.BranchName, sale.BranchName);
        Assert.Equal(request.BranchId, sale.BranchId);
        Assert.Equal(request.CustomerEmail, sale.CustomerEmail);
        Assert.Equal(request.CustomerId, sale.CustomerId);
        Assert.Equal(request.CustomerName, sale.CustomerName);
        Assert.Equal(request.Items.Count, sale.Items.Count);
    }

    /// <summary>
    /// Tests happy path for the Create Sale endpoint.
    /// </summary>
    [Fact]
    public async Task CreateSaleEndpoint_ShouldReturnBadRequest_WhenInvalidPayloadIsSent()
    {
        var request = SaleTestData.CreateValidSaleRequest();
        var user = UserTestData.GetDefaultUser();
        request.CustomerId = user.Id;
        request.CustomerName = user.Username;
        request.Items[0].Quantity = 21; //to make the payload invalid

        var (response, _) = await PostAsync<CreateSaleRequest, ApiResponseWithData<CreateSaleResponse>>(request);
       
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    /// <summary>
    /// Tests happy path for the Get Sale endpoint.
    /// </summary>
    [Fact]
    public async Task GetSaleEndpoint_ShouldReturnASale_WhenSuccess()
    {
        var sale = SaleTestData.GetDefaultSale();

        var (response, getSaleResponse) = await GetAsync<ApiResponseWithData<GetSaleResponse>>(sale.Id.ToString());

        response.EnsureSuccessStatusCode();
        await VerifyResponsePayloadAsync(response);

        var saleFromResponse = getSaleResponse!.Data;

        Assert.NotNull(sale);
        Assert.NotEqual(Guid.Empty, saleFromResponse!.Id);
        Assert.Equal(sale.BranchName, saleFromResponse.BranchName);
        Assert.Equal(sale.BranchId, saleFromResponse.BranchId);
        Assert.Equal(sale.CustomerEmail, saleFromResponse.CustomerEmail);
        Assert.Equal(sale.CustomerId, saleFromResponse.CustomerId);
        Assert.Equal(sale.CustomerName, saleFromResponse.CustomerName);
        Assert.Equal(sale.Items.Count, saleFromResponse.Items.Count);
    }

    /// <summary>
    /// Tests bad request response for Get Sale feature.
    /// </summary>
    [Fact]
    public async Task GetSaleEndpoint_ShouldReturnBadRequest_WhenInvalidParamsAreSent()
    {
        var (response, _) = await GetAsync<ApiResponseWithData<GetSaleResponse>>(Guid.Empty.ToString());

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
