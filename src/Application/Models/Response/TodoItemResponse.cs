namespace Application.Models.Response;

public record TodoItemResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public DateTime? CompletedDate { get; init; }
    public int Difficulty { get; init; }
    public Guid UserId { get; init; }
}
