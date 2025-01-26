using Ambev.DeveloperEvaluation.Application.Users.ListUsers;
using AutoMapper;
using static Ambev.DeveloperEvaluation.Application.Users.ListUsers.ListUsersResult;
using static Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers.ListUsersResponse;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

/// <summary>
/// Profile for mapping ListUsers feature requests to commands
/// </summary>
public class ListUsersProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListUsers feature
    /// </summary>
    public ListUsersProfile()
    {
        CreateMap<ListUsersRequest, ListUsersCommand>().ReverseMap();
        CreateMap<ListUsersResult, ListUsersResponse>().ReverseMap();
        CreateMap<UserResult, UsersResponse>().ReverseMap();
    }
}
