using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Product_PCategory.Commands.ProductCommands;
using Product_PCategory.Controllers;
using Product_PCategory.Models;
using Product_PCategory.Models.DTO;
using Product_PCategory.Query.ProductsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMicroservices.Tests
{
    public class ProductControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ProductController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnOkObjectResult_WithListOfProducts()
        {
            // Arrange
            var expectedProducts = new List<Product>()
            {
                new Product { ProductId = 1, Name = "Product1",Description="Good", CategoryId = 1,Price=21000},
                new Product { ProductId = 2, Name = "Product 2",Description="Good", CategoryId = 2 ,Price=4000 },
                new Product { ProductId = 3, Name = "Product 3",Description="Good", CategoryId = 3, Price=500 },
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), default)).ReturnsAsync(expectedProducts);

            // Act
            var result = await _controller.GetAllProducts();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(expectedProducts, okResult.Value);
        }

        [Fact]
        public async Task GetProductById_ShouldReturnOkObjectResult_WithProduct()
        {
            // Arrange
            var expectedProduct = new Product { ProductId = 1, Name = "Product1", Description = "Good", CategoryId = 1, Price = 21000 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), default)).ReturnsAsync(expectedProduct);

            // Act
            var result = await _controller.GetProductById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(expectedProduct, okResult.Value);
        }


        [Fact]
        public async Task AddNewProduct_ReturnsCreatedStatus()
        {
            // Arrange
            var newProduct = new ProductRequestDto { ProductId = 1, Name = "Product1", Description = "Good", CategoryId = 1, Price = 21000 };
            var message = "Product added successfully.";

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(message);

            // Act
            var result = await _controller.AddNewProduct(newProduct) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(message, result.Value.GetType().GetProperty("Message").GetValue(result.Value));
        }

        [Fact]
        public async Task DeleteProduct_ReturnsCreatedStatus()
        {
            // Arrange
            var ProductId = 1;
            var message = "Product deleted successfully.";

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(message);

            // Act
            var result = await _controller.DeleteProduct(ProductId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(message, result.Value.GetType().GetProperty("Message").GetValue(result.Value));
        }

        [Fact]
        public async Task UpdateProduct_ReturnsCreatedStatus()
        {
            // Arrange
            var updatedProduct = new ProductRequestDto { ProductId = 1, Name = "Product1", Description = "Good", CategoryId = 1, Price = 28000 };
            var message = "Product updated successfully.";

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(message);

            // Act
            var result = await _controller.UpdateProduct(updatedProduct) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(message, result.Value.GetType().GetProperty("Message").GetValue(result.Value));
        }

    }
}
