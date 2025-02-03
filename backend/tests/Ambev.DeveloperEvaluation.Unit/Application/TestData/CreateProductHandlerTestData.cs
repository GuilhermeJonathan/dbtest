using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class CreateProductHandlerTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid Product entities.
        /// The generated products will have valid:        
        /// </summary>
        private static readonly Faker<CreateProductCommand> createProductHandlerFaker = new Faker<CreateProductCommand>()
            .RuleFor(p => p.Title, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0])
            .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000))
            .RuleFor(p => p.Image, f => f.Internet.Avatar())
            .RuleFor(p => p.Rate, f => f.Random.Decimal(1, 1000))
            .RuleFor(p => p.Count, f => f.Random.Int(1, 1000));

        /// <summary>
        /// Generates a valid product entity with randomized data.
        /// The generated product will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid Product entity with randomly generated data.</returns>
        public static CreateProductCommand GenerateValidCommand()
        {
            return createProductHandlerFaker
                .Generate();
        }
    }
}
