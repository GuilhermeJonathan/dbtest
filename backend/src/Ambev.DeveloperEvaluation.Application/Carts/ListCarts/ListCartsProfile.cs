using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using AutoMapper;
using static Ambev.DeveloperEvaluation.Application.Carts.ListCarts.ListCartsResult;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Profile for mapping between Cart entity and ListProductsResponse
/// </summary>
public class ListCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListCarts operation
    /// </summary>
    public ListCartsProfile()
    {
        CreateMap<Cart, CartResult>();
        CreateMap<ProductCart, CartResult.ListCartsProductsResult>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            ;

        CreateMap<Cart, CartResult>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
           .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt))
           .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductsCart));
        ;
    }
}
