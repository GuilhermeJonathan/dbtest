using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Carts
{
    public class Cart : BaseEntity, ICart
    {
        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Cart()
        {
            CreatedAt = DateTime.UtcNow;
            Status = CartStatus.Created;
        }

        /// <summary>
        /// Gets the unique identifier of the cart.
        /// </summary>
        /// <returns>The cart's ID as a string.</returns>
        string ICart.Id => Id.ToString();

        /// <summary>
        /// Gets the date and time when the product was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time when the product was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets the date and time when the product was finished.
        /// </summary>
        public DateTime FinishedAt { get; set; }

        /// <summary>
        /// Gets the cart's User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets the cart's current status.
        /// </summary>
        public CartStatus Status { get; set; } = CartStatus.Created;

        /// <summary>
        /// Gets the cart's Products.
        /// </summary>
        public List<ProductCart> ProductsCart { get; set; } = new List<ProductCart>();

        /// <summary>
        /// Set a User to the cart.
        /// </summary>
        /// <param name="user">The user to add.</param>
        public void SetUser(User user)
        {
            User = user;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetClosed()
        {
            Status = CartStatus.Closed;
            FinishedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Adds a product to the cart.
        /// </summary>
        /// <param name="product">The product to add.</param>
        public void AddProductCart(List<ProductCart> productsCart)
        {
            ProductsCart.AddRange(productsCart);
            UpdatedAt = DateTime.UtcNow;
        }
        
        /// <summary>
        /// Calculates the total price for all products in the cart after applying discounts.
        /// </summary>
        /// <returns>The total price amount.</returns>
        public decimal GetTotal()
        {
            return ProductsCart.Sum(productCart => productCart.TotalPrice);
        }

        /// <summary>
        /// Calculates the total discounts for all products in the cart.
        /// </summary>
        /// <returns>The total discount amount.</returns>
        public decimal GetTotalDisccounts()
        {
            return ProductsCart.Sum(productCart => productCart.Discount * productCart.Quantity);
        }
    }
}
