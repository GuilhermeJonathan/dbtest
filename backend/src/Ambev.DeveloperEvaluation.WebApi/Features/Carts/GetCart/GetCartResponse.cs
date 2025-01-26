namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtcs.GetCart;

/// <summary>
/// API response model for GetCart operation
/// </summary>
public class GetCartResponse
{
    /// <summary>
    /// The unique identifier of the created cart
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
    /// The cart's products
    /// </summary>    
    public List<ProductsCartResponse> Products { get; set; } = new List<ProductsCartResponse>();

    public class ProductsCartResponse
    {
        /// <summary>
        /// The cart's Product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The product's quantity
        /// </summary>
        public int Quantity { get; set; }

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
