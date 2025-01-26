using Ambev.DeveloperEvaluation.Domain.Entities.Products;
using AutoMapper;
using static Ambev.DeveloperEvaluation.Application.Products.GetByCategory.GetByCategoryResult;

namespace Ambev.DeveloperEvaluation.Application.Products.GetByCategory;

/// <summary>
/// Profile for mapping between Product entity and GetByCategoryResponse
/// </summary>
public class GetByCategoryProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetByCategory operation
    /// </summary>
    public GetByCategoryProfile()
    {
        CreateMap<Product, ProductResult>();
        CreateMap<Rating, ProductResult.RatingResult>();
    }
}
