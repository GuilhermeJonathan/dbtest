using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Command for retrieving a list of all carts
/// </summary>
public record ListCartsCommand : IRequest<ListCartsResult>
{
    /// <summary>
    /// The UserId
    /// </summary>
    public Guid UserId { get; set; } = Guid.Empty;

    /// <summary>
    /// Page number
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// Page Size
    /// </summary>
    public int Size { get; set; } = 10;

    /// <summary>
    /// Order column
    /// </summary>
    public string Order { get; set; } = string.Empty;
}
