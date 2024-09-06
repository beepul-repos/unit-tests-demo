using Application.Data;
using Domain;
using FluentAssertions;
using Infrastructure.Services;
using MockQueryable;
using Moq;

namespace Infrastucture.UnitTests.Services;

public class TodoItemServiceTests
{
    
    
    [Theory]
    [InlineData("test1")]
    [InlineData("test-rando   m -user")]
    public async Task GetUserItems_When_Should(string username)
    {
        // Arrange
        var userRepository = new Mock<IUserRepository>();
        var todoRepository = new Mock<ITodoItemsRepository>();
        
        userRepository
            .Setup(repo => repo.GetByUsernameAsync(It.IsAny<string>()))
            .ReturnsAsync((AppUser?)null);
        
        var sut = new TodoItemService(userRepository.Object, todoRepository.Object);

        // Act
        Func<Task> act = async () => await sut.GetUserItems(username);

        // Assert
        await act.Should().ThrowAsync<Exception>()
            .WithMessage("User not found");
    }
    
    [Theory]
    [InlineData("test1")]
    [InlineData("test-rando   m -user")]
    public async Task GetUserItems_WhenUserFound_ShouldReturnItems(string username)
    {
        // Arrange
        var userRepository = new Mock<IUserRepository>();
        var todoRepository = new Mock<ITodoItemsRepository>();
        
        // Создаем тестовый объект AppUser
        var testUser = new AppUser
        {
            Username = "testuser",
            TodoItems = [],
        };

        userRepository
            .Setup(repo => repo.GetByUsernameAsync(It.IsAny<string>()))
            .ReturnsAsync(testUser);
        
        var sut = new TodoItemService(userRepository.Object, todoRepository.Object);
        
        // Act
        var result = await sut.GetUserItems(username);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAll_When_Should()
    {
        // Arrange
        var userRepository = new Mock<IUserRepository>();
        var todoRepository = new Mock<ITodoItemsRepository>();

        var sut = new TodoItemService(userRepository.Object, todoRepository.Object);
        
        // Создаем тестовый объект TodoItem
        var testTodoItem = new TodoItem
        {
            Title = "Test Todo Item"
        };

        var todoItems = new List<TodoItem> { testTodoItem };
        var mock = todoItems.BuildMock();
        
        todoRepository
            .Setup(repo => repo.Query)
            .Returns(mock);
        
        // Act 
        var result = await sut.GetAll();

        // Assert
        result.Count().Should().Be(todoItems.Count);
    }

    [Fact]
    public async Task GetOnlyCompleted_When_Should()
    {
        // Arrange
        var userRepository = new Mock<IUserRepository>();
        var todoRepository = new Mock<ITodoItemsRepository>();

        var sut = new TodoItemService(userRepository.Object, todoRepository.Object);
        
        var testUser = new AppUser
        {
            Username = "testuser",
            TodoItems = [],
        };
        testUser.TodoItems =
        [
            new TodoItem
            {
                Title = "t2",
                CompletedDate = DateTime.Today,
                UserId = testUser.Id,
                User = testUser
            },
            new TodoItem
            {
                Title = "t1",
                CompletedDate = null,
                UserId = testUser.Id,
                User = testUser
            }
        ];

        userRepository
            .Setup(repo => repo.GetByUsernameAsync(It.IsAny<string>()))
            .ReturnsAsync(testUser);

        var mock = testUser.TodoItems.BuildMock();
        todoRepository.Setup(x => x.Query).Returns(mock);
        
        // Act
        var result = await sut.GetOnlyCompleted(testUser.Username);
        
        // Assert
        result.Count().Should().Be(1);
    }
}