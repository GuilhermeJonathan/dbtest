namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Response model for GetProduct operation
/// </summary>
public class GetCartResult
{
    /// <summary>
    /// The unique identifier of the created product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The cart's UserId
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The cart's Date
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// The cart's Products
    /// </summary>    
    public List<ProductsResult> Products { get; set; } = new List<ProductsResult>();

    public class ProductsResult
    {
        /// <summary>
        /// The cart's Product
        /// </summary>
        public Guid ProductId { get; set; } = Guid.Empty;   

        /// <summary>
        /// The product's quantity
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// The product's Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the ProductCart's TotalPrice.
        /// </summary>
        public decimal TotalPrice { get; set; } = 0;

        /// <summary>
        /// The product's Discount
        /// </summary>
        public decimal Discount { get; set; }
    }
}
