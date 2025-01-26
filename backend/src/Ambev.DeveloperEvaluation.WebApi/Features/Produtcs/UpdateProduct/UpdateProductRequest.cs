namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtcs.UpdateProduct;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class UpdateProductRequest
{
    /// <summary>
    /// The unique identifier of the product to retrieve
    /// </summary>
    public Guid Id { get; set; }

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
}