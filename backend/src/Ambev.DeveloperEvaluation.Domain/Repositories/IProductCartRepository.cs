
using Ambev.DeveloperEvaluation.Domain.Entities.Carts;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductCartRepository
    {
        Task<ProductCart> CreateAsync(ProductCart productCart, CancellationToken cancellationToken = default);
        Task<bool> DeleteByCartAsync(Guid cartId, CancellationToken cancellationToken = default);
    }
}
