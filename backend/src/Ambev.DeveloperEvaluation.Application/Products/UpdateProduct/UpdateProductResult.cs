namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Represents the response returned after successfully updating a user.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly updated user,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateProductResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly updated user.
    /// </summary>
    /// <value>A GUID that uniquely identifies the updated user in the system.</value>
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
