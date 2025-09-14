namespace Ecommerce.Catalog.Application.Features.Product.Queries;

// Get current stock level for a product
public class GetProductStockQuery
{
    public Guid ProductId { get; set; }
}
