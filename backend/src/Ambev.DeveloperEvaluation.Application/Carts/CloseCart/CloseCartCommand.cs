using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CloseCart;

/// <summary>
/// Command for closing a cart
/// </summary>
public record CloseCartCommand : IRequest<CloseCartResponse>
{
    /// <summary>
    /// The unique identifier of the cart to close
    /// </summary>
    public Guid Id { get; }

    public CloseCartCommand()
    {
        
    }

    /// <summary>
    /// Initializes a new instance of CloseCartCommand
    /// </summary>
    /// <param name="id">The ID of the cart to close</param>
    public CloseCartCommand(Guid id)
    {
        Id = id;
    }
}
