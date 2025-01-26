using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Command for updating a cart.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating a cart
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateCartResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateCartValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateCartCommand : IRequest<UpdateCartResult>
{
    // <summary>
    /// Gets or sets the Id to be updated.
    /// </summary>
    public Guid Id { get; set; } = Guid.Empty;

    // <summary>
    /// Gets or sets the UserId to be updated.
    /// </summary>
    public Guid UserId { get; set; } = Guid.Empty;

    /// <summary>
    /// Gets the cart's update date.    
    /// </summary>
    public DateTime Date { get; set; } = DateTime.Now;

    public List<UpdateCartCommandProductsCartCommand> Products { get; set; } = new List<UpdateCartCommandProductsCartCommand>();

    public class UpdateCartCommandProductsCartCommand
    {
        /// <summary>
        /// Gets or sets the ProductId to be created.
        /// </summary>
        public Guid ProductId { get; set; } = Guid.Empty;

        /// <summary>
        /// Gets or sets the Quantity for the product.
        /// </summary>
        public int Quantity { get; set; } = 0;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateCartValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}