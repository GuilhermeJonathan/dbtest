namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Response model for GetProduct operation
/// </summary>
public class GetProductResult
{
    /// <summary>
    /// The unique identifier of the created product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The product's Title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The product's Price
    /// </summary>
    public decimal Price { get; set; } = 0;

    /// <summary>
    /// The product's Description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The product's Category
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// The product's Image
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// The product's Rating
    /// </summary>    
    public RatingResult Rating { get; set; } = new RatingResult();

    public class RatingResult
    {
        /// <summary>
        /// The product's Rate
        /// </summary>
        public decimal Rate { get; set; } = 0;

        /// <summary>
        /// The product's Count
        /// </summary>
        public int Count { get; set; } = 0;
    }
}
