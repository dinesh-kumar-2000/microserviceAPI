using AutoMapper;
using Ecommerce.Catalog.Application.Features.Product.Command;
using Ecommerce.Catalog.Application.Interfaces;
using MediatR;

namespace Ecommerce.Catalog.Application.Features.Product.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repo;

    public CreateProductCommandHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Entities.Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId,
        };
        var id = await _repo.CreateAsync(product);
        return id;
    }
}
