using Ambev.DeveloperEvaluation.Domain.Entities.Carts;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Cart>> GetPagedProductsAsync(int pageNumber, int pageSize, string orderByColumn, bool orderByDescending, Guid? userId, CancellationToken cancellationToken = default);
        Task<int> GetTotalCountAsync(Guid? userId, CancellationToken cancellationToken = default);
        Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default);
    }
}
