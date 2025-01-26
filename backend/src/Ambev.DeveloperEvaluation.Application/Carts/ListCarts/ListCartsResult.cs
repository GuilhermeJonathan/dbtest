namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Response model for ListCarts operation
/// </summary>
public class ListCartsResult
{
    public List<CartResult> Carts { get; set; } = new List<CartResult>();

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

    public class CartResult
    {
        /// <summary>
        /// The unique identifier of the cart
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
        /// The product's Rating
        /// </summary>    
        public List<ListCartsProductsResult> Products { get; set; } = new List<ListCartsProductsResult>();

        public class ListCartsProductsResult
        {
            /// <summary>
            /// The cart's Product
            /// </summary>
            public Guid ProductId { get; set; }

            /// <summary>
            /// The product's quantity
            /// </summary>
            public int Quantity { get; set; }
        }
    }
}
