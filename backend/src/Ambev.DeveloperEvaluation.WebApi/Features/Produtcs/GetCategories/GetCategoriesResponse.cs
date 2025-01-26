namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtcs.GetCategories;

/// <summary>
/// API response model for GetCategories operation
/// </summary>
public class GetCategoriesResponse
{
    /// <summary>
    /// The categories of products
    /// </summary>
    public List<string> Categories { get; set; } = new List<string>();
}
