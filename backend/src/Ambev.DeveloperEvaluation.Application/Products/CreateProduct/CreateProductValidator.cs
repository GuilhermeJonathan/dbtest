using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for user creation command.
/// </summary>
public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:    
    /// - Title: Required, must be between 3 and 100 characters    
    /// - Price: Cannot be set to null    
    /// - Description: Required, must be between 3 and 500 characters    
    /// - Category: Required, must be between 3 and 100 characters    
    /// - Image: Required, must be between 3 and 100 characters    
    /// - Rate: Required
    /// - Count: Required
    /// </remarks>
    public CreateProductValidator()
    {
        RuleFor(user => user.Title).NotEmpty().Length(3, 100);
        RuleFor(user => user.Price).NotEmpty();
        RuleFor(user => user.Description).NotEmpty().Length(3, 500);
        RuleFor(user => user.Category).NotEmpty().Length(3, 100);
        RuleFor(user => user.Image).NotEmpty().Length(3, 100);
        RuleFor(user => user.Rate).NotEmpty();
        RuleFor(user => user.Count).NotEmpty();
    }
}