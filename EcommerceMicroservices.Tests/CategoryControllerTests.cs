using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Product_PCategory.Commands.CategoryCommands;
using Product_PCategory.Controllers;
using Product_PCategory.Models;
using Product_PCategory.Query.ProductCategoryQuerys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMicroservices.Tests
{
    public class CategoryControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CategoryController _controller;

        public CategoryControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new CategoryController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetCategoryList_ReturnsOkObjectResult_WithListOfCategories()
        {
            // Arrange
            var categories = new List<ProductCategory> { new ProductCategory { CategoryId = 1, Category = "Category 1", SubCategory = "SubCategory1" }, new ProductCategory { CategoryId = 2, Category = "Category 2", SubCategory = "SubCategory2" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<ProductCategoryQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(categories);

            // Act
            var result = await _controller.GetCategoryList();

            // Assert
            var okResult = Assert.IsType<List<ProductCategory>>(result);
            Assert.Equal(categories.Count, okResult.Count);
            _mediatorMock.Verify(m => m.Send(It.IsAny<ProductCategoryQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetCategoryById_ReturnsProductCategory_WithValidId()
        {
            // Arrange
            var category = new ProductCategory { CategoryId = 1, Category = "Category 1", SubCategory = "SubCategory1" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<getCategoryByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(category);

            // Act
            var result = await _controller.GetCategoryById(1);

            // Assert
            var okResult = Assert.IsType<ProductCategory>(result);
            Assert.Equal(category.CategoryId, okResult.CategoryId);
            Assert.Equal(category.Category, okResult.Category);
            Assert.Equal(category.SubCategory, okResult.SubCategory);
            _mediatorMock.Verify(m => m.Send(It.IsAny<getCategoryByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AddNewCategory_ReturnsStatusCode201_WhenCategoryAddedSuccessfully()
        {
            // Arrange
            var newCategory = new ProductCategory { Category = "Test Category", SubCategory = "Test Sub Category" };
            var message = "Category added successfully";
            _mediatorMock.Setup(m => m.Send(It.IsAny<AddCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(message);

            // Act
            var result = await _controller.AddNewCategory(newCategory) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(message, result.Value.GetType().GetProperty("Message").GetValue(result.Value, null));
        }

        [Fact]
        public async Task UpdateCategory_ReturnsStatusCode201_WhenCategoryUpdatedSuccessfully()
        {
            // Arrange
            var updatedCategory = new ProductCategory { CategoryId = 1, Category = "Updated Category", SubCategory = "Updated Sub Category" };
            var message = "Category updated successfully";
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(message);

            // Act
            var result = await _controller.UpdateCategory(updatedCategory) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(message, result.Value.GetType().GetProperty("Message").GetValue(result.Value, null));
        }

        [Fact]
        public async Task DeleteCategory_ReturnsStatusCode200_WhenCategoryDeletedSuccessfully()
        {
            // Arrange
            var CategoryId = 1;
            var message = "Category deleted successfully";
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(message);

            // Act
            var result = await _controller.DeleteCategory(CategoryId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(message, result.Value.GetType().GetProperty("Message").GetValue(result.Value, null));
        }

    }
}
