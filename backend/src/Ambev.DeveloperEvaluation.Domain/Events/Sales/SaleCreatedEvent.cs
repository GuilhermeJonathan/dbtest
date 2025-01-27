using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales
{
    public class SaleCreatedEvent : INotification
    {
        public long SaleId { get; }
        public long CartId { get; }

        public SaleCreatedEvent(long saleId, long cartId)
        {
            SaleId = saleId;
            CartId = cartId;
        }
    }
}
