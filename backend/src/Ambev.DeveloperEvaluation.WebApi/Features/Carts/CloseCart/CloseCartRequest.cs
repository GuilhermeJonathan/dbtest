namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CloseCart;

/// <summary>
/// Request model for closing a cart
/// </summary>
public class CloseCartRequest
{
    /// <summary>
    /// The unique identifier of the cart to close
    /// </summary>
    public Guid Id { get; set; }
}
