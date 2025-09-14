namespace Ecommerce.Catalog.Application.Features.Product.Command;

// For adding an image to a product
public class AddProductImageCommand
{
    public Guid ProductId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int SortOrder { get; set; } = 0;
}
