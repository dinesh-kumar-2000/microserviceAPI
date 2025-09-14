namespace Ecommerce.Catalog.Application.Features.Product.Command;

// For removing a product image
public class RemoveProductImageCommand
{
    public Guid ProductId { get; set; }
    public Guid ImageId { get; set; }
}
