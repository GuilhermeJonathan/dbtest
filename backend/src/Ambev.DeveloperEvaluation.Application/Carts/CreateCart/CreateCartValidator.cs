using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartCommand that defines validation rules for user creation command.
/// </summary>
public class CreateCartValidator : AbstractValidator<CreateCartCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:    
    /// - UserId: Required
    /// - Date: Required    
    /// </remarks>
    public CreateCartValidator()
    {
        RuleFor(user => user.UserId).NotEmpty();
        RuleFor(user => user.Date).NotEmpty();
    }
}