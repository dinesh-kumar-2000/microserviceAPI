namespace Ecommerce.Catalog.Application.Features.Product.Command;

// For changing product stock
public class ChangeProductStockCommand
{
    public Guid ProductId { get; set; }
    public int NewStockQuantity { get; set; }
}
