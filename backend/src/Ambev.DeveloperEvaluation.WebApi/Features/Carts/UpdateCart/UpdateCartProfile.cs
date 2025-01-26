using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartProfile : Profile
    {
        public UpdateCartProfile()
        {
            CreateMap<UpdateCartRequest, UpdateCartCommand>();
            CreateMap<UpdateCartRequest.UpdateCartProductsRequest, UpdateCartCommand.UpdateCartCommandProductsCartCommand>();
            CreateMap<UpdateCartResult, UpdateCartResponse>().ReverseMap();
            CreateMap<UpdateCartResult.ProductsResult, UpdateCartResponse.UpdateCartProductsCartResponse>().ReverseMap();
        }
    }
}
