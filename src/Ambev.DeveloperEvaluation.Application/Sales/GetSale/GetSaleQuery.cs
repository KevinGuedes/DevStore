using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Query for retrieving a sale by ID
/// </summary>
/// <remarks>
/// This query is used to retrieve a sale from the database.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="GetSaleResult"/>.
/// The data provided in this query is validated using the 
/// <see cref="GetSaleValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class GetSaleQuery : IRequest<GetSaleResult>
{
    /// <summary>
    /// Gets or set the sale ID.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="GetSaleQuery">
    /// </summary>
    /// <param name="id">The ID of the sale to retrieve</param>
    public GetSaleQuery(Guid id)
    {
        Id = id;
    }
}
