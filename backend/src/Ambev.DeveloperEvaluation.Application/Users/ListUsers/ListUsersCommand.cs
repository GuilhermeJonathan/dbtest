using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

/// <summary>
/// Command for retrieving a list of all users
/// </summary>
public record ListUsersCommand : IRequest<ListUsersResult>
{
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
