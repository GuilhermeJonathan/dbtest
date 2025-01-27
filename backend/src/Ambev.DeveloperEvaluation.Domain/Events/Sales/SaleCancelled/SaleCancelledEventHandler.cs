using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales.SaleCancelled
{
    public class SaleCancelledEventHandler : INotificationHandler<SaleCancelledEvent>
    {
        private readonly ILogger<SaleCancelledEventHandler> _logger;

        public SaleCancelledEventHandler(ILogger<SaleCancelledEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(SaleCancelledEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Sale cancelled with ID: {notification.SaleId}");
            return Task.CompletedTask;
        }
    }
}
