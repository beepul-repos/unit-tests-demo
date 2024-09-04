namespace Application.Models.Response;

public record AppUserResponse
{
    public Guid Id { get; init; }
    public string Username { get; init; } = string.Empty;
}
