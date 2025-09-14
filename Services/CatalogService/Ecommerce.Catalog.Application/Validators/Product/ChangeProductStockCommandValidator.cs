using Ecommerce.Catalog.Application.Features.Product.Command;
using FluentValidation;

namespace Ecommerce.Catalog.Application.Validators.Product;

public class ChangeProductStockCommandValidator : AbstractValidator<ChangeProductStockCommand>
{
    public ChangeProductStockCommandValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.NewStockQuantity)
            .GreaterThanOrEqualTo(0);
    }
}