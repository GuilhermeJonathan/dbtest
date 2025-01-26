namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface ICart
    {
        /// <summary>
        /// Gets the unique identifier of the Cart.
        /// </summary>
        /// <returns>The cart's ID as a string.</returns>
        public string Id { get; }
    }
}
