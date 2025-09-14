using MediatR;

namespace Ecommerce.Catalog.Application.Features.Product.Command;

// For deletion (by Id)
public class DeleteProductCommand:IRequest<bool>
{
    public Guid Id { get; set; }
}
