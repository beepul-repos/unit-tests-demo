namespace Domain;

public class AppUser
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    
    public List<TodoItem> TodoItems { get; set; } = [];
}
