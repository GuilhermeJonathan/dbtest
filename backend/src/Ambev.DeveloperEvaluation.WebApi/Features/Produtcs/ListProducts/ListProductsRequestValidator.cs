using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtcs.ListProducts;

/// <summary>
/// Validator for ListProductsRequest
/// </summary>
public class ListProductsRequestValidator : AbstractValidator<ListProductsRequest>
{
    /// <summary>
    /// Initializes validation rules for ListProductsRequest
    /// </summary>
    public ListProductsRequestValidator()
    {        
    }
}
