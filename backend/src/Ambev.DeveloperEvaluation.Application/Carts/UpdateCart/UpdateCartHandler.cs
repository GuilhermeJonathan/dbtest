using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Handler for processing UpdateCartCommand requests
/// </summary>
public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductCartRepository _productCartRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateCartHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateCartCommand</param>
    public UpdateCartHandler(IMapper mapper, IProductRepository productRepository, ICartRepository cartRepository, IUserRepository userRepository, IProductCartRepository productCartRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _cartRepository = cartRepository;
        _userRepository = userRepository;
        _productCartRepository = productCartRepository;
    }

    /// <summary>
    /// Handles the UpdateCartHandler request
    /// </summary>
    /// <param name="command">The UpdateCart command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product details</returns>
    public async Task<UpdateCartResult> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingCart = await _cartRepository.GetByIdAsync(command.Id, cancellationToken);
        if (existingCart == null)
            throw new InvalidOperationException($"Cart with id {command.Id} not exists");

        if (command.Products != null && command.Products.Any())
        {
            var deletedProducts = await _productCartRepository.DeleteByCartAsync(command.Id, cancellationToken);

            if (deletedProducts)
            {
                existingCart = await _cartRepository.UpdateAsync(existingCart, cancellationToken);
            }

            foreach (var item in command.Products)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
                if (product == null)
                    throw new KeyNotFoundException($"Product with ID {item.ProductId} not found");

                var productCart = new ProductCart()
                {
                    Product = product,
                    Quantity = item.Quantity,
                    Cart = existingCart
                };

                await _productCartRepository.CreateAsync(productCart, cancellationToken);
            }
        }

        await _cartRepository.UpdateAsync(existingCart, cancellationToken);

        return new UpdateCartResult
        {
            Id = existingCart.Id,
            UserId = existingCart.User.Id,
            Date = existingCart.CreatedAt,
            Products = existingCart.ProductsCart.Select(o => new UpdateCartResult.ProductsResult
            {
                ProductId = o.Id,
                Quantity = o.Quantity
            }).ToList()
        };
    }
}
