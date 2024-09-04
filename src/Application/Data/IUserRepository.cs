using Domain;

namespace Application.Data;

public interface IUserRepository
{
    Task<IEnumerable<AppUser>> GetAllUsers();
    Task<AppUser?> GetByUsernameAsync(string username);
}
