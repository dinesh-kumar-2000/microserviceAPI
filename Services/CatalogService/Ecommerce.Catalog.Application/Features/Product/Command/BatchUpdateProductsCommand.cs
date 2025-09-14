namespace Ecommerce.Catalog.Application.Features.Product.Command;

// For updating multiple products at once
public class BatchUpdateProductsCommand
{
    public List<UpdateProductCommand> ProductsToUpdate { get; set; } = new();
}
