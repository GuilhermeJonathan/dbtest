using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetCategories;

/// <summary>
/// Command for retrieving a list of Categories
/// </summary>
public record GetCategoriesCommand : IRequest<GetCategoriesResult>
{
}
