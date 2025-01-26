namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Represents the response returned after successfully updating a Cart.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly updated Cart,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateCartResult
{
    /// <summary>
    /// The unique identifier of the Cart
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
    }
}
