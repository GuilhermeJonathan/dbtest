using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.Entities.Products;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Contains unit tests for the <see cref="CreateCartHandler"/> class.
    /// </summary>
    public class CreateCartHandlerTests
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly CreateCartHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartHandlerTests "/> class.
        /// Sets up the test dependencies and creates fake data generators.
        /// </summary>
        public CreateCartHandlerTests()
        {
            _cartRepository = Substitute.For<ICartRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _userRepository = Substitute.For<IUserRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateCartHandler(_mapper, _cartRepository, _productRepository, _userRepository);
        }

        /// <summary>
        /// Tests that a valid cart creation request is handled successfully.
        /// </summary>
        [Fact(DisplayName = "Given valid product data When creating cart Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = CreateCartHandlerTestData.GenerateValidCommand();
            var user = new User { Id = command.UserId };

            var cart = new Cart
            {
                Id = Guid.NewGuid(),
                User = user,
                Store = command.Store,
                ProductsCart = new List<ProductCart>()
            };

            var products = new List<Product>();

            foreach (var productCommand in command.Products)
            {
                var product = new Product
                {
                    Id = productCommand.ProductId
                };

                products.Add(product);

                cart.ProductsCart.Add(new ProductCart
                {
                    Product = product,
                    Cart = cart,
                    Quantity = productCommand.Quantity
                });
            }

            var result = new CreateCartResult
            {
                Id = cart.Id,
            };

            _mapper.Map<Cart>(command).Returns(cart);
            _mapper.Map<CreateCartResult>(cart).Returns(result);

            _cartRepository.CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>())
               .Returns(cart);

            _userRepository.GetByIdAsync(command.UserId, Arg.Any<CancellationToken>())
                .Returns(user);

            foreach (var product in products)
            {
                _productRepository.GetByIdAsync(product.Id, Arg.Any<CancellationToken>())
                    .Returns(product);
            }

            // When
            var createCartResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            createCartResult.Should().NotBeNull();
            createCartResult.Id.Should().Be(cart.Id);
            await _cartRepository.Received(1).CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>());
        }

        /// <summary>
        /// Tests that an invalid cart creation request throws a validation exception.
        /// </summary>
        [Fact(DisplayName = "Given invalid cart data When creating cart Then throws validation exception")]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Given
            var command = new CreateCartCommand(); // Empty command will fail validation

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<FluentValidation.ValidationException>();
        }

        /// <summary>
        /// Tests that creating a cart with more than 20 identical items throws an exception.
        /// </summary>
        [Fact(DisplayName = "Given more than 20 identical items When creating cart Then throws exception")]
        public async Task Handle_MoreThan20IdenticalItems_ThrowsException()
        {
            // Given
            var command = CreateCartHandlerTestData.GenerateCommandWithMoreThan20Items();
            var user = new User { Id = command.UserId };

            var cart = new Cart
            {
                Id = Guid.NewGuid(),
                User = user,
                Store = command.Store,
                ProductsCart = new List<ProductCart>()
            };


            var products = new List<Product>();

            foreach (var productCommand in command.Products)
            {
                var product = new Product
                {
                    Id = productCommand.ProductId
                };

                products.Add(product);

                cart.ProductsCart.Add(new ProductCart
                {
                    Product = product,
                    Cart = cart,
                    Quantity = productCommand.Quantity
                });
            }

            var result = new CreateCartResult
            {
                Id = cart.Id,
            };

            _mapper.Map<Cart>(command).Returns(cart);
            _mapper.Map<CreateCartResult>(cart).Returns(result);

            _cartRepository.CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>())
               .Returns(cart);

            _userRepository.GetByIdAsync(command.UserId, Arg.Any<CancellationToken>())
                .Returns(user);

            foreach (var product in products)
            {
                _productRepository.GetByIdAsync(product.Id, Arg.Any<CancellationToken>())
                    .Returns(product);
            }

            // When
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("It's not possible to sell above 20 identical items");
        }
    }
}
