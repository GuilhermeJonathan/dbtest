using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Bogus;
using static Ambev.DeveloperEvaluation.Application.Carts.CreateCart.CreateCartCommand;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class CreateCartHandlerTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid Cart entities.
        /// The generated products will have valid:        
        /// - UserId
        /// - Date
        /// - Store
        /// - Products
        /// </summary>
        private static readonly Faker<CreateCartCommand> createCartHandlerFaker = new Faker<CreateCartCommand>()
            .RuleFor(p => p.UserId, f => f.Random.Guid())
            .RuleFor(p => p.Date, f => DateTime.Now)
            .RuleFor(p => p.Store, f => f.Commerce.Department())
            .RuleFor(p => p.Products, f => createProductFaker.Generate(3))
            ;

        /// <summary>
        /// Configures the Faker to generate valid CreatecartCommand entities.
        /// The generated carts will have valid:
        /// - ProductId
        /// - Quantity
        /// - Price
        /// - Stock
        /// </summary>
        private static readonly Faker<ProductsCartCommand> createProductFaker = new Faker<ProductsCartCommand>()
            .RuleFor(p => p.ProductId, f => f.Random.Guid())
            .RuleFor(p => p.Quantity, f => f.Random.Int(1, 10));

        /// <summary>
        /// Generates a valid cart entity with randomized data.
        /// The generated cart will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid Cart entity with randomly generated data.</returns>
        public static CreateCartCommand GenerateValidCommand()
        {
            return createCartHandlerFaker
                .Generate();
        }
    }
}
