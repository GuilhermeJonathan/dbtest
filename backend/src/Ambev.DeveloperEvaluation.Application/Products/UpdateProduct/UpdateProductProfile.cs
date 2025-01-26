using Ambev.DeveloperEvaluation.Domain.Entities.Products;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Profile for mapping between Product entity and UpdateProductResponse
/// </summary>
public class UpdateProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateProduct operation
    /// </summary>
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductCommand, Product>().ReverseMap();
        CreateMap<Product, UpdateProductResult>().ReverseMap();
        CreateMap<Rating, UpdateProductResult.RatingResult>().ReverseMap();
    }
}
