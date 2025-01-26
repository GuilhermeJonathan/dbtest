using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using static Ambev.DeveloperEvaluation.Application.Products.ListProducts.ListProductsResult;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

/// <summary>
/// Handler for processing ListProductsCommand requests
/// </summary>
public class ListProductsHandler : IRequestHandler<ListProductsCommand, ListProductsResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProductsHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for ListProductsCommand</param>
    public ListProductsHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProductsCommand request
    /// </summary>
    /// <param name="request">The ListProducts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Product details if found</returns>
    public async Task<ListProductsResult> Handle(ListProductsCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListProductsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var orderDescending = request.Order?.Contains("desc") ?? false;
        var products = await _productRepository.GetPagedProductsAsync(request.Page, request.Size, request.Order, orderDescending, cancellationToken);
        var totalProducts = await _productRepository.GetTotalCountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((double)totalProducts / request.Size);

        var result = new ListProductsResult
        {
            Products = _mapper.Map<List<ProductResult>>(products),
            CurrentPage = request.Page,
            TotalPages = totalPages,
            TotalItems = totalProducts
        };

        return result;
    }
}
