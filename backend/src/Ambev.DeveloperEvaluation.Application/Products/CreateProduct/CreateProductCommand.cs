using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Command for creating a new product.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a product
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateProductResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateProductValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateProductCommand : IRequest<CreateProductResult>
{
    /// <summary>
    /// Gets or sets the Title of the product to be created.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price for the product.
    /// </summary>
    public decimal Price { get; set; } = 0;

    /// <summary>
    /// Gets or sets the description for the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category for the product.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the image for the product.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Rate for the product.
    /// </summary>
    public decimal Rate { get; set; } = 0;

    /// <summary>
    /// Gets or sets the Count for the product.
    /// </summary>
    public int Count { get; set; } = 0;

    public ValidationResultDetail Validate()
    {
        var validator = new CreateProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}