using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateCartRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - UserId: Required
        /// - Date: Required   
        /// </remarks>
        public UpdateCartRequestValidator()
        {
            RuleFor(user => user.UserId).NotEmpty();
            RuleFor(user => user.Date).NotEmpty();
        }
    }
}
