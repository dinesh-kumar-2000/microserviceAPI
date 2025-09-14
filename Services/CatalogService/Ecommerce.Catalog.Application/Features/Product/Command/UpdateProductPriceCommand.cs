namespace Ecommerce.Catalog.Application.Features.Product.Command;

// For changing product price
public class UpdateProductPriceCommand
{
    public Guid ProductId { get; set; }
    public decimal NewPrice { get; set; }
    public decimal? NewSalePrice { get; set; }
    public DateTime? SaleStartDate { get; set; }
    public DateTime? SaleEndDate { get; set; }
}
