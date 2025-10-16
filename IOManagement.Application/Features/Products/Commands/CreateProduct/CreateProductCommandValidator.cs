using FluentValidation;

namespace IOManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");
        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("Product description must not exceed 500 characters.");
        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
        RuleFor(p => p.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");
    }
}
