using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtcs.GetByCategory;

/// <summary>
/// Validator for GetByCategoryRequest
/// </summary>
public class GetByCategoryRequestValidator : AbstractValidator<GetByCategoryRequest>
{
    /// <summary>
    /// Initializes validation rules for GetByCategoryRequest
    /// </summary>
    public GetByCategoryRequestValidator()
    {
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category name is required");
    }
}
