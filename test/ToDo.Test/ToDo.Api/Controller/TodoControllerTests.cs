using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDo.Api.Controllers;
using ToDo.Application.DTOs.Business.Todo;
using ToDo.Application.UseCases.Business.Todo.Command;
using ToDo.Application.UseCases.Business.Todo.Query;
using ToDo.Domain.Common.Response;
using ToDo.Domain.Enum;

namespace ToDo.Test.ToDo.Api.Controller
{
    [TestClass]
    public class TodoControllerTests
    {
        private Mock<IMediator> _mediatorMock = null!;
        private TodoController _controller = null!;

        [TestInitialize]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new TodoController(_mediatorMock.Object);
        }

        [TestMethod]
        public async Task Create_ShouldReturnOk_WithResponse()
        {
            // Arrange
            var command = new CreateTodoCommand ("Test", "Desc", 0);
            var expectedResponse = new BaseResponse<int> { Data = 1 };

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Create(command) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedResponse, result.Value);
        }

        [TestMethod]
        public async Task Update_ShouldReturnOk_WithResponse()
        {
            // Arrange
            var command = new UpdateTodoCommand(1, "test", "testDescription", EnumStateTodo.InProgress, false, 1);
            var expectedResponse = new BaseResponse<int> { Data = 1 };

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Update(command) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedResponse, result.Value);
        }

        [TestMethod]
        public async Task Delete_ShouldReturnOk_WithResponse()
        {
            // Arrange
            var command = new DeleteTodoCommand(1);
            var expectedResponse = new BaseResponse<int> { Data = 1 };

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Delete(command) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedResponse, result.Value);
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnOk_WithTodoList()
        {
            // Arrange
            var query = new AllTodoQuery(1, null, null);
            var expectedResponse = new BaseResponse<List<AllTodoQueryResponse>>
            {
                Data = new List<AllTodoQueryResponse> {
                    new AllTodoQueryResponse { Id = 1, Name = "Task 1", Description = "Desc", Status = 0 }
                },
            };

            _mediatorMock
                .Setup(m => m.Send(query, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetAll(query) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedResponse, result.Value);
        }
    }
}
