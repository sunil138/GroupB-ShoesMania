using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Orders.Commands;
using Orders.Controllers;
using Orders.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_UAuthentication.Models;

namespace EcommerceMicroservices.Tests
{
    public class OrdersControllerTests
    {
        [Fact]
        public async Task PlaceOrder_Returns_OkResult_With_Valid_Request()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var request = new OrderRequestDto { UserId=1 };
            var response = new OrderPlacedResponseDto { /* your test data */ };
            mediatorMock.Setup(m => m.Send(It.IsAny<AddOrderCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);
            var controller = new OrdersController(mediatorMock.Object);

            // Act
            var result = await controller.PlaceOrder(request);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(response, okResult.Value);
        }
    }
}
