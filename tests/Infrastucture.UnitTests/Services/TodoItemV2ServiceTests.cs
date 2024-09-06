using Application.Data;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Domain;
using FluentAssertions;
using Infrastructure.Services;
using Infrastucture.UnitTests.Autofixture;
using Moq;

namespace Infrastucture.UnitTests.Services;

public class TodoItemV2ServiceTests
{
    [Fact]
    public async Task GetUserItems_When_Should()
    {
        // Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        var user = new AppUser
        {
            Username = "test",
            TodoItems = []
        };
        var todoItems = fixture.Build<TodoItem>()
            .With(x => x.UserId, user.Id)
            .With(x => x.User, user)
            .CreateMany(5) // Указываем количество создаваемых объектов
            .ToList();
        user.TodoItems = todoItems;

        var userRepo = fixture.Freeze<Mock<IUserRepository>>();
        userRepo.Setup(x => x.GetByUsernameAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        var sut = fixture.Create<TodoItemV2Service>();
        
        // Act 
        var result = await sut.GetUserItems("s");

        // Assert
        result.Count().Should().Be(5);
    }
    
    [Theory]
    [AutoDomainData]
    public async Task GetUserItemsWithData_When_Should(
        [Frozen] Mock<IUserRepository> userRepo,
        TodoItemV2Service sut,
        Fixture fixture)
    {
        // Arrange
        fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        var user = new AppUser
        {
            Username = "test",
            TodoItems = []
        };
        var todoItems = fixture.Build<TodoItem>()
            .With(x => x.UserId, user.Id)
            .With(x => x.User, user)
            .CreateMany(5) // Указываем количество создаваемых объектов
            .ToList();
        user.TodoItems = todoItems;

        userRepo.Setup(x => x.GetByUsernameAsync(It.IsAny<string>()))
            .ReturnsAsync(user);
        
        // Act 
        var result = await sut.GetUserItems("s");

        // Assert
        result.Count().Should().Be(5);
    }
}