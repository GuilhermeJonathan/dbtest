using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales.ItemCancelled
{
    public class ItemCancelledEventHandler : INotificationHandler<ItemCancelledEvent>
    {
        private readonly ILogger<ItemCancelledEventHandler> _logger;

        public ItemCancelledEventHandler(ILogger<ItemCancelledEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ItemCancelledEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Item Cancelled with Sale ID: {notification.SaleId} for Product ID: {notification.ProductId}");
            return Task.CompletedTask;
        }
    }
}
