using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales.SaleModified
{
    public class SaleModifiedEventHandler : INotificationHandler<SaleModifiedEvent>
    {
        private readonly ILogger<SaleModifiedEventHandler> _logger;

        public SaleModifiedEventHandler(ILogger<SaleModifiedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(SaleModifiedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Sale modified with ID: {notification.SaleId}");
            return Task.CompletedTask;
        }
    }
}
