using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales.ItemCancelled
{
    public class ItemCancelledEvent : INotification
    {
        public long SaleId { get; }
        public Guid ProductId { get; }

        public ItemCancelledEvent(long saleId, Guid productId)
        {
            SaleId = saleId;
            ProductId = productId;
        }
    }
}
