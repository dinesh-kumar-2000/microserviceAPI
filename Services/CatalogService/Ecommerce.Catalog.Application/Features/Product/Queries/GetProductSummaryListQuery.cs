namespace Ecommerce.Catalog.Application.Features.Product.Queries;

// Get a summary/lightweight list for product listings or dropdowns
public class GetProductSummaryListQuery
{
    // Optionally filter
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public Guid? CategoryId { get; set; }
    public string? Keyword { get; set; }
}
