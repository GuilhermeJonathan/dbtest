using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

/// <summary>
/// Validator for ListCartsRequest
/// </summary>
public class ListCartsRequestValidator : AbstractValidator<ListCartsRequest>
{
    /// <summary>
    /// Initializes validation rules for ListCartsRequest
    /// </summary>
    public ListCartsRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
    }
}
