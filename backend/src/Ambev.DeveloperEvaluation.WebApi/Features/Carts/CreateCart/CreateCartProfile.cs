using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Profile for mapping between Application and API CreateCart responses
/// </summary>
public class CreateCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateCart feature
    /// </summary>
    public CreateCartProfile()
    {
        CreateMap<CreateCartRequest, CreateCartCommand>().ReverseMap();
        CreateMap<CreateCartRequest.ProductsRequest, CreateCartCommand.ProductsCartCommand>().ReverseMap();
        CreateMap<CreateCartResult, CreateCartResponse>();
    }
}
