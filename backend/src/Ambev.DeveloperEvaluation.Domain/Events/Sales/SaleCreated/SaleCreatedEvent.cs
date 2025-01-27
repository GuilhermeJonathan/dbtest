using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales.SaleCreated
{
    public class SaleCreatedEvent : INotification
    {
        public long SaleId { get; }
        public Guid CartId { get; }

        public SaleCreatedEvent(long saleId, Guid cartId)
        {
            SaleId = saleId;
            CartId = cartId;
        }
    }
}
