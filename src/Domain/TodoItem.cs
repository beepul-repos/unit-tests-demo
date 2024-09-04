namespace Domain;

public class TodoItem
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public DateTime? CompletedDate { get; set; }
    public int Difficulty { get; set; }

    public Guid UserId { get; set; }
    public AppUser User { get; set; } = null!;
}
