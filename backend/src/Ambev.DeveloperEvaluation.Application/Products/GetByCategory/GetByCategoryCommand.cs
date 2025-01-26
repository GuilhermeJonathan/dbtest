using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetByCategory;

/// <summary>
/// Command for retrieving a list of all products by category
/// </summary>
public record GetByCategoryCommand : IRequest<GetByCategoryResult>
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

    /// <summary>
    /// Category name
    /// </summary>
    public string Category { get; set; } = string.Empty;
}
