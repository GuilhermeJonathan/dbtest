using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetByCategory;

/// <summary>
/// Validator for GetByCategoryCommand
/// </summary>
public class GetByCategoryValidator : AbstractValidator<GetByCategoryCommand>
{
    /// <summary>
    /// Initializes validation rules for GetByCategoryCommand
    /// </summary>
    public GetByCategoryValidator()
    {
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category name is required");
    }
}
