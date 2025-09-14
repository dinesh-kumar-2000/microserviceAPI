namespace Ecommerce.Catalog.Application.Features.Product.Command;

// For toggling product availability
public class SetProductAvailabilityCommand
{
    public Guid ProductId { get; set; }
    public bool IsAvailable { get; set; }
}
