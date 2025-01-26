namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    /// <summary>
    /// API response model for UpdateCartResponse operation
    /// </summary>
    public class UpdateCartResponse
    {
        /// <summary>
        /// The unique identifier of the updated cart
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
        public List<UpdateCartProductsCartResponse> Products { get; set; } = new List<UpdateCartProductsCartResponse>();

        public class UpdateCartProductsCartResponse
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
