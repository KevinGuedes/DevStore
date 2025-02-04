using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<SaleItemRequest, SaleItemCommand>();
        CreateMap<CreateSaleRequest, CreateSaleCommand>();

        CreateMap<SaleItemResult, SaleItemResponse>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();
    }
}
