// using Application.Helpers;
// using Domain;
//
// namespace Application.UnitTests.Helpers;
//
// public class ScoreCalculatorHelperTests
// {
//     [Fact]
//     public void Test1()
//     {
//         // Arrange 
//         var user = new AppUser()
//         {
//             Username = "test"
//         };
//         var expected = 0;
//         
//         // Act
//         var result = ScoreCalculatorHelper.GetUserScore(user);
//     
//         // Assert
//         Assert.Equal(result, expected);
//     }
//     
//     [Theory]
//     [InlineData("test")]
//     [InlineData("test2")]
//     public void Test2(string username)
//     {
//         // Arrange 
//         var user = new AppUser()
//         {
//             Username = username,
//         };
//         user.TodoItems =
//         [
//             new TodoItem
//             {
//                 Title = "title",
//                 CompletedDate = null,
//                 Difficulty = 10,
//                 UserId = user.Id,
//                 User = user
//             }
//         ];
//         
//         var expected = 0;
//         
//         // Act
//         var result = ScoreCalculatorHelper.GetUserScore(user);
//
//         // Assert
//         Assert.Equal(result, expected);
//     } 
//     [Theory]
//     [InlineData("test2")]
//     public void Test3(string username)
//     {
//         // Arrange 
//         var user = new AppUser()
//         {
//             Username = username,
//         };
//         user.TodoItems =
//         [
//             new TodoItem
//             {
//                 Title = "title",
//                 CompletedDate = null,
//                 Difficulty = 10,
//                 UserId = user.Id,
//                 User = user
//             },
//             new TodoItem
//             {
//                 Title = "title2",
//                 CompletedDate = null,
//                 Difficulty = 10,
//                 UserId = user.Id,
//                 User = user
//             },
//             new TodoItem
//             {
//                 Title = "title3",
//                 CompletedDate = DateTime.Today,
//                 Difficulty = 10,
//                 UserId = user.Id,
//                 User = user
//             }
//         ];
//         
//         var expected = 10;
//         
//         // Act
//         var result = ScoreCalculatorHelper.GetUserScore(user);
//
//         // Assert
//         Assert.Equal(result, expected);
//     } 
// }