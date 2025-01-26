using Ambev.DeveloperEvaluation.Application.Products.ListProducts;
using AutoMapper;
using static Ambev.DeveloperEvaluation.Application.Products.ListProducts.ListProductsResult;
using static Ambev.DeveloperEvaluation.WebApi.Features.Produtcs.ListProducts.ListProductsResponse;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtcs.ListProducts;

/// <summary>
/// Profile for mapping ListProducts feature requests to commands
/// </summary>
public class ListProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProducts feature
    /// </summary>
    public ListProductsProfile()
    {
        CreateMap<ListProductsRequest, ListProductsCommand>().ReverseMap();
        CreateMap<ListProductsResult, ListProductsResponse>().ReverseMap();
        CreateMap<ProductResult, ProductsResponse>().ReverseMap();
        CreateMap<ProductResult.RatingResult, ProductsResponse.ListProductsRatingResponse>().ReverseMap();
    }
}
