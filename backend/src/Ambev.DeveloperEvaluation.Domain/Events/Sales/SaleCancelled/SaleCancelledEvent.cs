using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales.SaleCancelled
{
    public class SaleCancelledEvent : INotification
    {
        public long SaleId { get; }

        public SaleCancelledEvent(long saleId)
        {
            SaleId = saleId;
        }
    }
}
