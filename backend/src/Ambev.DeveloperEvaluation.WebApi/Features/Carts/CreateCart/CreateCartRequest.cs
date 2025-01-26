namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Represents a request to create a new cart in the system.
/// </summary>
public class CreateCartRequest
{
    /// <summary>
    /// Gets or sets the UserId to be created.
    /// </summary>
    public Guid UserId { get; set; } = Guid.Empty;

    /// <summary>
    /// Gets the cart's create date.    
    /// </summary>
    public DateTime Date { get; set; } = DateTime.Now;

    public List<ProductsRequest> Products { get; set; } = new List<ProductsRequest>();

    public class ProductsRequest
    {
        /// <summary>
        /// Gets or sets the ProductId to be created.
        /// </summary>
        public Guid ProductId { get; set; } = Guid.Empty;

        /// <summary>
        /// Gets or sets the Quantity for the product.
        /// </summary>
        public int Quantity { get; set; } = 0;
    }
}