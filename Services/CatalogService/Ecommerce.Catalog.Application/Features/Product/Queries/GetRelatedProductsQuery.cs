namespace Ecommerce.Catalog.Application.Features.Product.Queries;

// Get related/recommended products (could be upsells, cross-sells, etc.)
public class GetRelatedProductsQuery
{
    public Guid ProductId { get; set; }
    public int? Limit { get; set; } = 4;
}
