using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

/// <summary>
/// Command for retrieving a list of all products
/// </summary>
public record ListProductsCommand : IRequest<ListProductsResult>
{
    /// <summary>
    /// Page number
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// Page Size
    /// </summary>
    public int Size { get; set; } = 10;

    /// <summary>
    /// Order column
    /// </summary>
    public string Order { get; set; } = string.Empty;
}
