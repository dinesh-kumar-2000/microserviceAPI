using AutoMapper;
using Ecommerce.Catalog.Application.DTOs.Product;
using Ecommerce.Catalog.Application.Features.Product.Queries;
using Ecommerce.Catalog.Application.Interfaces;
using MediatR;

namespace Ecommerce.Catalog.Application.Features.Product.Handlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductRepository _repo;

    public GetProductByIdQueryHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repo.GetByIdAsync(request.ProductId);
        var dto = new ProductDto
        {

        };
        return dto;
    }
}