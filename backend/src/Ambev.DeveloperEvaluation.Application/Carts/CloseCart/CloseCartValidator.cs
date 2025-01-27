using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CloseCart;

/// <summary>
/// Validator for DeleteCartCommand
/// </summary>
public class CloseCartValidator : AbstractValidator<CloseCartCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteCartCommand
    /// </summary>
    public CloseCartValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Cart ID is required");
    }
}
