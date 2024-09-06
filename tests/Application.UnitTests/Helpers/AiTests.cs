using Application.Helpers;
using Domain;

namespace Application.UnitTests.Helpers;

public class AiTests
{
    [Fact]
    public void GetUserScore_UsernameIsTest_ReturnsZero()
    {
        // Arrange
        var user = new AppUser
        {
            Username = "test"
        };

        // Act
        var score = ScoreCalculatorHelper.GetUserScore(user);

        // Assert
        Assert.Equal(0, score);
    }

    [Fact]
    public void GetUserScore_NoCompletedTasks_ReturnsZero()
    {
        // Arrange
        var user = new AppUser
        {
            Username = "user1",
            TodoItems = new List<TodoItem>
            {
                new TodoItem { Title = "Task 1", CompletedDate = null, Difficulty = 5 },
                new TodoItem { Title = "Task 2", CompletedDate = null, Difficulty = 3 }
            }
        };

        // Act
        var score = ScoreCalculatorHelper.GetUserScore(user);

        // Assert
        Assert.Equal(0, score);
    }

    [Fact]
    public void GetUserScore_WithCompletedTasks_ReturnsSumOfDifficulties()
    {
        // Arrange
        var user = new AppUser
        {
            Username = "user2",
            TodoItems = new List<TodoItem>
            {
                new TodoItem { Title = "Task 1", CompletedDate = DateTime.Now, Difficulty = 5 },
                new TodoItem { Title = "Task 2", CompletedDate = DateTime.Now, Difficulty = 3 }
            }
        };

        // Act
        var score = ScoreCalculatorHelper.GetUserScore(user);

        // Assert
        Assert.Equal(9, score);
    }

    [Fact]
    public void GetUserScore_WithMixedTasks_ReturnsSumOfCompletedTaskDifficulties()
    {
        // Arrange
        var user = new AppUser
        {
            Username = "user3",
            TodoItems = new List<TodoItem>
            {
                new TodoItem { Title = "Task 1", CompletedDate = DateTime.Now, Difficulty = 5 },
                new TodoItem { Title = "Task 2", CompletedDate = null, Difficulty = 3 }
            }
        };

        // Act
        var score = ScoreCalculatorHelper.GetUserScore(user);

        // Assert
        Assert.Equal(5, score);
    }
}