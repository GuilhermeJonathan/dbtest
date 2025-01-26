using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities.Products;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Carts
{
    public class ProductCart : BaseEntity
    {
        public ProductCart() { CreatedAt = DateTime.UtcNow; }

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

        /// <summary>
        /// Gets the ProductCart's Price.
        /// </summary>
        public decimal Price { get; set; } = 0;

        /// <summary>
        /// Gets the ProductCart's TotalPrice.
        /// </summary>
        public decimal TotalPrice { get; set; } = 0;

        /// <summary>
        /// Gets the ProductCart's Discount.
        /// </summary>
        public decimal Discount { get; set; } = 0;

        /// <summary>
        /// Gets the date and time when the product was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
