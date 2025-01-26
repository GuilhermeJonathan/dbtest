using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using static Ambev.DeveloperEvaluation.Application.Users.ListUsers.ListUsersResult;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class ListUsersProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public ListUsersProfile()
    {
        CreateMap<User, UserResult>();
    }
}
