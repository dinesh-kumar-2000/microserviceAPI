using Ecommerce.Catalog.Application.Features.Product.Command;
using FluentValidation;

namespace Ecommerce.Catalog.Application.Validators.Product;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Product Id is required.");

        RuleFor(x => x.Name)
            .MaximumLength(200);

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).When(x => x.Price.HasValue);

        // Add per-field conditional rules
    }
}
