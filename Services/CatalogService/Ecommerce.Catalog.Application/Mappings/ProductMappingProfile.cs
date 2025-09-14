using AutoMapper;
using Ecommerce.Catalog.Application.DTOs.Product;
using Ecommerce.Catalog.Application.Features.Product.Command;
using Ecommerce.Catalog.Domain.Entities;

namespace Ecommerce.Catalog.Application.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // Command -> Entity
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();

        // Entity -> DTO
        CreateMap<Product, ProductDto>();
        CreateMap<Product, ProductSummaryDto>();
        // DTO -> Entity

    }
}