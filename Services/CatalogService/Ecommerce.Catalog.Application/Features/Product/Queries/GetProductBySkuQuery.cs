namespace Ecommerce.Catalog.Application.Features.Product.Queries;

// Get a product by its unique SKU
public class GetProductBySkuQuery
{
    public string Sku { get; set; } = string.Empty;
}
