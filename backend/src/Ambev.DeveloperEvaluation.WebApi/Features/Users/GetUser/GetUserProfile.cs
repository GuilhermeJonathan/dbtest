using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class GetUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public GetUserProfile()
    {
        CreateMap<Guid, Application.Users.GetUser.GetUserCommand>()
            .ConstructUsing(id => new Application.Users.GetUser.GetUserCommand(id));

        CreateMap<GetUserResult, GetUserResponse>().ReverseMap();
        CreateMap<GetUserResult.NameResult, GetUserResponse.NameResponse>().ReverseMap();
        CreateMap<GetUserResult.AddressResult, GetUserResponse.AddressResponse>().ReverseMap();
        CreateMap<GetUserResult.GeolocationResult, GetUserResponse.GeolocationResponse>().ReverseMap();
    }
}
