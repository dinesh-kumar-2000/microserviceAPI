using MediatR;

namespace Ecommerce.Catalog.Application.Features.Product.Command;

// DTO for creating a product
public class CreateProductCommand : IRequest<Guid>
{
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Brand { get; set; }
    public Guid? CategoryId { get; set; }
    public string? ProductType { get; set; }
    public decimal Price { get; set; }
    public decimal? CostPrice { get; set; }
    public decimal? SalePrice { get; set; }
    public DateTime? SaleStartDate { get; set; }
    public DateTime? SaleEndDate { get; set; }
    public bool IsTaxable { get; set; }
    public Guid? TaxClassId { get; set; }
    public int StockQuantity { get; set; }
    public bool ManageStock { get; set; }
    public bool IsAvailable { get; set; }
    public int? LowStockThreshold { get; set; }
    public bool IsShippable { get; set; } = true;
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public decimal? Width { get; set; }
    public decimal? Length { get; set; }
    public Guid? ParentProductId { get; set; }
    public string? AttributesJson { get; set; }
    public string? MainImageUrl { get; set; }
    public string? ImageGalleryUrls { get; set; }
    public string? MetaTitle { get; set; }
    public string? MetaKeywords { get; set; }
    public string? MetaDescription { get; set; }
    public string? UrlSlug { get; set; }
}
