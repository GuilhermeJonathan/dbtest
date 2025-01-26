using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using static Ambev.DeveloperEvaluation.Application.Carts.ListCarts.ListCartsResult;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Handler for processing ListCartsCommand requests
/// </summary>
public class ListCartsHandler : IRequestHandler<ListCartsCommand, ListCartsResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListCartsHandler
    /// </summary>
    /// <param name="cartRepository">The cart repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for ListCartsCommand</param>
    public ListCartsHandler(
        ICartRepository cartRepository,
        IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListCartsCommand request
    /// </summary>
    /// <param name="command">The ListProducts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Cart details if found</returns>
    public async Task<ListCartsResult> Handle(ListCartsCommand command, CancellationToken cancellationToken)
    {
        var validator = new ListCartsValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var orderDescending = command.Order?.Contains("desc") ?? false;
        var carts = await _cartRepository.GetPagedProductsAsync(command.Page, command.Size, command.Order, orderDescending,
            command.UserId, cancellationToken);

        var totalCarts = await _cartRepository.GetTotalCountAsync(command.UserId, cancellationToken);
        var totalPages = (int)Math.Ceiling((double)totalCarts / command.Size);

        var result = new ListCartsResult
        {
            Carts = _mapper.Map<List<CartResult>>(carts),
            CurrentPage = command.Page,
            TotalPages = totalPages,
            TotalItems = totalCarts
        };

        return result;
    }
}
