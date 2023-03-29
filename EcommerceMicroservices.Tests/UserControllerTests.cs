using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_UAuthentication.Command.UserCommands;
using User_UAuthentication.Controllers;
using User_UAuthentication.Models;
using User_UAuthentication.Models.DTO;
using User_UAuthentication.Query.UserQuery;

namespace EcommerceMicroservices.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _userController = new UserController(_mediatorMock.Object);
        }

        [Fact]
        public async void GetAllUsers_ShouldReturnListOfUsers()
        {
            //Arrange
            var users = new List<User>
            {
                new User { UserId = 1, UserName = "John Doe", Email = "johndoe@example.com", City="City1", Address="Address1" },
                new User { UserId = 2, UserName = "Jane Doe", Email = "janedoe@example.com" , City="City2", Address="Address2" }
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAllUsersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(users);

            //Act
            var result = await _userController.GetAllUsers();

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(users, okResult.Value);
        }

        [Fact]
        public async void GetUserById_ShouldReturnByUserId()
        {
            var users = new User
            {
                UserId = 1,
                UserName = "John Doe",
                Email = "johndoe@example.com",
                City = "City1",
                Address = "Address1"
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(users);

            //Act
            var result = await _userController.GetUserById(1);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(users, okResult.Value);

        }

        [Fact]
        public async Task UpdateUser_ReturnsCreatedStatusCode()
        {
            // Arrange
            var user = new UserDto { UserId = 1, UserName = "John" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateUserCommand>(), CancellationToken.None)).Verifiable();



            // Act
            var result = await _userController.UpdateUser(user);



            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.Equal(201, statusCodeResult.StatusCode);
            _mediatorMock.Verify(m => m.Send(It.IsAny<UpdateUserCommand>(), CancellationToken.None), Times.Once);
        }



        [Fact]
        public async Task DeleteUserById_ReturnsOkStatusCode()
        {
            // Arrange
            var id = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteUserCommand>(), CancellationToken.None)).Verifiable();



            // Act
            var result = await _userController.DeleteUserById(id);



            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.Equal(200, statusCodeResult.StatusCode);
            _mediatorMock.Verify(m => m.Send(It.IsAny<DeleteUserCommand>(), CancellationToken.None), Times.Once);
        }

    }
}
