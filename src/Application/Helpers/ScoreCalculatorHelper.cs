using Domain;

namespace Application.Helpers;

public static class ScoreCalculatorHelper
{
    public static int GetUserScore(AppUser user)
    {
        return user.TodoItems
            .Where(x => x.CompletedDate != null)
            .Sum(x => x.Difficulty);
    }
}
