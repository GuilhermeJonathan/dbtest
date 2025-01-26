using Ambev.DeveloperEvaluation.Application.Products.GetCategories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtcs.GetCategories;

/// <summary>
/// Profile for mapping GetCategories feature requests to commands
/// </summary>
public class GetCategoriesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCategories feature
    /// </summary>
    public GetCategoriesProfile()
    {
        CreateMap<GetCategoriesRequest, GetCategoriesCommand>().ReverseMap();
        CreateMap<GetCategoriesResult, GetCategoriesResponse>().ReverseMap();
    }
}
