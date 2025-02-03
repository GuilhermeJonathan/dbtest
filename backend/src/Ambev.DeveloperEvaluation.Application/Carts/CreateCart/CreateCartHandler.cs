using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Handler for processing CreateCartCommand requests
/// </summary>
public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateCartHandler
    /// </summary>
    /// <param name="cartRepository">The cart repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateCartCommand</param>
    public CreateCartHandler(IMapper mapper, ICartRepository cartRepository, IProductRepository productRepository, IUserRepository userRepository)
    {
        _mapper = mapper;
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Handles the CreateCartCommand request
    /// </summary>
    /// <param name="command">The CreateCart command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created cart details</returns>
    public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {command.UserId} not found");

        var cart = _mapper.Map<Cart>(command);
        cart.SetUser(user);

        if (command.Products != null && command.Products.Any())
        {
            var listProducts = new List<ProductCart>();
            foreach (var item in command.Products)
            {
                if (item.Quantity > 20)
                    throw new InvalidOperationException("It's not possible to sell above 20 identical items");
                
                var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
                if (product == null)
                    throw new KeyNotFoundException($"Product with ID {item.ProductId} not found");

                var discount = DiscountCalculator.CalculateDiscount(item.Quantity);
                var discountedPrice = product.Price * (1 - discount);

                var productCart = new ProductCart()
                {
                    Product = product,
                    Quantity = item.Quantity,
                    Price = product.Price,
                    Discount = discount,
                    TotalPrice = discountedPrice * item.Quantity
                };

                listProducts.Add(productCart);
            }

            cart.AddProductCart(listProducts);

        }
        
        var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);
        var result = _mapper.Map<CreateCartResult>(createdCart);
        result.TotalDiscount = createdCart.GetTotalDisccounts();

        return result;
    }
}
