using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ICartRepository using Entity Framework Core
    /// </summary>
    public class CartRepository : ICartRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of CartRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public CartRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new cart in the database
        /// </summary>
        /// <param name="cart">The cart to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created user</returns>
        public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            await _context.Carts.AddAsync(cart, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return cart;
        }

        /// <summary>
        /// Retrieves a cart by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the cart</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart if found, null otherwise</returns>
        public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Carts
                .Include(a => a.User)
                .Include(a => a.ProductsCart)
                .ThenInclude(b => b.Product)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        /// <summary>
        /// Update a cart in the database
        /// </summary>
        /// <param name="cart">The cart to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated cart</returns>
        public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return cart;
        }

        /// <summary>
        /// Deletes a Cart from the database
        /// </summary>
        /// <param name="id">The unique identifier of the Cart to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the Cart was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var cart = await GetByIdAsync(id, cancellationToken);
            if (cart == null)
                return false;

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Retrieves a paginated and ordered list of cart
        /// </summary>
        /// <param name="pageNumber">The page number</param>
        /// <param name="pageSize">The size of the page</param>
        /// <param name="orderByColumn">The column to order by</param>
        /// <param name="orderByDescending">Whether to order by descending</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A paginated and ordered list of cart</returns>
        public async Task<List<Cart>> GetPagedProductsAsync(int pageNumber, int pageSize, string orderByColumn,
            bool orderByDescending, Guid? userId, CancellationToken cancellationToken = default)
        {
            var query = _context.Carts
                .Include(a => a.User)
                .Include(a => a.ProductsCart)
                .Include(a => a.ProductsCart).ThenInclude(b => b.Product)
                .AsQueryable();

            if (userId.HasValue)
            {
                query = query.Where(p => p.User.Id == userId);
            }

            if (!string.IsNullOrEmpty(orderByColumn))
            {
                var parameter = Expression.Parameter(typeof(Cart), "u");
                var property = Expression.Property(parameter, orderByColumn);
                var lambda = Expression.Lambda(property, parameter);

                var methodName = orderByDescending ? "OrderByDescending" : "OrderBy";
                var method = typeof(Queryable).GetMethods()
                    .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(Cart), property.Type);

                query = (IQueryable<Cart>)method.Invoke(null, new object[] { query, lambda });
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a total carts by userid
        /// </summary>
        public async Task<int> GetTotalCountAsync(Guid? userId, CancellationToken cancellationToken = default)
        {
            var query = _context.Carts.AsQueryable();

            if (userId.HasValue)
            {
                query = query.Where(p => p.User.Id == userId);
            }

            return await query.CountAsync(cancellationToken);
        }

    }
}
