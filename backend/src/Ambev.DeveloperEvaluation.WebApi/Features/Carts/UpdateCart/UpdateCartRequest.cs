namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    /// <summary>
    /// Represents a request to update a cart in the system.
    /// </summary>
    public class UpdateCartRequest
    {
        // <summary>
        /// Gets or sets the Id to be updated.
        /// </summary>
        public Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// Gets or sets the UserId to be created.
        /// </summary>
        public Guid UserId { get; set; } = Guid.Empty;

        /// <summary>
        /// Gets the cart's create date.    
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;

        public List<UpdateCartProductsRequest> Products { get; set; } = new List<UpdateCartProductsRequest>();

        public class UpdateCartProductsRequest
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
}
