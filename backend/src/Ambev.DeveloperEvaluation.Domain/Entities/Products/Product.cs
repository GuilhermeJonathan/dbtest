using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Products
{
    public class Product : BaseEntity, IProduct
    {
        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the unique identifier of the user.
        /// </summary>
        /// <returns>The user's ID as a string.</returns>
        string IProduct.Id => Id.ToString();


        /// <summary>
        /// Gets the date and time when the product was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the product's Title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's Price.
        /// </summary>
        public decimal Price { get; set; } = 0;

        /// <summary>
        /// Gets the product's Description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's category.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's image.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product's rating.
        /// </summary>
        public Rating Rating { get; set; } = new Rating();
    }
}
