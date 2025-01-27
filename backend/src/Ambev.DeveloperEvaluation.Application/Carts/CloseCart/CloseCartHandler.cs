using Ambev.DeveloperEvaluation.Domain.Events.Sales.SaleCreated;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CloseCart;

/// <summary>
/// Handler for processing CloseCartCommand requests
/// </summary>
public class CloseCartHandler : IRequestHandler<CloseCartCommand, CloseCartResponse>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductCartRepository _productCartRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of CloseCartHandler
    /// </summary>
    /// <param name="cartRepository">The cart repository</param>
    /// <param name="productCartRepository">The productCart repository</param>
    /// <param name="validator">The validator for CloseCartCommand</param>
    public CloseCartHandler(ICartRepository cartRepository, IProductCartRepository productCartRepository, ISaleRepository saleRepository, IMediator mediator)
    {
        _cartRepository = cartRepository;
        _productCartRepository = productCartRepository;
        _saleRepository = saleRepository;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the CloseCartCommand request
    /// </summary>
    /// <param name="command">The CloseCart command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the close operation</returns>
    public async Task<CloseCartResponse> Handle(CloseCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new CloseCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingCart = await _cartRepository.GetByIdAsync(command.Id, cancellationToken);
        if (existingCart == null)
            throw new InvalidOperationException($"Cart with id {command.Id} not exists");

        if (existingCart.Status != Domain.Enums.CartStatus.Created)
            throw new InvalidOperationException($"Cart with id {command.Id} cannot be closed");

        existingCart.SetClosed();
        existingCart = await _cartRepository.UpdateAsync(existingCart, cancellationToken);

        var newSale = new Domain.Entities.Sales.Sale()
        {
            Cart = existingCart,
            TotalDiscount = existingCart.GetTotalDisccounts(),
            TotalPrice = existingCart.GetTotal()
        };

        var sale = await _saleRepository.CreateAsync(newSale, cancellationToken);

        //event SaleCreatedEvent
        await _mediator.Publish(new SaleCreatedEvent(sale.Id, existingCart.Id), cancellationToken);

        return new CloseCartResponse { Success = true };
    }
}
