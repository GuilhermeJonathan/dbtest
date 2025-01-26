using Ambev.DeveloperEvaluation.Application.Products.GetByCategory;
using AutoMapper;
using static Ambev.DeveloperEvaluation.Application.Products.GetByCategory.GetByCategoryResult;
using static Ambev.DeveloperEvaluation.WebApi.Features.Produtcs.GetByCategory.GetByCategoryResponse;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtcs.GetByCategory;

/// <summary>
/// Profile for mapping GetByCategory feature requests to commands
/// </summary>
public class GetByCategoryProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetByCategory feature
    /// </summary>
    public GetByCategoryProfile()
    {
        CreateMap<GetByCategoryRequest, GetByCategoryCommand>().ReverseMap();
        CreateMap<GetByCategoryResult, GetByCategoryResponse>().ReverseMap();
        CreateMap<ProductResult, ProductsByCategoryResponse>().ReverseMap();
        CreateMap<ProductResult.RatingResult, ProductsByCategoryResponse.RatingByCategoryResponse>().ReverseMap();
    }
}
