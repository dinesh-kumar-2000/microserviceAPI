using AutoMapper;
using Ecommerce.Catalog.Application.Features.Product.Command;
using Ecommerce.Catalog.Application.Interfaces;
using MediatR;

namespace Ecommerce.Catalog.Application.Features.Product.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repo;

    public UpdateProductCommandHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Entities.Product
        {

        };

        return await _repo.UpdateAsync(product);
    }
}