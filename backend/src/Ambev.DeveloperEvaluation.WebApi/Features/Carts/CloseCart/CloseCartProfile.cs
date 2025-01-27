using Ambev.DeveloperEvaluation.Application.Carts.CloseCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CloseCart;

/// <summary>
/// Profile for mapping CloseCart feature requests to commands
/// </summary>
public class CloseCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CloseCart feature
    /// </summary>
    public CloseCartProfile()
    {
        CreateMap<Guid, CloseCartCommand>()
            .ConstructUsing(id => new CloseCartCommand(id));
    }
}
