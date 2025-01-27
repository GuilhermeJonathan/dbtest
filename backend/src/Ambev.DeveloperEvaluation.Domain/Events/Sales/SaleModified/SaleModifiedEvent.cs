using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales.SaleModified
{
    public class SaleModifiedEvent : INotification
    {
        public long SaleId { get; }

        public SaleModifiedEvent(long saleId)
        {
            SaleId = saleId;
        }
    }
}
