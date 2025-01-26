using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

/// <summary>
/// Validator for GetUserCommand
/// </summary>
public class ListUsersValidator : AbstractValidator<ListUsersCommand>
{
    /// <summary>
    /// Initializes validation rules for GetUserCommand
    /// </summary>
    public ListUsersValidator()
    {
    }
}
