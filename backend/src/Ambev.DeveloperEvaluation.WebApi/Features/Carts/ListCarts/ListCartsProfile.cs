using Ambev.DeveloperEvaluation.Application.Carts.ListCarts;
using AutoMapper;
using static Ambev.DeveloperEvaluation.Application.Carts.ListCarts.ListCartsResult;
using static Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts.ListCartsResponse;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

/// <summary>
/// Profile for mapping ListCarts feature requests to commands
/// </summary>
public class ListCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListCarts feature
    /// </summary>
    public ListCartsProfile()
    {
        CreateMap<ListCartsRequest, ListCartsCommand>().ReverseMap();
        CreateMap<ListCartsResult, ListCartsResponse>().ReverseMap();
        CreateMap<CartResult, CartsResponse>().ReverseMap();
        CreateMap<CartResult.ListCartsProductsResult, CartsResponse.ListCartsProductsResponse>().ReverseMap();
    }
}
