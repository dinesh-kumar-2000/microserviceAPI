using Ecommerce.Catalog.Application.DTOs.Product;
using MediatR;

namespace Ecommerce.Catalog.Application.Features.Product.Queries;

// Get a product by its unique ID
public class GetProductByIdQuery : IRequest<ProductDto>
{
    public Guid ProductId { get; set; }
}
