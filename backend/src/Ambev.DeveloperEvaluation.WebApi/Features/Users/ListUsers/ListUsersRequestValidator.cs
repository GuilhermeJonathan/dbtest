using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

/// <summary>
/// Validator for ListUsersRequest
/// </summary>
public class ListUsersRequestValidator : AbstractValidator<ListUsersRequest>
{
    /// <summary>
    /// Initializes validation rules for ListUsersRequest
    /// </summary>
    public ListUsersRequestValidator()
    {        
    }
}
