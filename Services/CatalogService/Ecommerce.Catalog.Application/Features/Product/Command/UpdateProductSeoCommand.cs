namespace Ecommerce.Catalog.Application.Features.Product.Command;

// For updating SEO-specific fields
public class UpdateProductSeoCommand
{
    public Guid ProductId { get; set; }
    public string? MetaTitle { get; set; }
    public string? MetaKeywords { get; set; }
    public string? MetaDescription { get; set; }
    public string? UrlSlug { get; set; }
}
