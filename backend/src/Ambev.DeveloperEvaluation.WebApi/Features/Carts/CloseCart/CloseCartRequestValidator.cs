using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CloseCart;

/// <summary>
/// Validator for DeleteCartRequest
/// </summary>
public class CloseCartRequestValidator : AbstractValidator<CloseCartRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteCartRequest
    /// </summary>
    public CloseCartRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Cart ID is required");
    }
}
