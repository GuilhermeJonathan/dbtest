using Ambev.DeveloperEvaluation.Application.Carts.CloseCart;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class CloseCartHandlerTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid Cart entities.
        /// The generated cart will have valid:
        /// - Id
        /// </summary>
        private static readonly Faker<CloseCartCommand> closeCartHandlerFaker = new Faker<CloseCartCommand>()
           .CustomInstantiator(f => new CloseCartCommand(f.Random.Guid()));

        /// <summary>
        /// Generates a valid cart entity with randomized data.
        /// The generated cart will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid Cart entity with randomly generated data.</returns>
        public static CloseCartCommand GenerateValidCommand()
        {
            return closeCartHandlerFaker
                .Generate();
        }
    }
}
