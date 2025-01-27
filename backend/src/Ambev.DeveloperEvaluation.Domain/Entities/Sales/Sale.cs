using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales
{
    public class Sale : BaseLongEntity
    {
        public Sale()
        {
            CreatedAt = DateTime.UtcNow;
            Status = SaleStatus.Created;
        }

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
        /// Gets the sale's current status.
        /// </summary>
        public SaleStatus Status { get; set; } = SaleStatus.Created;

        /// <summary>
        /// Gets the sales's cart.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Gets the sales's TotalPrice.
        /// </summary>
        public decimal TotalPrice { get; set; } = 0;

        /// <summary>
        /// Gets the sales's TotalDiscount.
        /// </summary>
        public decimal TotalDiscount { get; set; } = 0;
    }
}
