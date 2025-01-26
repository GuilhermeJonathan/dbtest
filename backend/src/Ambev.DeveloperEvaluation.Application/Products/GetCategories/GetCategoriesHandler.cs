using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetCategories;

/// <summary>
/// Handler for processing GetCategoriesCommand requests
/// </summary>
public class GetCategoriesHandler : IRequestHandler<GetCategoriesCommand, GetCategoriesResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetCategoriesHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetCategoriesCommand</param>
    public GetCategoriesHandler(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    /// <summary>
    /// Handles the GetCategoriesCommand request
    /// </summary>
    /// <param name="request">The GetCategories command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The categories details if found</returns>
    public async Task<GetCategoriesResult> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
    {
        var categories = await _productRepository.GetAllCategoriesAsync(cancellationToken);
        if (categories == null || !categories.Any())
            throw new KeyNotFoundException($"Categories empty.");

        return new GetCategoriesResult
        {
            Categories = categories
        };
    }
}
