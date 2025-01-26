namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtcs.UpdateProduct;

/// <summary>
/// API response model for UpdateProduct operation
/// </summary>
public class UpdateProductResponse
{
    /// <summary>
    /// The unique identifier of the updated product
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
    /// The product's rating
    /// </summary>    
    public UpdateProductRatingResponse Rating { get; set; } = new UpdateProductRatingResponse();

    public class UpdateProductRatingResponse
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
