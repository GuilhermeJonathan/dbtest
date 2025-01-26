using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Validator for UpdateCartCommand that defines validation rules for user update command.
/// </summary>
public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
{
    /// <summary>
    /// Initializes a new instance of the UpdateCartRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserId: Required
    /// - Date: Required   
    /// </remarks>
    public UpdateCartValidator()
    {
        RuleFor(user => user.UserId).NotEmpty();
        RuleFor(user => user.Date).NotEmpty();
    }
}