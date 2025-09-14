using AutoMapper;
using Ecommerce.Catalog.Application.DTOs.Product;
using Ecommerce.Catalog.Application.Features.Product.Queries;
using Ecommerce.Catalog.Application.Interfaces;
using MediatR;

namespace Ecommerce.Catalog.Application.Features.Product.Handlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly IProductRepository _repo;

    public GetAllProductsQueryHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repo.GetAllAsync(request.Page, request.PageSize);
        var dtos = products.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
        }).ToList();

        return dtos;
    }
}