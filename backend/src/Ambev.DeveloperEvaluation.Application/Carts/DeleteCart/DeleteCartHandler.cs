using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

/// <summary>
/// Handler for processing DeleteCartCommand requests
/// </summary>
public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResponse>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductCartRepository _productCartRepository;

    /// <summary>
    /// Initializes a new instance of DeleteCartHandler
    /// </summary>
    /// <param name="cartRepository">The cart repository</param>
    /// <param name="productCartRepository">The productCart repository</param>
    /// <param name="validator">The validator for DeleteCartCommand</param>
    public DeleteCartHandler(ICartRepository cartRepository, IProductCartRepository productCartRepository)
    {
        _cartRepository = cartRepository;
        _productCartRepository = productCartRepository;
    }

    /// <summary>
    /// Handles the DeleteCartCommand request
    /// </summary>
    /// <param name="command">The DeleteCart command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteCartResponse> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingCart = await _cartRepository.GetByIdAsync(command.Id, cancellationToken);
        if (existingCart == null)
            throw new InvalidOperationException($"Cart with id {command.Id} not exists");

        var deletedProducts = await _productCartRepository.DeleteByCartAsync(command.Id, cancellationToken);

        var success = await _cartRepository.DeleteAsync(command.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Cart with ID {command.Id} not found");

        return new DeleteCartResponse { Success = true };
    }
}
