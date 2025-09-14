namespace Ecommerce.Catalog.Application.Features.Product.Queries;

// Get all reviews for a product
public class GetProductReviewsQuery
{
    public Guid ProductId { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}
