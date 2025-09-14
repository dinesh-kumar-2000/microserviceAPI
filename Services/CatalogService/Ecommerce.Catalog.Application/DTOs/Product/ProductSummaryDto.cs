namespace Ecommerce.Catalog.Application.DTOs.Product;

public class ProductSummaryDto
{
    public Guid Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? MainImageUrl { get; set; }
}
