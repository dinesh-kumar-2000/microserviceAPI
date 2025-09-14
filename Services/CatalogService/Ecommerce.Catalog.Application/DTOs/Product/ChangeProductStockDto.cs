namespace Ecommerce.Catalog.Application.DTOs.Product;

public class ChangeProductStockDto
{
    public Guid ProductId { get; set; }
    public int NewStockQuantity { get; set; }
}
