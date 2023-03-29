using Cart_CartItems.Controllers;
using Cart_CartItems.DataAccess;
using Cart_CartItems.Models;
using Cart_CartItems.Query.CartQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMicroservices.Tests
{
    public class CartControllerTests
    {
        private readonly Mock<ICart> _cartServiceMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CartController _controller;

        public CartControllerTests()
        {
            _cartServiceMock = new Mock<ICart>();
            _mediatorMock = new Mock<IMediator>();
            _controller = new CartController(_cartServiceMock.Object, _mediatorMock.Object);
        }

        [Fact]
        public async Task GetAllCarts_ReturnsOk_WhenCartsExist()
        {
            // Arrange
            var cart = new List<Cart>
            {
                new Cart { Id = 1, UserId=1},
                 new Cart { Id = 2, UserId=2}
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCartDetailsQuery>(), default))
                .ReturnsAsync(cart);

            var controller = new CartController(_cartServiceMock.Object, _mediatorMock.Object);

            // Act
            var result = await controller.GetAllCarts();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetCartByUserId_WhenCartsExist()
        {
            // Arrange
            var cart = new Cart
            {
                Id = 1,
                UserId = 1
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCartByUserIdQuery>(), default))
                .ReturnsAsync(cart);

            var controller = new CartController(_cartServiceMock.Object, _mediatorMock.Object);

            // Act
            var result = await controller.GetCartByUserId(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
