using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PaymentDetails_Mongo.Commands;
using PaymentDetails_Mongo.Controllers;
using PaymentDetails_Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMicroservices.Tests
{
    public class PaymentControllerTests
    {
        private readonly Payments _samplePayment = new Payments { id = "123", PaymentType = "Upi" };
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [Fact]
        public async Task Post_ReturnsStatusCode201()
        {
            // Arrange
            var controller = new PaymentController(_mockMediator.Object);

            // Act
            var result = await controller.Post(_samplePayment);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<AddPaymentCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, (result as StatusCodeResult).StatusCode);
        }
    }
}
