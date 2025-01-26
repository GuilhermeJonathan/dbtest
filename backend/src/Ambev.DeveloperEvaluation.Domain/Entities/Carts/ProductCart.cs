using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities.Products;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Carts
{
    public class ProductCart : BaseEntity
    {
        public ProductCart() { }

        /// <summary>
        /// Gets the ProductCart's Cart.
        /// </summary>
        public Cart Cart { get; set; } = new Cart();

        /// <summary>
        /// Gets the ProductCart's Product.
        /// </summary>
        public Product Product { get; set; } = new Product();

        /// <summary>
        /// Gets the ProductCart's Quantity.
        /// </summary>
        public int Quantity { get; set; } = 0;
    }
}
