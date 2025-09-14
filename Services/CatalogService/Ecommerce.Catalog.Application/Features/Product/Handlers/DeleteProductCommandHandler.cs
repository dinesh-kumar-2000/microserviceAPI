using Ecommerce.Catalog.Application.Features.Product.Command;
using Ecommerce.Catalog.Application.Interfaces;
using MediatR;

namespace Ecommerce.Catalog.Application.Features.Product.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                return false; // Product not found
            }

            await _productRepository.DeleteAsync(request.Id);

            return true; // Deletion successful
        }
    }
}
