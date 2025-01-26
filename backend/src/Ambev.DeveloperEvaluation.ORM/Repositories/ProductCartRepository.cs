using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductCartRepository : IProductCartRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of ProductCartRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public ProductCartRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new ProductCart in the database
        /// </summary>
        /// <param name="productCart">The ProductCart to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created ProductCart</returns>
        public async Task<ProductCart> CreateAsync(ProductCart productCart, CancellationToken cancellationToken = default)
        {
            await _context.ProductsCarts.AddAsync(productCart, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return productCart;
        }

        /// <summary>
        /// Deletes all ProductCart by CartId from the database
        /// </summary>
        /// <param name="cartId">The unique identifier of the Cart to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the ProductCart was deleted, false if not found</returns>
        public async Task<bool> DeleteByCartAsync(Guid cartId, CancellationToken cancellationToken = default)
        {
            var productsCart = await GetByCartIdAsync(cartId, cancellationToken);
            if (productsCart == null || !productsCart.Any())
                return false;

            _context.ProductsCarts.RemoveRange(productsCart);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Retrieves a ProductCart by CartId
        /// </summary>
        /// <param name="cartId">The unique identifier of the Cart</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The ProductCart if found, null otherwise</returns>
        public async Task<List<ProductCart>> GetByCartIdAsync(Guid cartId, CancellationToken cancellationToken = default)
        {
            var query = _context.ProductsCarts.Include(a => a.Cart).AsQueryable();
            query = query.Where(p => p.Cart.Id == cartId);
            return await query.ToListAsync(cancellationToken);
        }
    }
}
