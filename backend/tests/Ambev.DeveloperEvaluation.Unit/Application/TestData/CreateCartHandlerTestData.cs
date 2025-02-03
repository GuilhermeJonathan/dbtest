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
        /// Configures the Faker to generate CreateCartCommand entities with a product having more than 20 items.
        /// </summary>
        private static readonly Faker<ProductsCartCommand> createProductWithMoreThan20ItemsFaker = new Faker<ProductsCartCommand>()
            .RuleFor(p => p.ProductId, f => f.Random.Guid())
            .RuleFor(p => p.Quantity, f => f.Random.Int(21, 30));

        /// <summary>
        /// Configures the Faker to generate CreateCartCommand entities with a product having less than 3 items.
        /// </summary>
        private static readonly Faker<ProductsCartCommand> createProductWithLessThan3ItemsFaker = new Faker<ProductsCartCommand>()
            .RuleFor(p => p.ProductId, f => f.Random.Guid())
            .RuleFor(p => p.Quantity, f => f.Random.Int(1, 2));


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

        /// <summary>
        /// Generates a cart entity with a product having more than 20 items.
        /// </summary>
        /// <returns>A Cart entity with a product having more than 20 items.</returns>
        public static CreateCartCommand GenerateCommandWithMoreThan20Items()
        {
            var command = createCartHandlerFaker.Generate();
            command.Products = createProductWithMoreThan20ItemsFaker.Generate(1);
            return command;
        }

        /// <summary>
        /// Generates a valid cart entity with a specified number of items.
        /// </summary>
        /// <param name="numberOfItems">The number of items to add to the cart.</param>
        /// <returns>A valid Cart entity with the specified number of items.</returns>
        public static CreateCartCommand GenerateValidCommandWithItems(int numberOfItems)
        {
            var command = createCartHandlerFaker.Generate();
            command.Products = createProductWithLessThan3ItemsFaker.Generate(numberOfItems);
            return command;
        }
    }
}
