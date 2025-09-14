namespace Ecommerce.Catalog.Application.Features.Product.Command;

// For submitting a new product rating/review
public class RateProductCommand
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public int Rating { get; set; } // e.g., 1-5 stars
    public string? Review { get; set; }
}
