using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Represents a profile for mapping object related to GetSale feature.
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSale feature.
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<Guid, GetSaleQuery>()
            .ConstructUsing(id => new GetSaleQuery(id));

        CreateMap<GetSaleResult, GetSaleResponse>();
        CreateMap<GetSaleItemResult, GetSaleItemResponse>();
    }
}
