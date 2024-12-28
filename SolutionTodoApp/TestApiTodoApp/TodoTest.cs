using Moq;
using System.Net;
using TestApiTodoApp.Mocks;
using TodoApp.Application.Services;
using TodoApp.Domain.Contracts;

namespace TestApiTodoApp
{
    [TestClass]
    public class TodoTest
    {
        [TestMethod]
        public void GetTodos_Ok()
        {
            //Arrange
            var allTodos = MockData.GetAllTodosAsync();
            Mock<ITodoRepository> todoRepository = new();
            TodoService todoService = new(todoRepository.Object);

            todoRepository.Setup(a => a.GetAllTodosAsync()).Returns(allTodos);

            //Act
            var todos = todoService.GetAllAsync();

            //Assert
            Assert.AreEqual(2, todos.Result.Count());
            Assert.AreEqual("Todo1", todos.Result.FirstOrDefault().Title);
            Assert.IsNotNull(todos);
            todoRepository.Verify(a => a.GetAllTodosAsync(), Times.Once);
        }

        [TestMethod]
        public void GetTodoById_Ok()
        {
            //Arrange
            var mockTodo = MockData.GetTodoByIdAsync();
            Mock<ITodoRepository> todoRepository = new();
            TodoService todoService = new(todoRepository.Object);

            todoRepository.Setup(a => a.GetTodoByIdAsync(It.IsAny<int>())).Returns(mockTodo);

            //Act
            var todos = todoService.GetByIdAsync(It.IsAny<int>());

            //Assert
            Assert.AreEqual("Yes", todos.Result.PendingApproval);
            Assert.AreEqual("Todo1", todos.Result.Title);
            Assert.IsNotNull(todos);
            todoRepository.Verify(a => a.GetTodoByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetTodoPendingApproval_Ok()
        {
            //Arrange
            var allTodos = MockData.GetAllTodosAsync();
            Mock<ITodoRepository> todoRepository = new();
            TodoService todoService = new(todoRepository.Object);

            todoRepository.Setup(a => a.GetTodoPendingApprovalAsync()).Returns(allTodos);

            //Act
            var todos = todoService.GetPendingApprovalAsync();

            //Assert
            Assert.AreEqual(2, todos.Result.Count());
            Assert.AreEqual("Todo", todos.Result.FirstOrDefault().State);
            Assert.IsNotNull(todos);
            todoRepository.Verify(a => a.GetTodoPendingApprovalAsync(), Times.Once);
        }
    }
}