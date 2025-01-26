using Ambev.DeveloperEvaluation.Domain.Entities.Products;
using AutoMapper;
using static Ambev.DeveloperEvaluation.Application.Products.ListProducts.ListProductsResult;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

/// <summary>
/// Profile for mapping between Product entity and GetProductResponse
/// </summary>
public class ListProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProduct operation
    /// </summary>
    public ListProductsProfile()
    {
        CreateMap<Product, ProductResult>();
        CreateMap<Rating, ProductResult.RatingResult>();
    }
}
