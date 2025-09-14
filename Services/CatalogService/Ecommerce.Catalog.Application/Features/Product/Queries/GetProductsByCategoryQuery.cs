namespace Ecommerce.Catalog.Application.Features.Product.Queries;

// Get all products within a specific category (optionally with pagination)
public class GetProductsByCategoryQuery
{
    public Guid CategoryId { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}
