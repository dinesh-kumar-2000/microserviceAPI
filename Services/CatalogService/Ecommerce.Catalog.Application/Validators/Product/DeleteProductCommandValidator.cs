using Ecommerce.Catalog.Application.Features.Product.Command;
using FluentValidation;

namespace Ecommerce.Catalog.Application.Validators.Product;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Product Id is required.");
    }
}
