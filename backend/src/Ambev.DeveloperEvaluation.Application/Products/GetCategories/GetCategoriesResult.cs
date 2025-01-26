namespace Ambev.DeveloperEvaluation.Application.Products.GetCategories;

/// <summary>
/// Response model for GetCategories operation
/// </summary>
public class GetCategoriesResult
{
    /// <summary>
    /// The categories of products
    /// </summary>
    public List<string> Categories { get; set; } = new List<string>();
}
