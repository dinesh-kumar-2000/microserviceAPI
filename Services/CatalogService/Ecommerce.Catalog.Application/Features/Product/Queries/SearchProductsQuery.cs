namespace Ecommerce.Catalog.Application.Features.Product.Queries;

// Search with keyword and filtering
public class SearchProductsQuery
{
    public string? Keyword { get; set; }
    public Guid? CategoryId { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? Brand { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public string? SortBy { get; set; }    // e.g. "price", "name"
    public string? SortDirection { get; set; } // "asc" or "desc"
}
