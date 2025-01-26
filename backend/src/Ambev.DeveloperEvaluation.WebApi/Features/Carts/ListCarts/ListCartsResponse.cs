namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

/// <summary>
/// API response model for ListCarts operation
/// </summary>
public class ListCartsResponse
{
    public List<CartsResponse> Carts { get; set; } = new List<CartsResponse>();

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

    public class CartsResponse
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
        /// The product's cart
        /// </summary>    
        public List<ListCartsProductsResponse> Products { get; set; } = new List<ListCartsProductsResponse>();
     
        public class ListCartsProductsResponse
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
