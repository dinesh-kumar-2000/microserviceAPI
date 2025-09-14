using Ecommerce.Catalog.Application.DTOs.Product;
using MediatR;

namespace Ecommerce.Catalog.Application.Features.Product.Queries;

// Get all products, optionally with pagination
public class GetAllProductsQuery : IRequest<List<ProductDto>>
{
    // Pagination (optional)
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
