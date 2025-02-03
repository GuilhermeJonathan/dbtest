using Ambev.DeveloperEvaluation.Application.Carts.CloseCart;
using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.Entities.Products;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using MediatR;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Contains unit tests for the <see cref="CloseCartHandler"/> class.
    /// </summary>
    public class CloseCartHandlerTests
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductCartRepository _productCartRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IMediator _mediator;
        private readonly CloseCartHandler _handler;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloseCartHandlerTests "/> class.
        /// Sets up the test dependencies and creates fake data generators.
        /// </summary>
        public CloseCartHandlerTests()
        {
            _cartRepository = Substitute.For<ICartRepository>();
            _productCartRepository = Substitute.For<IProductCartRepository>();
            _saleRepository = Substitute.For<ISaleRepository>();
            _mediator = Substitute.For<IMediator>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CloseCartHandler(_cartRepository, _productCartRepository, _saleRepository, _mediator);
        }

        /// <summary>
        /// Tests that a valid cart creation request is handled successfully.
        /// </summary>
        [Fact(DisplayName = "Given valid product data When creating cart Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = CloseCartHandlerTestData.GenerateValidCommand();

            var cart = new Cart
            {
                Id = command.Id,
                ProductsCart = new List<ProductCart>
                {
                    new ProductCart
                    {
                        Product = new Product
                        {
                            Id = Guid.NewGuid(),
                            Title = "Product 1",
                            Description = "Description 1",
                            Price = 10.0m
                        },
                        Quantity = 1
                    }
                }
            };

            var result = new CloseCartResponse
            {
                Success = true,
            };

            _mapper.Map<Cart>(command).Returns(cart);
            _mapper.Map<CloseCartResponse>(cart).Returns(result);

            _cartRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>())
            .Returns(cart);

            // When
            var closeCartResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            closeCartResult.Should().NotBeNull();
            closeCartResult.Success.Should().BeTrue();
            await _cartRepository.Received(1).GetByIdAsync(command.Id, Arg.Any<CancellationToken>());
        }

        /// <summary>
        /// Tests that an invalid cart creation request throws a validation exception.
        /// </summary>
        [Fact(DisplayName = "Given invalid cart data When creating cart Then throws validation exception")]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Given
            var command = new CloseCartCommand();

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<FluentValidation.ValidationException>();
        }        
    }
}
