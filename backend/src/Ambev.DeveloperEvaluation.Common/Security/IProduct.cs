namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface IProduct
    {
        /// <summary>
        /// Gets the unique identifier of the user.
        /// </summary>
        /// <returns>The user's ID as a string.</returns>
        public string Id { get; }
    }
}
