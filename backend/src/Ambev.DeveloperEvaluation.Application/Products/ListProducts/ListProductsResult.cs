namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

/// <summary>
/// Response model for ListProducts operation
/// </summary>
public class ListProductsResult
{
    public List<ProductResult> Products { get; set; } = new List<ProductResult>();

    /// <summary>
    /// Total items in the list
    /// </summary>
    public int TotalItems { get; set; }

    /// <summary>
    /// Current page
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Total pages
    /// </summary>
    public int TotalPages { get; set; }

    public class ProductResult
    {
        /// <summary>
        /// The unique identifier of the product
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
}
