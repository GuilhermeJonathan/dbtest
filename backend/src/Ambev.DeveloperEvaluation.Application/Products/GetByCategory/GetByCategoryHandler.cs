using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using static Ambev.DeveloperEvaluation.Application.Products.GetByCategory.GetByCategoryResult;

namespace Ambev.DeveloperEvaluation.Application.Products.GetByCategory;

/// <summary>
/// Handler for processing GetByCategoryCommand requests
/// </summary>
public class GetByCategoryHandler : IRequestHandler<GetByCategoryCommand, GetByCategoryResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetByCategoryHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetByCategoryCommand</param>
    public GetByCategoryHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetByCategoryCommand request
    /// </summary>
    /// <param name="request">The GetByCategory command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Product details if found</returns>
    public async Task<GetByCategoryResult> Handle(GetByCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetByCategoryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var orderDescending = request.Order?.Contains("desc") ?? false;
        var products = await _productRepository.GetPagedProductsAsync(request.Page, request.Size, request.Order, orderDescending,
            request.Category, cancellationToken);

        var totalProducts = await _productRepository.GetTotalCountAsync(request.Category, cancellationToken);
        var totalPages = (int)Math.Ceiling((double)totalProducts / request.Size);

        var result = new GetByCategoryResult
        {
            Products = _mapper.Map<List<ProductResult>>(products),
            CurrentPage = request.Page,
            TotalPages = totalPages,
            TotalItems = totalProducts
        };

        return result;
    }
}
