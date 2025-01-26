using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartRequest that defines validation rules for user creation.
/// </summary>
public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:    
    /// - UserId: Required
    /// - Date: Required    
    /// </remarks>
    public CreateCartRequestValidator()
    {
        RuleFor(user => user.UserId).NotEmpty();
        RuleFor(user => user.Date).NotEmpty();
    }
}